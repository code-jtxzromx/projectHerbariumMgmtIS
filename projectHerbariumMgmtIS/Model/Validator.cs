using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectHerbariumMgmtIS.Model
{
    public class Validator
    {
        // Properties
        public int ValidatorID { get; set; }
        public string FullName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string MiddleInitial { get; set; }
        public string NameSuffix { get; set; }
        public string ContactNumber { get; set; }
        public string Email { get; set; }
        public string Institution { get; set; }

        // Constructor
        public Validator()
        {
            this.ValidatorID = 0;
            this.FullName = "";
            this.FirstName = "";
            this.MiddleName = "";
            this.LastName = "";
            this.MiddleInitial = "";
            this.NameSuffix = "";
            this.ContactNumber = "";
            this.Email = "";
            this.Institution = "";
        }

        // Methods
        public List<Validator> GetValidators()
        {
            List<Validator> validators = new List<Validator>();
            DatabaseConnection connection = new DatabaseConnection();

            connection.setQuery("SELECT intValidatorID, strFirstname, strMiddlename, strLastname, strMiddleInitial, strNameSuffix, " +
                                        "strContactNumber, strEmailAddress, strFullName, strInstitution " +
                                "FROM viewValidator " +
                                "WHERE strValidatorType = 'External' " +
                                "ORDER BY strLastname, strFirstname");
            SqlDataReader sqlData = connection.executeResult();
            
            while (sqlData.Read())
            {
                validators.Add(new Validator()
                {
                    ValidatorID = Convert.ToInt32(sqlData[0]),
                    FirstName = sqlData[1].ToString(),
                    MiddleName = sqlData[2].ToString(),
                    LastName = sqlData[3].ToString(),
                    MiddleInitial = sqlData[4].ToString(),
                    NameSuffix = sqlData[5].ToString(),
                    ContactNumber = sqlData[6].ToString(),
                    Email = sqlData[7].ToString(),
                    FullName = sqlData[8].ToString(),
                    Institution = sqlData[9].ToString()
                });
            }
            connection.closeResult();
            return validators;
        }

        public List<string> GetValidatorList()
        {
            List<string> Borrowers = new List<string>();
            DatabaseConnection connection = new DatabaseConnection();

            connection.setQuery("SELECT strFullName FROM viewValidator ORDER BY strFullName");
            SqlDataReader sqlData = connection.executeResult();

            while (sqlData.Read())
            {
                Borrowers.Add(sqlData[0].ToString());
            }
            connection.closeResult();
            return Borrowers;
        }

        public int AddValidator()
        {
            int status;
            DatabaseConnection connection = new DatabaseConnection();

            connection.setStoredProc("dbo.procInsertValidator");
            connection.addProcParameter("@firstname", SqlDbType.VarChar, FirstName);
            connection.addProcParameter("@lastname", SqlDbType.VarChar, LastName);
            connection.addProcParameter("@middlename", SqlDbType.VarChar, MiddleName);
            connection.addProcParameter("@middleinitial", SqlDbType.VarChar, MiddleInitial);
            connection.addProcParameter("@namesuffix", SqlDbType.VarChar, NameSuffix);
            connection.addProcParameter("@contactno", SqlDbType.VarChar, ContactNumber);
            connection.addProcParameter("@email", SqlDbType.VarChar, Email);
            connection.addProcParameter("@institution", SqlDbType.VarChar, Institution);
            status = connection.executeProcedure();

            return status;
        }

        public int EditValidator()
        {
            int status;
            DatabaseConnection connection = new DatabaseConnection();

            connection.setStoredProc("dbo.procUpdateValidator");
            connection.addProcParameter("@validatorID", SqlDbType.Int, ValidatorID);
            connection.addProcParameter("@firstname", SqlDbType.VarChar, FirstName);
            connection.addProcParameter("@lastname", SqlDbType.VarChar, LastName);
            connection.addProcParameter("@middlename", SqlDbType.VarChar, MiddleName);
            connection.addProcParameter("@middleinitial", SqlDbType.VarChar, MiddleInitial);
            connection.addProcParameter("@namesuffix", SqlDbType.VarChar, NameSuffix);
            connection.addProcParameter("@contactno", SqlDbType.VarChar, ContactNumber);
            connection.addProcParameter("@email", SqlDbType.VarChar, Email);
            connection.addProcParameter("@institution", SqlDbType.VarChar, Institution);
            status = connection.executeProcedure();

            return status;
        }
    }
}
