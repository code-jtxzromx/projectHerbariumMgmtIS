using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectHerbariumMgmtIS.Model
{
    public class Borrower
    {
        // Properties
        public int BorrowerID { get; set; }
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
        public Borrower()
        {
            this.BorrowerID = 0;
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
        public List<Borrower> GetBorrowers()
        {
            List<Borrower> Borrowers = new List<Borrower>();
            DatabaseConnection connection = new DatabaseConnection();

            connection.setQuery("SELECT intBorrowerID, strFirstname, strMiddlename, strLastname, strMiddleInitial, strNameSuffix, " +
                                    "strHomeAddress, strContactNumber, strEmailAddress, strFullName, strAffiliation  " +
                                "FROM viewBorrower " +
                                "WHERE boolIsCollector = 0 " +
                                "ORDER BY strLastname, strFirstname");
            SqlDataReader sqlData = connection.executeResult();

            while (sqlData.Read())
            {
                Borrowers.Add(new Borrower()
                {
                    BorrowerID = Convert.ToInt32(sqlData[0]),
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
            return Borrowers;
        }

        public List<string> GetBorrowerList()
        {
            List<string> Borrowers = new List<string>();
            DatabaseConnection connection = new DatabaseConnection();

            connection.setQuery("SELECT strFullName FROM viewBorrower ORDER BY strFullName");
            SqlDataReader sqlData = connection.executeResult();

            while (sqlData.Read())
            {
                Borrowers.Add(sqlData[0].ToString());
            }
            connection.closeResult();
            return Borrowers;
        }

        public int AddBorrower()
        {
            int status;
            DatabaseConnection connection = new DatabaseConnection();

            connection.setStoredProc("dbo.procInsertBorrower");
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

        public int EditBorrower()
        {
            int status;
            DatabaseConnection connection = new DatabaseConnection();

            connection.setStoredProc("dbo.procUpdateBorrower");
            connection.addProcParameter("@BorrowerID", SqlDbType.Int, BorrowerID);
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
