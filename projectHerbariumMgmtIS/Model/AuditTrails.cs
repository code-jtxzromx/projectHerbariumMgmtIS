using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectHerbariumMgmtIS.Model
{
    public class AuditTrails
    {
        // Properties
        public string Staff { get; set; }
        public string Module { get; set; }
        public string TransactionDescription { get; set; }
        public string Timestamp { get; set; }

        // Constructor
        public AuditTrails()
        {
            this.Staff = "";
            this.Module = "";
            this.TransactionDescription = "";
            this.Timestamp = "";
        }

        // Methods
        public List<AuditTrails> GetAudits()
        {
            List<AuditTrails> audits = new List<AuditTrails>();
            DatabaseConnection connection = new DatabaseConnection();

            connection.setQuery("SELECT strStaff, strModule, strTransactionDesc, dateTimeStamp " +
                                "FROM viewAuditTrailing " +
                                "ORDER BY dateTimeStamp DESC");
            SqlDataReader sqlData = connection.executeResult();

            while (sqlData.Read())
            {
                audits.Add(new AuditTrails()
                {
                    Staff = sqlData[0].ToString(),
                    Module = sqlData[1].ToString(),
                    TransactionDescription = sqlData[2].ToString(),
                    Timestamp = sqlData[3].ToString()
                });
            }
            connection.closeResult();
            return audits;
        }
    }
}
