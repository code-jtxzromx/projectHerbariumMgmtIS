using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectHerbariumMgmtIS.Model
{
    public class TaxonGenus
    {
        // Properties
        public string GenusID { get; set; }
        public bool IsChecked { get; set; }
        public string FamilyName { get; set; }
        public string GenusName { get; set; }

        // Constructor
        public TaxonGenus()
        {
            this.GenusID = "";
            this.FamilyName = "";
            this.GenusName = "";
        }

        // Methods
        public List<TaxonGenus> GetGenera()
        {
            List<TaxonGenus> genera = new List<TaxonGenus>();
            DatabaseConnection connection = new DatabaseConnection();
            
            connection.setQuery("SELECT strGenusNo, strFamilyName, strGenusName " +
                                "FROM viewTaxonGenus " +
                                "ORDER BY strFamilyName, strGenusName");
            SqlDataReader sqlData = connection.executeResult();

            while (sqlData.Read())
            {
                genera.Add(new TaxonGenus()
                {
                    GenusID = sqlData[0].ToString(),
                    IsChecked = false,
                    FamilyName = sqlData[1].ToString(),
                    GenusName = sqlData[2].ToString()
                });
            }
            connection.closeResult();
            return genera;
        }

        public List<TaxonGenus> GetLoanAvailableGenera()
        {
            List<TaxonGenus> genera = new List<TaxonGenus>();
            DatabaseConnection connection = new DatabaseConnection();

            connection.setQuery("SELECT DISTINCT SI.strFamilyName, SI.strGenusName, " +
                                    "SI.intSpeciesCount - ISNULL(SL.intBorrowedCount, 0) " +
                                "FROM viewSpeciesInventory SI " +
                                    "LEFT JOIN viewSpeciesLoanCount SL ON SI.strScientificName = SL.strScientificName " +
                                "WHERE SI.intSpeciesCount - ISNULL(SL.intBorrowedCount, 0) > 0");
            SqlDataReader sqlData = connection.executeResult();

            while (sqlData.Read())
            {
                genera.Add(new TaxonGenus()
                {
                    IsChecked = false,
                    FamilyName = sqlData[0].ToString(),
                    GenusName = sqlData[1].ToString()
                });
            }
            connection.closeResult();
            return genera;
        }

        public List<string> GetVerifiedGenera()
        {
            List<string> genera = new List<string>();
            DatabaseConnection connection = new DatabaseConnection();

            connection.setQuery("SELECT DISTINCT strGenusName FROM tblSpeciesData ORDER BY strGenusName");
            SqlDataReader sqlData = connection.executeResult();

            while (sqlData.Read())
            {
                genera.Add(sqlData[0].ToString());
            }
            connection.closeResult();
            return genera;
        }

        public List<string> GetGenusList()
        {
            List<string> genera = new List<string>();
            DatabaseConnection connection = new DatabaseConnection();

            connection.setQuery("SELECT strGenusName FROM tblGenus ORDER BY strGenusName");
            SqlDataReader sqlData = connection.executeResult();

            while (sqlData.Read())
            {
                genera.Add(sqlData[0].ToString());
            }
            connection.closeResult();
            return genera;
        }

        public int AddGenus()
        {
            int status;
            DatabaseConnection connection = new DatabaseConnection();

            connection.setStoredProc("dbo.procInsertGenus");
            connection.addProcParameter("@isIDBase", SqlDbType.Bit, 0);
            connection.addProcParameter("@familyName", SqlDbType.VarChar, FamilyName);
            connection.addProcParameter("@genusName", SqlDbType.VarChar, GenusName);
            status = connection.executeProcedure();

            return status;
        }

        public int EditGenus()
        {
            int status;
            DatabaseConnection connection = new DatabaseConnection();

            connection.setStoredProc("dbo.procUpdateGenus");
            connection.addProcParameter("@isIDBase", SqlDbType.Bit, 0);
            connection.addProcParameter("@genusNo", SqlDbType.VarChar, GenusID);
            connection.addProcParameter("@familyName", SqlDbType.VarChar, FamilyName);
            connection.addProcParameter("@genusName", SqlDbType.VarChar, GenusName);
            status = connection.executeProcedure();

            return status;
        }
    }
}
