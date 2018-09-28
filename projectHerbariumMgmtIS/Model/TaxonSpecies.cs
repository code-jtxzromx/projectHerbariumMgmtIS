using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectHerbariumMgmtIS.Model
{
    public class TaxonSpecies
    {
        // Properties
        public string SpeciesID { get; set; }
        public string GenusName { get; set; }
        public string SpeciesName { get; set; }
        public string CommonName { get; set; }
        public string ScientificName { get; set; }
        public string SpeciesAuthor { get; set; }
        public bool IdentifiedStatus { get; set; }

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
    }
}
