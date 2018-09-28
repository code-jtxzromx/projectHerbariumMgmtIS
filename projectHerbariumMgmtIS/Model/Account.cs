using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectHerbariumMgmtIS.Model
{
    public class Account
    {
        // Properties
        public int AccountID { get; set; }
        public string Staff { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        // Constructor
        public Account()
        {
            this.AccountID = 0;
            this.Staff = "";
            this.Username = "";
            this.Password = "";
            this.Role = "";
        }

        // Methods
        public List<Account> GetAccounts()
        {
            List<Account> accounts = new List<Account>();
            DatabaseConnection connection = new DatabaseConnection();
            
            connection.setQuery("SELECT intStaffID, strFullName, strUsername, strPassword, strRole " +
                                "FROM viewAccounts " +
                                "ORDER BY strFullName, strUsername, strPassword");
            SqlDataReader sqlData = connection.executeResult();

            while (sqlData.Read())
            {
                accounts.Add(new Account()
                {
                    AccountID = Convert.ToInt32(sqlData[0]),
                    Staff = sqlData[1].ToString(),
                    Username = sqlData[2].ToString(),
                    Password = sqlData[3].ToString(),
                    Role = sqlData[4].ToString()
                });
            }
            connection.closeResult();
            return accounts;
        }

        public int AddAccount()
        {
            int status;
            DatabaseConnection connection = new DatabaseConnection();

            connection.setStoredProc("dbo.procInsertAccount");
            connection.addProcParameter("@isIDBase", SqlDbType.Bit, 0);
            connection.addProcParameter("@staffName", SqlDbType.VarChar, Staff);
            connection.addProcParameter("@username", SqlDbType.VarChar, Username);
            connection.addProcParameter("@password", SqlDbType.VarChar, Password);
            status = connection.executeProcedure();

            return status;
        }

        public int EditAccount()
        {
            int status;
            DatabaseConnection connection = new DatabaseConnection();

            connection.setStoredProc("dbo.procUpdateAccount");
            connection.addProcParameter("@isIDBase", SqlDbType.Bit, 0);
            connection.addProcParameter("@staffID", SqlDbType.Int, AccountID);
            connection.addProcParameter("@username", SqlDbType.VarChar, Username);
            connection.addProcParameter("@password", SqlDbType.VarChar, Password);
            status = connection.executeProcedure();

            return status;
        }
    }
}
