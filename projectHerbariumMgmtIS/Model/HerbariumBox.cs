using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectHerbariumMgmtIS.Model
{
    public class HerbariumBox
    {
        // Properties
        public string BoxNumber { get; set; }
        public string Family { get; set; }
        public int BoxLimit { get; set; }
        public int CurrentNo { get; set; }
        public string Location { get; set; }
        public int RackNumber { get; set; }
        public int RackRow { get; set; }
        public int RackColumn { get; set; }
        public string Status { get; set; }

        // Constructor
        public HerbariumBox()
        {
            this.BoxNumber = "";
            this.Family = "";
            this.BoxLimit = 10;
            this.CurrentNo = 0;
            this.Location = "";
            this.RackNumber = 1;
            this.RackRow = 1;
            this.RackColumn = 1;
            this.Status = "";
        }

        // Methods
        public List<HerbariumBox> GetHerbariumBoxes()
        {
            List<HerbariumBox> familyBoxes = new List<HerbariumBox>();
            DatabaseConnection connection = new DatabaseConnection();

            connection.setQuery("SELECT FB.strBoxNumber, FB.strFamilyName, FB.intBoxLimit, FB.intRackNo, FB.intRackRow, FB.intRackColumn, COUNT(HI.intStoredSheetID)  " +
                                "FROM viewFamilyBox FB LEFT JOIN viewHerbariumInventory HI ON FB.strBoxNumber = HI.strBoxNumber " +
                                "GROUP BY FB.strBoxNumber, FB.strFamilyName, FB.intBoxLimit, FB.intRackNo, FB.intRackRow, FB.intRackColumn " +
                                "ORDER BY FB.strBoxNumber");
            SqlDataReader sqlData = connection.executeResult();

            while (sqlData.Read())
            {
                familyBoxes.Add(new HerbariumBox()
                {
                    BoxNumber = sqlData[0].ToString(),
                    Family = sqlData[1].ToString(),
                    BoxLimit = Convert.ToInt32(sqlData[2]),
                    RackNumber = Convert.ToInt32(sqlData[3]),
                    RackRow = Convert.ToInt32(sqlData[4]),
                    RackColumn = Convert.ToInt32(sqlData[5]),
                    Location = "Rack #" + sqlData[3].ToString() + " (R:" + sqlData[4].ToString() + ", C:" + sqlData[5].ToString() + ")",
                    Status = (Convert.ToInt32(sqlData[2]) == Convert.ToInt32(sqlData[6]) ? "Full" : "Available")
                });
            }
            connection.closeResult();
            return familyBoxes;
        }

        public List<HerbariumBox> GetAvailableBoxes()
        {
            List<HerbariumBox> familyBoxes = new List<HerbariumBox>();
            DatabaseConnection connection = new DatabaseConnection();

            connection.setQuery("SELECT strBoxNumber, strFamilyName, intBoxLimit, intCurrentNo FROM viewFamilyBox");
            SqlDataReader sqlData = connection.executeResult();

            while (sqlData.Read())
            {
                familyBoxes.Add(new HerbariumBox()
                {
                    BoxNumber = sqlData[0].ToString(),
                    Family = sqlData[1].ToString(),
                    BoxLimit = Convert.ToInt32(sqlData[2]),
                    CurrentNo = Convert.ToInt32(sqlData[3])
                });
            }
            connection.closeResult();
            return familyBoxes;
        }
        
        public int AddHerbariumBox()
        {
            int status;
            DatabaseConnection connection = new DatabaseConnection();

            connection.setStoredProc("dbo.procInsertFamilyBox");
            connection.addProcParameter("@isIDBase", SqlDbType.Bit, 0);
            connection.addProcParameter("@familyName", SqlDbType.VarChar, Family);
            connection.addProcParameter("@boxLimit", SqlDbType.Int, BoxLimit);
            connection.addProcParameter("@rack", SqlDbType.Int, RackNumber);
            connection.addProcParameter("@row", SqlDbType.Int, RackRow);
            connection.addProcParameter("@column", SqlDbType.Int, RackColumn);
            status = connection.executeProcedure();

            return status;
        }

        public int EditHerbariumBox()
        {
            int status;
            DatabaseConnection connection = new DatabaseConnection();

            connection.setStoredProc("dbo.procUpdateFamilyBox");
            connection.addProcParameter("@isIDBase", SqlDbType.Bit, 0);
            connection.addProcParameter("@boxNumber", SqlDbType.VarChar, BoxNumber);
            connection.addProcParameter("@familyName", SqlDbType.VarChar, Family);
            connection.addProcParameter("@boxLimit", SqlDbType.Int, BoxLimit);
            connection.addProcParameter("@rack", SqlDbType.Int, RackNumber);
            connection.addProcParameter("@row", SqlDbType.Int, RackRow);
            connection.addProcParameter("@column", SqlDbType.Int, RackColumn);
            status = connection.executeProcedure();

            return status;
        }
    }
}
