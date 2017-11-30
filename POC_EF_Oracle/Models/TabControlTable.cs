using System.Collections.Generic;

namespace POCO_EF_Oracle.Models
{
    public class TabControlTable
    {
        public string Table { get; set; }
        public string FriendlyTable { get; set; }
        public bool TypeName { get; set; }
        public bool Required { get; set; }
        public bool PrimaryKey { get; set; }
        public bool AllInLine { get; set; }
        public bool Length { get; set; }    
        public bool IsView { get; set; }
        public string NameSpace { get; set; }
        public string NameOfFile { get; set; }
        public string Schema { get; set; }
        public List<TableView> Columns { get; set; }

    }
}
