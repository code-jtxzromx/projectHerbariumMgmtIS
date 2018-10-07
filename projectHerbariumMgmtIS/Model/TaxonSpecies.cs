using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace projectHerbariumMgmtIS.Model
{
    public class TaxonSpecies
    {
        // Properties
        public string SpeciesID { get; set; }
        public bool IsChecked { get; set; }
        public string FamilyName { get; set; }
        public string GenusName { get; set; }
        public string SpeciesName { get; set; }
        public string CommonName { get; set; }
        public string ScientificName { get; set; }
        public string SpeciesAuthor { get; set; }
        public bool IdentifiedStatus { get; set; }
        public int Specimens { get; set; }
        public int Copies { get; set; }

        // Constructor
        public TaxonSpecies()
        {
            this.SpeciesID = "";
            this.GenusName = "";
            this.SpeciesName = "";
            this.CommonName = "";
            this.SpeciesName = "";
            this.SpeciesAuthor = "";
            this.IdentifiedStatus = true;
        }

        // Methods
        public List<TaxonSpecies> GetSpecies()
        {
            List<TaxonSpecies> species = new List<TaxonSpecies>();
            DatabaseConnection connection = new DatabaseConnection();

            connection.setQuery("SELECT strSpeciesNo, strGenusName, strSpeciesName, strCommonName, strScientificName, " +
                                    "strAuthorsName, boolSpeciesIdentified " +
                                "FROM viewTaxonSpecies " +
                                "ORDER BY strScientificName");
            SqlDataReader sqlData = connection.executeResult();

            while (sqlData.Read())
            {
                species.Add(new TaxonSpecies()
                {
                    SpeciesID = sqlData[0].ToString(),
                    GenusName = sqlData[1].ToString(),
                    SpeciesName = sqlData[2].ToString(),
                    CommonName = sqlData[3].ToString(),
                    ScientificName = sqlData[4].ToString(),
                    SpeciesAuthor = sqlData[5].ToString(),
                    IdentifiedStatus = Convert.ToBoolean(sqlData[6])
                });
            }
            connection.closeResult();
            return species;
        }

        public List<TaxonSpecies> GetSpeciesWithCheck()
        {
            List<TaxonSpecies> species = new List<TaxonSpecies>();
            DatabaseConnection connection = new DatabaseConnection();

            connection.setQuery("SELECT SI.strFamilyName, SI.strGenusName, SI.strScientificName, " +
                                    "SI.intSpeciesCount - ISNULL(SL.intBorrowedCount, 0) " +
                                "FROM viewSpeciesInventory SI " +
                                    "LEFT JOIN viewSpeciesLoanCount SL ON SI.strScientificName = SL.strScientificName ");
            SqlDataReader sqlData = connection.executeResult();

            while (sqlData.Read())
            {
                species.Add(new TaxonSpecies()
                {
                    IsChecked = false,
                    FamilyName = sqlData[0].ToString(),
                    GenusName = sqlData[1].ToString(),
                    ScientificName = sqlData[2].ToString(),
                    Specimens = Convert.ToInt32(sqlData[3]),
                    Copies = 0
                });
            }
            connection.closeResult();
            return species;
        }

        public List<string> GetTaxonList()
        {
            List<string> species = new List<string>();
            DatabaseConnection connection = new DatabaseConnection();

            connection.setQuery("SELECT strScientificName FROM viewTaxonSpecies ORDER BY strScientificName");
            SqlDataReader sqlData = connection.executeResult();

            while (sqlData.Read())
            {
                species.Add(sqlData[0].ToString());
            }
            connection.closeResult();
            return species;
        }

        public int AddSpecies()
        {
            int status;
            DatabaseConnection connection = new DatabaseConnection();

            connection.setStoredProc("dbo.procInsertSpecies");
            connection.addProcParameter("@isIDBase", SqlDbType.Bit, 0);
            connection.addProcParameter("@genusName", SqlDbType.VarChar, GenusName);
            connection.addProcParameter("@speciesName", SqlDbType.VarChar, SpeciesName);
            connection.addProcParameter("@commonName", SqlDbType.VarChar, CommonName);
            connection.addProcParameter("@author", SqlDbType.VarChar, SpeciesAuthor);
            connection.addProcParameter("@isVerified", SqlDbType.Bit, IdentifiedStatus);
            status = connection.executeProcedure();

            return status;
        }

        public int EditSpecies()
        {
            int status;
            DatabaseConnection connection = new DatabaseConnection();

            connection.setStoredProc("dbo.procUpdateSpecies");
            connection.addProcParameter("@isIDBase", SqlDbType.Bit, 0);
            connection.addProcParameter("@speciesNo", SqlDbType.VarChar, SpeciesID);
            connection.addProcParameter("@genusName", SqlDbType.VarChar, GenusName);
            connection.addProcParameter("@speciesName", SqlDbType.VarChar, SpeciesName);
            connection.addProcParameter("@commonName", SqlDbType.VarChar, CommonName);
            connection.addProcParameter("@author", SqlDbType.VarChar, SpeciesAuthor);
            connection.addProcParameter("@isVerified", SqlDbType.Bit, IdentifiedStatus);
            status = connection.executeProcedure();

            return status;
        }

        public int LoanSpecies(string loannumber)
        {
            int status;
            DatabaseConnection connection = new DatabaseConnection();

            connection.setStoredProc("dbo.procLoanPlants");
            connection.addProcParameter("@loanNumber", SqlDbType.VarChar, loannumber);
            connection.addProcParameter("@taxonName", SqlDbType.VarChar, ScientificName);
            connection.addProcParameter("@copies", SqlDbType.Int, Copies);
            status = connection.executeProcedure();
            
            return status;
        }
    }
}
