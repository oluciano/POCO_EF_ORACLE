namespace POCO_EF_Oracle.Models
{
    public class TableView
    {
        public string ColumnName { get; set; }
        public string ColumnNameFriendly { get; set; }
        public string DateType { get; set; }
        public int DataLength { get; set; }
        public int DataScale { get; set; }
        public string Nullable { get; set; }
        public int Position { get; set; }

        public override string ToString()
        {
            return ColumnName;
        }
    }
}
