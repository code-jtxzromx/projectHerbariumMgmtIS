using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectHerbariumMgmtIS.Model
{
    public class Staff
    {
        // Properties
        public int StaffID { get; set; }
        public string FullName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string MiddleInitial { get; set; }
        public string NameSuffix { get; set; }
        public string ContactNumber { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string College { get; set; }

        // Constructor
        public Staff()
        {
            this.StaffID = 0;
            this.FullName = "";
            this.FirstName = "";
            this.MiddleName = "";
            this.LastName = "";
            this.MiddleInitial = "";
            this.NameSuffix = "";
            this.ContactNumber = "";
            this.Email = "";
            this.Role = "";
            this.College = "";
        }

        // Methods
        public List<Staff> GetStaffs()
        {
            List<Staff> staffs = new List<Staff>();
            DatabaseConnection connection = new DatabaseConnection();

            connection.setQuery("SELECT intStaffID, strFirstname, strMiddlename, strLastname, strMiddleInitial, strNameSuffix, " +
                                        "strContactNumber, strEmailAddress, strFullName, strRole, strCollegeDepartment " +
                                "FROM viewHerbariumStaff " +
                                "ORDER BY strLastname, strFirstname");
            SqlDataReader sqlData = connection.executeResult();
            
            while (sqlData.Read())
            {
                staffs.Add(new Staff()
                {
                    StaffID = Convert.ToInt32(sqlData[0]),
                    FirstName = sqlData[1].ToString(),
                    MiddleName = sqlData[2].ToString(),
                    LastName = sqlData[3].ToString(),
                    MiddleInitial = sqlData[4].ToString(),
                    NameSuffix = sqlData[5].ToString(),
                    ContactNumber = sqlData[6].ToString(),
                    Email = sqlData[7].ToString(),
                    FullName = sqlData[8].ToString(),
                    Role = sqlData[9].ToString(),
                    College = sqlData[10].ToString()
                });
            }
            connection.closeResult();
            return staffs;
        }

        public List<string> GetStaffList()
        {
            List<string> Borrowers = new List<string>();
            DatabaseConnection connection = new DatabaseConnection();

            connection.setQuery("SELECT strFullName FROM viewHerbariumStaff ORDER BY strFullName");
            SqlDataReader sqlData = connection.executeResult();

            while (sqlData.Read())
            {
                Borrowers.Add(sqlData[0].ToString());
            }
            connection.closeResult();
            return Borrowers;
        }

        public int AddStaff()
        {
            int status;
            DatabaseConnection connection = new DatabaseConnection();

            connection.setStoredProc("dbo.procInsertHerbariumStaff");
            connection.addProcParameter("@firstname", System.Data.SqlDbType.VarChar, FirstName);
            connection.addProcParameter("@middlename", System.Data.SqlDbType.VarChar, MiddleName);
            connection.addProcParameter("@lastname", System.Data.SqlDbType.VarChar, LastName);
            connection.addProcParameter("@middleinitial", System.Data.SqlDbType.VarChar, MiddleInitial);
            connection.addProcParameter("@namesuffix", System.Data.SqlDbType.VarChar, NameSuffix);
            connection.addProcParameter("@contactno", System.Data.SqlDbType.VarChar, ContactNumber);
            connection.addProcParameter("@email", System.Data.SqlDbType.VarChar, Email);
            connection.addProcParameter("@role", System.Data.SqlDbType.VarChar, Role);
            connection.addProcParameter("@department", System.Data.SqlDbType.VarChar, College);
            status = connection.executeProcedure();

            return status;
        }

        public int EditStaff()
        {
            int status;
            DatabaseConnection connection = new DatabaseConnection();

            connection.setStoredProc("dbo.procUpdateHerbariumStaff");
            connection.addProcParameter("@staffID", System.Data.SqlDbType.Int, StaffID);
            connection.addProcParameter("@firstname", System.Data.SqlDbType.VarChar, FirstName);
            connection.addProcParameter("@middlename", System.Data.SqlDbType.VarChar, MiddleName);
            connection.addProcParameter("@lastname", System.Data.SqlDbType.VarChar, LastName);
            connection.addProcParameter("@middleinitial", System.Data.SqlDbType.VarChar, MiddleInitial);
            connection.addProcParameter("@namesuffix", System.Data.SqlDbType.VarChar, NameSuffix);
            connection.addProcParameter("@contactno", System.Data.SqlDbType.VarChar, ContactNumber);
            connection.addProcParameter("@email", System.Data.SqlDbType.VarChar, Email);
            connection.addProcParameter("@role", System.Data.SqlDbType.VarChar, Role);
            connection.addProcParameter("@department", System.Data.SqlDbType.VarChar, College);
            status = connection.executeProcedure();

            return status;
        }
    }
}
