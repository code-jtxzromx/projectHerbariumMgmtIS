using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectHerbariumMgmtIS.Model
{
    public class TaxonPhylum
    {
        // Properties
        public string PhylumID { get; set; }
        public string DomainName { get; set; }
        public string KingdomName { get; set; }
        public string PhylumName { get; set; }

        // Constructor
        public TaxonPhylum()
        {
            this.PhylumID = "";
            this.DomainName = "Eukaryota";
            this.KingdomName = "Plantae";
            this.PhylumName = "";
        }

        // Methods
        public List<TaxonPhylum> GetPhyla()
        {
            List<TaxonPhylum> phyla = new List<TaxonPhylum>();
            DatabaseConnection connection = new DatabaseConnection();

            connection.setQuery("SELECT strPhylumNo, strDomainName, strKingdomName, strPhylumName " +
                                "FROM viewTaxonPhylum " +
                                "ORDER BY strDomainName, strKingdomName, strPhylumName");
            SqlDataReader sqlData = connection.executeResult();

            while (sqlData.Read())
            {
                phyla.Add(new TaxonPhylum()
                {
                    PhylumID = sqlData[0].ToString(),
                    DomainName = sqlData[1].ToString(),
                    KingdomName = sqlData[2].ToString(),
                    PhylumName = sqlData[3].ToString()
                });
            }
            connection.closeResult();
            return phyla;
        }

        public List<string> GetVerifiedPhyla()
        {
            List<string> phyla = new List<string>();
            DatabaseConnection connection = new DatabaseConnection();

            connection.setQuery("SELECT DISTINCT strPhylumName FROM tblSpeciesData ORDER BY strPhylumName");
            SqlDataReader sqlData = connection.executeResult();

            while (sqlData.Read())
            {
                phyla.Add(sqlData[0].ToString());
            }
            connection.closeResult();
            return phyla;
        }

        public List<string> GetPhylumList()
        {
            List<string> phyla = new List<string>();
            DatabaseConnection connection = new DatabaseConnection();

            connection.setQuery("SELECT strPhylumName FROM tblPhylum ORDER BY strPhylumName");
            SqlDataReader sqlData = connection.executeResult();

            while (sqlData.Read())
            {
                phyla.Add(sqlData[0].ToString());
            }
            connection.closeResult();
            return phyla;
        }

        public int AddPhylum()
        {
            int status;
            DatabaseConnection connection = new DatabaseConnection();

            connection.setStoredProc("dbo.procInsertPhylum");
            connection.addProcParameter("@domainName", SqlDbType.VarChar, DomainName);
            connection.addProcParameter("@kingdomName", SqlDbType.VarChar, KingdomName);
            connection.addProcParameter("@phylumName", SqlDbType.VarChar, PhylumName);
            status = connection.executeProcedure();

            return status;
        }

        public int EditPhylum()
        {
            int status;
            DatabaseConnection connection = new DatabaseConnection();

            connection.setStoredProc("dbo.procUpdatePhylum");
            connection.addProcParameter("@phylumNo", SqlDbType.VarChar, PhylumID);
            connection.addProcParameter("@domainName", SqlDbType.VarChar, DomainName);
            connection.addProcParameter("@kingdomName", SqlDbType.VarChar, KingdomName);
            connection.addProcParameter("@phylumName", SqlDbType.VarChar, PhylumName);
            status = connection.executeProcedure();

            return status;
        }
    }
}
