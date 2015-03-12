using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLObjectBackup
{
    public class SqlSchema
    {
        public string Name { get; private set; }
        public string QuotedName { get; private set; }

        public SqlSchema(string name, string quotedName)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Schema name cannot be null or empty");
            if (string.IsNullOrWhiteSpace(quotedName))
                throw new ArgumentException("Quoted schema name cannot be null or empty");

            Name = name;
            QuotedName = quotedName;
        }
    }
}
