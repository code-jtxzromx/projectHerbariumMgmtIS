using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectHerbariumMgmtIS.Model
{
    public static class StaticAccess
    {
        // Properties
        public static int ID { get; set; } = 0;
        public static string StaffName { get; set; } = "";
        public static string Role { get; set; } = "";

        // Methods
        public static int LogIn(string username, string password)
        {
            int status;

            if (CheckAccounts())
            {
                DatabaseConnection connection = new DatabaseConnection();
                connection.setQuery("SELECT intStaffID, strFullName, strRole " +
                                    "FROM viewAccounts " +
                                    "WHERE strUsername = @username AND strPassword = @password");
                connection.addQueryParameter("@username", System.Data.SqlDbType.VarChar, username);
                connection.addQueryParameter("@password", System.Data.SqlDbType.VarChar, password);

                SqlDataReader sqlData = connection.executeResult();
                if (sqlData.HasRows)
                {
                    while (sqlData.Read())
                    {
                        ID = Convert.ToInt32(sqlData[0]);
                        StaffName = sqlData[1].ToString();
                        Role = sqlData[2].ToString();
                    }
                    status = 0;
                }
                else
                    status = 1;
            }
            else
            {
                if (username == "admin" && password == "admin")
                {
                    ID = 0;
                    StaffName = "Temporary Admin";
                    Role = "ADMINISTRATOR";

                    status = 0;
                }
                else
                    status = 1;
            }

            return status;
        }

        public static bool CheckAccounts()
        {
            bool hasRecords;
            DatabaseConnection connection = new DatabaseConnection();

            connection.setQuery("SELECT intStaffID FROM tblAccounts");

            SqlDataReader sqlData = connection.executeResult();
            hasRecords = (sqlData.HasRows);

            connection.closeResult();
            return hasRecords;
        }
    }
}
