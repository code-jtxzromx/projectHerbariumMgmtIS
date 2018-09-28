using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectHerbariumMgmtIS.Model
{
    public class SpeciesNomenclature
    {
        // Properties
        public int AltNameID { get; set; }
        public string TaxonName { get; set; }
        public string Language { get; set; }
        public string AlternateName { get; set; }

        // Constructor
        public SpeciesNomenclature()
        {
            this.AltNameID = 0;
            this.TaxonName = "";
            this.Language = "";
            this.AlternateName = "";
        }

        // Methods
        public List<SpeciesNomenclature> GetSpeciesNomenclatures()
        {
            List<SpeciesNomenclature> alternates = new List<SpeciesNomenclature>();
            DatabaseConnection connection = new DatabaseConnection();
            
            connection.setQuery("SELECT intAltNameID, strScientificName, strLanguage, strAlternateName " +
                                "FROM viewSpeciesAlternate " +
                                "ORDER BY strScientificName, strLanguage");
            SqlDataReader sqlData = connection.executeResult();

            while (sqlData.Read())
            {
                alternates.Add(new SpeciesNomenclature()
                {
                    AltNameID = Convert.ToInt32(sqlData[0]),
                    TaxonName = sqlData[1].ToString(),
                    Language = sqlData[2].ToString(),
                    AlternateName = sqlData[3].ToString()
                });
            }
            connection.closeResult();
            return alternates;
        }

        public int AddNomenclature()
        {
            int status;
            DatabaseConnection connection = new DatabaseConnection();

            connection.setStoredProc("dbo.procInsertSpeciesNomenclature");
            connection.addProcParameter("@isIDBase", SqlDbType.Bit, 0);
            connection.addProcParameter("@taxonName", SqlDbType.VarChar, TaxonName);
            connection.addProcParameter("@language", SqlDbType.VarChar, Language);
            connection.addProcParameter("@alternateName", SqlDbType.VarChar, AlternateName);
            status = connection.executeProcedure();

            return status;
        }

        public int EditNomenclature()
        {
            int status;
            DatabaseConnection connection = new DatabaseConnection();

            connection.setStoredProc("dbo.procUpdateSpeciesNomenclature");
            connection.addProcParameter("@isIDBase", SqlDbType.Bit, 0);
            connection.addProcParameter("@altNameID", SqlDbType.VarChar, AltNameID);
            connection.addProcParameter("@taxonName", SqlDbType.VarChar, TaxonName);
            connection.addProcParameter("@language", SqlDbType.VarChar, Language);
            connection.addProcParameter("@alternateName", SqlDbType.VarChar, AlternateName);
            status = connection.executeProcedure();

            return status;
        }
    }
}
