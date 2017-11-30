using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using Oracle.ManagedDataAccess.Client;
using POCO_EF_Oracle.Models;


namespace POCO_EF_Oracle
{
    public class DbUtil
    {
        private static OracleConnection _database = new OracleConnection();

        public static List<string> ListTnsNames()
        {
            const string providerName = "Oracle.ManagedDataAccess.Client";

            var tns = new List<string>();
            var factory = DbProviderFactories.GetFactory(providerName);
            if (factory.CanCreateDataSourceEnumerator)
            {
                var dsenum = factory.CreateDataSourceEnumerator();
                if (dsenum != null)
                {
                    var dt = dsenum.GetDataSources();
                    tns.AddRange(dt.Rows.Cast<DataRow>().Select(row => row[0].ToString()));
                }
            }
            tns.Sort();
            return tns;
        }

        public static void OpenConnection(string dataSource, string userId, string password)
        {
            var csb = new OracleConnectionStringBuilder
            {
                DataSource = dataSource,
                UserID = userId,
                Password = password
            };
            _database = new OracleConnection(csb.ConnectionString);
            _database.Open();
        }

        public static List<string> LisTables(string text)
        {
            string sql = string.Empty;
            var lisTables = new List<string>();
            if (string.IsNullOrWhiteSpace(text))
                sql = $"SELECT TABLE_NAME  FROM USER_TABLES ORDER BY TABLE_NAME";
            else
                sql = $"SELECT TABLE_NAME  FROM USER_TABLES WHERE TABLE_NAME LIKE '{text}' ORDER BY TABLE_NAME";

            var cmd = new OracleCommand(sql, _database);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                lisTables.Add(reader["TABLE_NAME"].ToString());
            }
            return lisTables;
        }

        public static List<string> ListViews(string text)
        {
            string sql = string.Empty;
            var viewList = new List<string>();
            if (string.IsNullOrWhiteSpace(text))
                sql = $"SELECT VIEW_NAME FROM USER_VIEWS ORDER BY VIEW_NAME";
            else
            {
                sql = $"SELECT VIEW_NAME FROM USER_VIEWS WHERE TABLE_NAME LIKE :p0 ORDER BY VIEW_NAME";
            }
            var cmd = new OracleCommand(sql, _database);

            if (!string.IsNullOrEmpty(text))
            {
                if (sql.EndsWith("%"))
                    cmd.Parameters.Add(":p0", string.Concat(text, "%"));
                else if (sql.StartsWith("%"))
                    cmd.Parameters.Add(":p0", string.Concat("%", text));
                else
                    cmd.Parameters.Add(":p0", text);
            }
            
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                viewList.Add(reader["VIEW_NAME"].ToString());
            }

            return viewList;
        }

        public static List<TableView> ColumunsViews(string table)
        {
            var columnsTable = new List<TableView>();
            const string sqlView = @"SELECT COLUMN_NAME, DATA_TYPE, DATA_LENGTH, DATA_SCALE, NULLABLE FROM user_tab_columns WHERE table_name = :p0 ORDER BY column_id";
            var cmd = new OracleCommand(sqlView, _database);
            cmd.Parameters.Add(":p0", table);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var tb = new TableView
                {
                    ColumnName = reader["COLUMN_NAME"].ToString(),
                    ColumnNameFriendly = Services.FriendlyName(reader["COLUMN_NAME"].ToString()),
                    DateType = reader["DATA_TYPE"].ToString(),
                    DataLength = Convert.ToInt32(reader["DATA_LENGTH"].ToString()),
                    DataScale = reader["DATA_SCALE"].ToString() != ""
                        ? Convert.ToInt32(reader["DATA_SCALE"].ToString())
                        : 0,
                    Nullable = reader["NULLABLE"].ToString()
                };
                columnsTable.Add(tb);
            }
            return columnsTable;

        }

        public static List<TableView> ColumnsTable(string table)
        {
            var columnsTable = new List<TableView>();

            const string sql = @"SELECT TAB.COLUMN_NAME,
                                     TAB.DATA_TYPE,
                                     TAB.DATA_LENGTH,
                                     TAB.DATA_SCALE,
                                     TAB.NULLABLE,          
                                     AL.POSITION
                                FROM USER_TAB_COLUMNS TAB
                                    LEFT JOIN USER_CONSTRAINTS USER_CONS ON USER_CONS.TABLE_NAME = TAB.TABLE_NAME AND USER_CONS.CONSTRAINT_TYPE = 'P'
                                    LEFT JOIN ALL_CONS_COLUMNS AL ON AL.CONSTRAINT_NAME =  USER_CONS.CONSTRAINT_NAME AND TAB.COLUMN_NAME = AL.COLUMN_NAME AND AL.OWNER = USER_CONS.OWNER
                               WHERE TAB.TABLE_NAME = :p0
                            ORDER BY AL.POSITION, TAB.COLUMN_ID";
            var cmd = new OracleCommand(sql, _database);
            cmd.Parameters.Add(":p0", table);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var position = 0;
                var tb = new TableView
                {
                    ColumnName = reader["COLUMN_NAME"].ToString(),
                    ColumnNameFriendly = Services.FriendlyName(reader["COLUMN_NAME"].ToString()),
                    DateType = reader["DATA_TYPE"].ToString(),
                    DataLength = Convert.ToInt32(reader["DATA_LENGTH"].ToString()),
                    DataScale = reader["DATA_SCALE"].ToString() != ""
                        ? Convert.ToInt32(reader["DATA_SCALE"].ToString())
                        : 0,
                    Nullable = reader["NULLABLE"].ToString(),
                    Position = int.TryParse(reader["POSITION"].ToString(), out position) ? position : 0
                };
                columnsTable.Add(tb);

            }
            return columnsTable;
        }

        public static List<ContraintTable> ListAllForeignKeyes(string table)
        {
            List<ContraintTable> list = new List<ContraintTable>();

            const string sql = @"  SELECT 
                                     UC.TABLE_NAME CHILD_TABLE,
                                     UC.CONSTRAINT_NAME CONSTRAINT_NAME,                                    
                                     UCC.COLUMN_NAME CHILD_COLUMN,
                                     UCR.TABLE_NAME PARENT_TABLE,
                                     UCCR.COLUMN_NAME PARENT_COLUMN
                                FROM USER_CONSTRAINTS UC
                                     INNER JOIN USER_CONSTRAINTS UCR ON UCR.CONSTRAINT_NAME = UC.R_CONSTRAINT_NAME
                                     INNER JOIN USER_CONS_COLUMNS UCC ON UCC.CONSTRAINT_NAME = UC.CONSTRAINT_NAME AND UC.TABLE_NAME = UCC.TABLE_NAME
                                     INNER JOIN USER_CONS_COLUMNS UCCR ON UCCR.CONSTRAINT_NAME = UCR.CONSTRAINT_NAME AND UCR.TABLE_NAME = UCCR.TABLE_NAME AND UCCR.POSITION = UCC.POSITION
                               WHERE     UCR.TABLE_NAME = :p01  
                                     AND UCR.CONSTRAINT_TYPE IN ('P', 'U')
                            ORDER BY CHILD_TABLE, CONSTRAINT_NAME, CHILD_COLUMN";
            var cmd = new OracleCommand(sql, _database);
            cmd.Parameters.Add(":p0", table);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var contraintTable = new ContraintTable
                {
                    ChildColumn = reader["CHILD_COLUMN"].ToString(),
                    ChildTable = reader["CHILD_TABLE"].ToString(),
                    ConstraintName = reader["CONSTRAINT_NAME"].ToString(),
                    ParentColumn = reader["PARENT_COLUMN"].ToString(),
                    ParentTale = reader["PARENT_TABLE"].ToString()
                };
                //TODO: caso tenha que mapear outras FK, fazer um list no pai
                if (!list.Where(x => x.ChildTable == contraintTable.ChildTable).Any())
                    list.Add(contraintTable);
            }
            return list;
        }

        public static void CloseConnection()
        {
            _database.Close();
        }
    }

}
