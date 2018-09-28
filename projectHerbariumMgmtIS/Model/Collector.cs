using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectHerbariumMgmtIS.Model
{
    public class Collector
    {
        // Properties
        public int CollectorID { get; set; }
        public string FullName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string MiddleInitial { get; set; }
        public string NameSuffix { get; set; }
        public string HomeAddress { get; set; }
        public string ContactNumber { get; set; }
        public string Email { get; set; }
        public string Affiliation { get; set; }

        // Constructor
        public Collector()
        {
            this.CollectorID = 0;
            this.FullName = "";
            this.FirstName = "";
            this.MiddleName = "";
            this.LastName = "";
            this.MiddleInitial = "";
            this.NameSuffix = "";
            this.HomeAddress = "";
            this.ContactNumber = "";
            this.Email = "";
            this.Affiliation = "";
        }

        // Methods
        public List<Collector> GetCollectors()
        {
            List<Collector> collectors = new List<Collector>();
            DatabaseConnection connection = new DatabaseConnection();

            connection.setQuery("SELECT intCollectorID, strFirstname, strMiddlename, strLastname, strMiddleInitial, strNameSuffix, " +
                                    "strHomeAddress, strContactNumber, strEmailAddress, strFullName, strAffiliation  " +
                                "FROM viewCollector " +
                                "ORDER BY strLastname, strFirstname");
            SqlDataReader sqlData = connection.executeResult();

            while (sqlData.Read())
            {
                collectors.Add(new Collector()
                {
                    CollectorID = Convert.ToInt32(sqlData[0]),
                    FirstName = sqlData[1].ToString(),
                    MiddleName = sqlData[2].ToString(),
                    LastName = sqlData[3].ToString(),
                    MiddleInitial = sqlData[4].ToString(),
                    NameSuffix = sqlData[5].ToString(),
                    HomeAddress = sqlData[6].ToString(),
                    ContactNumber = sqlData[7].ToString(),
                    Email = sqlData[8].ToString(),
                    FullName = sqlData[9].ToString(),
                    Affiliation = sqlData[10].ToString()
                });
            }
            connection.closeResult();
            return collectors;
        }

        public List<string> GetCollectorList()
        {
            List<string> collectors = new List<string>();
            DatabaseConnection connection = new DatabaseConnection();

            connection.setQuery("SELECT strFullName FROM viewCollector ORDER BY strFullName");
            SqlDataReader sqlData = connection.executeResult();

            while (sqlData.Read())
            {
                collectors.Add(sqlData[0].ToString());
            }
            connection.closeResult();
            return collectors;
        }

        public int AddCollector()
        {
            int status;
            DatabaseConnection connection = new DatabaseConnection();

            connection.setStoredProc("dbo.procInsertCollector");
            connection.addProcParameter("@firstname", SqlDbType.VarChar, FirstName);
            connection.addProcParameter("@middlename", SqlDbType.VarChar, MiddleName);
            connection.addProcParameter("@lastname", SqlDbType.VarChar, LastName);
            connection.addProcParameter("@middleinitial", SqlDbType.VarChar, MiddleInitial);
            connection.addProcParameter("@namesuffix", SqlDbType.VarChar, NameSuffix);
            connection.addProcParameter("@address", SqlDbType.VarChar, HomeAddress);
            connection.addProcParameter("@contactno", SqlDbType.VarChar, ContactNumber);
            connection.addProcParameter("@email", SqlDbType.VarChar, Email);
            connection.addProcParameter("@affiliation", SqlDbType.VarChar, Affiliation);
            status = connection.executeProcedure();

            return status;
        }

        public int EditCollector()
        {
            int status;
            DatabaseConnection connection = new DatabaseConnection();

            connection.setStoredProc("dbo.procUpdateCollector");
            connection.addProcParameter("@collectorID", SqlDbType.Int, CollectorID);
            connection.addProcParameter("@firstname", SqlDbType.VarChar, FirstName);
            connection.addProcParameter("@middlename", SqlDbType.VarChar, MiddleName);
            connection.addProcParameter("@lastname", SqlDbType.VarChar, LastName);
            connection.addProcParameter("@middleinitial", SqlDbType.VarChar, MiddleInitial);
            connection.addProcParameter("@namesuffix", SqlDbType.VarChar, NameSuffix);
            connection.addProcParameter("@address", SqlDbType.VarChar, HomeAddress);
            connection.addProcParameter("@contactno", SqlDbType.VarChar, ContactNumber);
            connection.addProcParameter("@email", SqlDbType.VarChar, Email);
            connection.addProcParameter("@affiliation", SqlDbType.VarChar, Affiliation);
            status = connection.executeProcedure();

            return status;
        }
    }
}
