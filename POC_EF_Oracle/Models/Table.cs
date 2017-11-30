using System.Collections.Generic;

namespace POCO_EF_Oracle.Models
{
    public class Table
    {
        public Table()
        {
            Constraints = new List<ContraintTable>();
        }
        public string TableName { get; set; }
        public bool IsView { get; set; }
        public bool ShowConstraint { get; set; }
        public List<ContraintTable> Constraints { get; set; }
    }
}
