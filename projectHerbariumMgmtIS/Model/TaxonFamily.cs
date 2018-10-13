using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectHerbariumMgmtIS.Model
{
    public class TaxonFamily
    {
        // Properties
        public string FamilyID { get; set; }
        public bool IsChecked { get; set; }
        public string OrderName { get; set; }
        public string FamilyName { get; set; }

        // Constructor
        public TaxonFamily()
        {
            this.FamilyID = "";
            this.OrderName = "";
            this.FamilyName = "";
        }

        // Methods
        public List<TaxonFamily> GetFamilies()
        {
            List<TaxonFamily> families = new List<TaxonFamily>();
            DatabaseConnection connection = new DatabaseConnection();

            connection.setQuery("SELECT strFamilyNo, strOrderName, strFamilyName " +
                                "FROM viewTaxonFamily " +
                                "ORDER BY strOrderName, strFamilyName");
            SqlDataReader sqlData = connection.executeResult();

            while (sqlData.Read())
            {
                families.Add(new TaxonFamily()
                {
                    FamilyID = sqlData[0].ToString(),
                    OrderName = sqlData[1].ToString(),
                    FamilyName = sqlData[2].ToString()
                });
            }
            connection.closeResult();
            return families;
        }

        public List<TaxonFamily> GetLoanAvailableFamilies()
        {
            List<TaxonFamily> families = new List<TaxonFamily>();
            DatabaseConnection connection = new DatabaseConnection();

            connection.setQuery("SELECT DISTINCT SI.strFamilyName, " +
                                    "SI.intSpeciesCount - ISNULL(SL.intBorrowedCount, 0) " +
                                "FROM viewSpeciesInventory SI " +
                                    "LEFT JOIN viewSpeciesLoanCount SL ON SI.strScientificName = SL.strScientificName " +
                                "WHERE SI.intSpeciesCount - ISNULL(SL.intBorrowedCount, 0) > 0");
            SqlDataReader sqlData = connection.executeResult();

            while (sqlData.Read())
            {
                families.Add(new TaxonFamily()
                {
                    IsChecked = false,
                    FamilyName = sqlData[0].ToString()
                });
            }
            connection.closeResult();
            return families;
        }

        public bool CanProcessLoan()
        {
            bool status;
            DatabaseConnection connection = new DatabaseConnection();

            connection.setQuery("SELECT DISTINCT SI.strFamilyName, " +
                                    "SI.intSpeciesCount - ISNULL(SL.intBorrowedCount, 0) " +
                                "FROM viewSpeciesInventory SI " +
                                    "LEFT JOIN viewSpeciesLoanCount SL ON SI.strScientificName = SL.strScientificName " +
                                "WHERE SI.intSpeciesCount - ISNULL(SL.intBorrowedCount, 0) > 0");
            SqlDataReader sqlData = connection.executeResult();
            status = sqlData.HasRows;

            connection.closeResult();
            return status;
        }

        public List<string> GetFamilyList()
        {
            List<string> families = new List<string>();
            DatabaseConnection connection = new DatabaseConnection();

            connection.setQuery("SELECT strFamilyName FROM tblFamily ORDER BY strFamilyName");
            SqlDataReader sqlData = connection.executeResult();

            while (sqlData.Read())
            {
                families.Add(sqlData[0].ToString());
            }
            connection.closeResult();
            return families;
        }

        public int AddFamily()
        {
            int status;
            DatabaseConnection connection = new DatabaseConnection();

            connection.setStoredProc("dbo.procInsertFamily");
            connection.addProcParameter("@isIDBase", SqlDbType.Bit, 0);
            connection.addProcParameter("@orderName", SqlDbType.VarChar, OrderName);
            connection.addProcParameter("@familyName", SqlDbType.VarChar, FamilyName);
            status = connection.executeProcedure();

            return status;
        }

        public int EditFamily()
        {
            int status;
            DatabaseConnection connection = new DatabaseConnection();

            connection.setStoredProc("dbo.procUpdateFamily");
            connection.addProcParameter("@isIDBase", SqlDbType.Bit, 0);
            connection.addProcParameter("@familyNo", SqlDbType.VarChar, FamilyID);
            connection.addProcParameter("@orderName", SqlDbType.VarChar, OrderName);
            connection.addProcParameter("@familyName", SqlDbType.VarChar, FamilyName);
            status = connection.executeProcedure();

            return status;
        }
    }
}
