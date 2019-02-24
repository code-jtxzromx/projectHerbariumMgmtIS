using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectHerbariumMgmtIS.Model
{
    public class ItemListView
    {
        public string Title { get; set; }
        public int Count { get; set; }

        public int CountHerbariumSheets()
        {
            int count = 0;
            DatabaseConnection connection = new DatabaseConnection();

            connection.setQuery("SELECT COUNT(intPlantDepositID) FROM tblPlantDeposit");
            SqlDataReader sqlData = connection.executeResult();

            while (sqlData.Read())
            {
                count = Convert.ToInt32(sqlData[0]);
            }
            connection.closeResult();
            return count;
        }

        public int CountVerifiedSpecies()
        {
            int count = 0;
            DatabaseConnection connection = new DatabaseConnection();

            connection.setQuery("SELECT COUNT(intSpeciesID) FROM viewTaxonSpecies WHERE boolSpeciesIdentified = 1");
            SqlDataReader sqlData = connection.executeResult();

            while (sqlData.Read())
            {
                count = Convert.ToInt32(sqlData[0]);
            }
            connection.closeResult();
            return count;
        }

        public int CountFamilyBox()
        {
            int count = 0;
            DatabaseConnection connection = new DatabaseConnection();

            connection.setQuery("SELECT COUNT(intBoxID) FROM viewFamilyBox");
            SqlDataReader sqlData = connection.executeResult();

            while (sqlData.Read())
            {
                count = Convert.ToInt32(sqlData[0]);
            }
            connection.closeResult();
            return count;
        }

        public int CountLoanAvailable()
        {
            int count = 0;
            DatabaseConnection connection = new DatabaseConnection();

            connection.setQuery("SELECT COUNT(intStoredSheetID) FROM viewHerbariumInventory WHERE boolLoanAvailable = 1");
            SqlDataReader sqlData = connection.executeResult();

            while (sqlData.Read())
            {
                count = Convert.ToInt32(sqlData[0]);
            }
            connection.closeResult();
            return count;
        }

        public int CountNewDeposit()
        {
            int count = 0;
            DatabaseConnection connection = new DatabaseConnection();

            connection.setQuery("SELECT COUNT(intDepositID) FROM tblReceivedDeposits WHERE strStatus = 'New Deposit'");
            SqlDataReader sqlData = connection.executeResult();

            while (sqlData.Read())
            {
                count = Convert.ToInt32(sqlData[0]);
            }
            connection.closeResult();
            return count;
        }

        public int CountRejectedDeposit()
        {
            int count = 0;
            DatabaseConnection connection = new DatabaseConnection();

            connection.setQuery("SELECT COUNT(intDepositID) FROM tblReceivedDeposits WHERE strStatus = 'Rejected'");
            SqlDataReader sqlData = connection.executeResult();

            while (sqlData.Read())
            {
                count = Convert.ToInt32(sqlData[0]);
            }
            connection.closeResult();
            return count;
        }
    }
}
