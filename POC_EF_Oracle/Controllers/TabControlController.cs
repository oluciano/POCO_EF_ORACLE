using System.Collections.Generic;
using System.Linq;
using POCO_EF_Oracle.Models;

namespace POCO_EF_Oracle.Controllers
{
    public static class TabControlController
    {
        public static readonly List<TabControlTable> ListTabControlTables = new List<TabControlTable>();

        public static void AddOrUpdate(TabControlTable tabControlTable)
        {
            var controlTable = ListTabControlTables.FirstOrDefault(c => c.Table == tabControlTable.Table);
            if (controlTable != null)
                ListTabControlTables.Remove(controlTable);
            ListTabControlTables.Add(tabControlTable);            
        }

        public static TabControlTable Get(string tableName)
        {
            return ListTabControlTables.FirstOrDefault(c => c.Table == tableName);
        }

        public static void Remove(TabControlTable tabControlTable)
        {
            ListTabControlTables.Remove(tabControlTable);
        }        
    }
}
