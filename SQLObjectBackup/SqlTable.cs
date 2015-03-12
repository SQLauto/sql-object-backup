using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace SQLObjectBackup
{
    public class SqlTable
    {
        public int ObjectId { get; set; }
        public string ObjectName { get; private set; }
        public string QuotedObjectName { get; private set; }
        public SqlSchema Schema { get; private set; }
        public string FullyQuotedName { get { return GetFullyQuotedName(); } }

        public SqlTable(int objectId, SqlSchema schema, string objectName, string quotedObjectName)
        {
            if (objectId == 0)
                throw new ArgumentException("ObjectID cannot be zero");
            if (schema == null)
                throw new ArgumentNullException("schema");
            if (string.IsNullOrWhiteSpace(objectName))
                throw new ArgumentException("Object name cannot be null or empty");
            if (string.IsNullOrWhiteSpace(quotedObjectName))
                throw new ArgumentException("Quoted object name cannot be null or empty");

            ObjectId = objectId;
            ObjectName = objectName;
            Schema = schema;
            QuotedObjectName = quotedObjectName;
        }

        private string GetFullyQuotedName()
        {
            return string.Format("{0}.{1}", Schema.QuotedName, QuotedObjectName);
        }
    }
}
