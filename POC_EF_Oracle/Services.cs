using System.Globalization;
using System.Text.RegularExpressions;
using POCO_EF_Oracle.Models;
using System.Text;

namespace POCO_EF_Oracle
{
    public static class Services
    {
        public static bool FlagSelftimer;

        public static string GenerateRtbText(string textIn)
        {
            var text = Regex.Split(textIn, "\n");

            var lvl = 0;
            var newString = string.Empty;
            foreach (var line in text)
            {
                if (line.Trim().Equals("{"))
                {
                    newString += Indentation(lvl) + line.Trim() + "\n";
                    lvl++;
                }
                else if (line.Trim().Equals("}"))
                {
                    lvl--;
                    newString += Indentation(lvl) + line.Trim() + "\n";
                }
                else
                {
                    newString += Indentation(lvl) + line.Trim() + "\n";
                }
            }

            FlagSelftimer = true;
            return newString;
        }

        public static string Indentation(int indentLevel)
        {
            var space = string.Empty;
            if (indentLevel <= 0)
                return space;
            for (var lvl = 0; lvl < indentLevel; lvl++)
            {
                space += " ".PadLeft(3);
            }

            return space;
        }

        public static string FriendlyName(string text)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(text.Replace('_', ' ').Trim().ToLower()).Replace(" ", "");
        }
        
        public static string MakeView(TabControlTable tabControlTable)
        {
            var sb = new StringBuilder();
            var source = Properties.Resources.BaseModel;

            foreach (TableView item in tabControlTable.Columns)
            {
                var key = "Key";
                var order = $"Order = {item.Position}";
                var stringLength = $"StringLength({item.DataLength})";
                var typeName = $"TypeName = \"{item.DateType}\"";
                var required = "Required";
                var columnName = $"Column(\"{item.ColumnName}\", {typeName} {(item.Position > 0 ? ", " + order : string.Empty) })";

                if (item.Position > 0 && tabControlTable.PrimaryKey)               
                    sb.AppendLine($"[{key}]");
                
                if (tabControlTable.Required && item.Nullable == DataType.Nullable && item.DateType == DataType.Varchar2)
                    sb.AppendLine($"[{required}]");

                if (tabControlTable.Length && item.DateType != DataType.Date)
                    sb.AppendLine($"[{stringLength}]");
                sb.AppendLine($"[{columnName}]");

                string property;

                switch (item.DateType)
                {
                    case DataType.Date:
                        property = "DateTime? ";
                        break;
                    case DataType.Number:

                        if (item.DataScale > 0)
                            property = "decimal";
                        else if (item.DataLength >= 19)
                            property = "long";
                        else
                            property = "int";
                        if (!item.Nullable.Equals(DataType.Nullable))
                            property = string.Concat(property, "?");
                        break;
                    default:
                        property = "string";
                        break;
                }
                sb.AppendLine($"public {property} {item.ColumnNameFriendly} {{ get; set; }}");
                sb.AppendLine(string.Empty);
            }
            return source.Replace("_NAMESPACE", tabControlTable.NameSpace)
                         .Replace("_TABLENAME", tabControlTable.Table)
                         .Replace("_SCHEMA", tabControlTable.Schema)
                         .Replace("_MODELNAME", tabControlTable.FriendlyTable)
                         .Replace("_COLUMNS", sb.ToString());
        }

    }
}
