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
        public string DomainName { get; set; }
        public string KingdomName { get; set; }
        public string PhylumName { get; set; }
        public string ClassName { get; set; }
        public string OrderName { get; set; }
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

        public List<TaxonSpecies> GetLoanedSpecies(string loanNumber)
        {
            List<TaxonSpecies> species = new List<TaxonSpecies>();
            DatabaseConnection connection = new DatabaseConnection();

            connection.setQuery("SELECT strFamilyName, strScientificName, intCopies " +
                                "FROM viewLoanedSpecies " +
                                "WHERE strLoanNumber = @loanNumber " +
                                "ORDER BY strFamilyName, strScientificName ASC");
            connection.addQueryParameter("@loanNumber", SqlDbType.VarChar, loanNumber);
            SqlDataReader sqlData = connection.executeResult();

            while (sqlData.Read())
            {
                species.Add(new TaxonSpecies()
                {
                    FamilyName = sqlData[0].ToString(),
                    ScientificName = sqlData[1].ToString(),
                    Copies = Convert.ToInt32(sqlData[2])
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

        public List<TaxonSpecies> GetSpeciesQuery()
        {
            List<TaxonSpecies> species = new List<TaxonSpecies>();
            DatabaseConnection connection = new DatabaseConnection();

            connection.setQuery("SELECT TS.strSpeciesNo, TS.strDomainName, TS.strKingdomName, TS.strPhylumName, TS.strClassName, TS.strOrderName, " +
                                       "TS.strFamilyName, TS.strGenusName, TS.strSpeciesName, TS.strScientificName, TS.strCommonName, " +
                                       "TS.strAuthorsName, TS.boolSpeciesIdentified, COUNT(HS.intHerbariumSheetID) as intSpecimenCount " +
                                "FROM viewTaxonSpecies TS " +
                                    "LEFT JOIN viewHerbariumSheet HS ON TS.strScientificName = HS.strScientificName " +
                                "GROUP BY TS.strSpeciesNo, TS.strDomainName, TS.strKingdomName, TS.strPhylumName, TS.strClassName, TS.strOrderName, " +
                                         "TS.strFamilyName, TS.strGenusName, TS.strSpeciesName, TS.strScientificName, TS.strCommonName, " +
                                         "TS.strAuthorsName, TS.boolSpeciesIdentified");
            SqlDataReader sqlData = connection.executeResult();

            while (sqlData.Read())
            {
                species.Add(new TaxonSpecies()
                {
                    SpeciesID = sqlData[0].ToString(),
                    DomainName = sqlData[1].ToString(),
                    KingdomName = sqlData[2].ToString(),
                    PhylumName = sqlData[3].ToString(),
                    ClassName = sqlData[4].ToString(),
                    OrderName = sqlData[5].ToString(),
                    FamilyName = sqlData[6].ToString(),
                    GenusName = sqlData[7].ToString(),
                    SpeciesName = sqlData[8].ToString(),
                    ScientificName = sqlData[9].ToString(),
                    CommonName = sqlData[10].ToString(),
                    SpeciesAuthor = sqlData[11].ToString(),
                    IdentifiedStatus = Convert.ToBoolean(sqlData[12]),
                    Specimens = Convert.ToInt32(sqlData[13])
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
