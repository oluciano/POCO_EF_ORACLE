using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POCO_EF_Oracle.Models
{
    public class ContraintTable
    {
        public string ConstraintName { get; set; }
        public string ChildTable { get; set; }
        public string ChildColumn { get; set; }
        public string ParentTale { get; set; }
        public string ParentColumn { get; set; }
        public override string ToString()
        {
            return ChildTable;
        }
    }
}
