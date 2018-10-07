using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Media.Imaging;

namespace projectHerbariumMgmtIS.Model
{
    public class HerbariumSheet
    {
        // Properties
        public string AccessionNumber { get; set; }
        public string ReferenceNumber { get; set; }
        public string FamilyName { get; set; }
        public string ScientificName { get; set; }
        public string TaxonNomenclature { get; set; }
        public string DateCollected { get; set; }
        public string DateDeposited { get; set; }
        public string DateValidated { get; set; }
        public string Locality { get; set; }
        public string Collector { get; set; }
        public string Validator { get; set; }
        public string Description { get; set; }
        public string LoanAvailability { get; set; }
        public bool IsAvailable { get; set; }
        public string Status { get; set; }
        public string BoxLocation { get; set; }
        public string Account { get; set; }

        // Constructor
        public HerbariumSheet()
        {
            this.AccessionNumber = "";
            this.ReferenceNumber = "";
            this.ScientificName = "";
            this.TaxonNomenclature = "";
            this.DateCollected = "";
            this.DateDeposited = "";
            this.DateValidated = "";
            this.Locality = "";
            this.Collector = "";
            this.Validator = "";
            this.Description = "";
            this.IsAvailable = false;
            this.LoanAvailability = "";
            this.Status = "";
            this.BoxLocation = "";
            this.Account = "";
        }

        // Methods
        public List<HerbariumSheet> GetUnclassifiedSheets()
        {
            List<HerbariumSheet> herbariumSheets = new List<HerbariumSheet>();
            DatabaseConnection connection = new DatabaseConnection();

            connection.setQuery("SELECT strAccessionNumber, strReferenceAccession, strFamilyName, " +
                                    "strScientificName, strFullNomenclature, CONVERT(VARCHAR, dateCollected, 107), " +
                                    "CONVERT(VARCHAR, dateDeposited, 107), CONVERT(VARCHAR, dateVerified, 107), " +
                                    "strFullLocality, strCollector, strValidator, strDescription " +
                                "FROM viewHerbariumSheet " +
                                "WHERE strStatus = 'Verified'");

            SqlDataReader sqlData = connection.executeResult();
            while (sqlData.Read())
            {
                herbariumSheets.Add(new HerbariumSheet()
                {
                    AccessionNumber = sqlData[0].ToString(),
                    ReferenceNumber = sqlData[1].ToString(),
                    FamilyName = sqlData[2].ToString(),
                    ScientificName = sqlData[3].ToString(),
                    TaxonNomenclature = sqlData[4].ToString().Replace(';', '\n'),
                    DateCollected = sqlData[5].ToString(),
                    DateDeposited = sqlData[6].ToString(),
                    DateValidated = sqlData[7].ToString(),
                    Locality = sqlData[8].ToString(),
                    Collector = sqlData[9].ToString(),
                    Validator = sqlData[10].ToString(),
                    Description = sqlData[11].ToString()
                });
            }
            connection.closeResult();
            return herbariumSheets;
        }

        public List<HerbariumSheet> GetHerbariumInventory()
        {
            List<HerbariumSheet> herbariumSheets = new List<HerbariumSheet>();
            DatabaseConnection connection = new DatabaseConnection();

            connection.setQuery("SELECT strAccessionNumber, strReferenceAccession, strBoxNumber, strFamilyName, strScientificName, " +
                                   "strFullNomenclature, CONVERT(VARCHAR, dateCollected, 107), CONVERT(VARCHAR, dateDeposited, 107), " +
                                   "CONVERT(VARCHAR, dateVerified, 107), strFullLocality, " +
                                   "strCollector, strValidator, strDescription, boolLoanAvailable, strStatus " +
                                   "FROM viewHerbariumInventory");

            SqlDataReader sqlData = connection.executeResult();
            while (sqlData.Read())
            {
                herbariumSheets.Add(new HerbariumSheet()
                {
                    AccessionNumber = sqlData[0].ToString(),
                    ReferenceNumber = sqlData[1].ToString(),
                    BoxLocation = sqlData[2].ToString(),
                    FamilyName = sqlData[3].ToString(),
                    ScientificName = sqlData[4].ToString(),
                    TaxonNomenclature = sqlData[5].ToString().Replace(';', '\n'),
                    DateCollected = sqlData[6].ToString(),
                    DateDeposited = sqlData[7].ToString(),
                    DateValidated = sqlData[8].ToString(),
                    Locality = sqlData[9].ToString(),
                    Collector = sqlData[10].ToString(),
                    Validator = sqlData[11].ToString(),
                    Description = sqlData[12].ToString(),
                    LoanAvailability = Convert.ToBoolean(sqlData[13]) ? "Available" : "Not Available",
                    Status = sqlData[14].ToString()
                });
            }
            connection.closeResult();
            return herbariumSheets;
        }
        
        public int ClassifyHerbariumSheet(string boxnumber)
        {
            int status;
            DatabaseConnection connection = new DatabaseConnection();
            connection.setStoredProc("dbo.procStoreHerbariumSheet");
            connection.addProcParameter("@accessionNumber", SqlDbType.VarChar, AccessionNumber);
            connection.addProcParameter("@boxNumber", SqlDbType.VarChar, boxnumber);
            connection.addProcParameter("@loanAvailable", SqlDbType.Bit, IsAvailable);
            status = connection.executeProcedure();
            
            return status;
        }

        public int UpdateHerbariumSheet()
        {
            int status;
            DatabaseConnection connection = new DatabaseConnection();
            connection.setStoredProc("dbo.procUpdateHerbariumSheet");
            connection.addProcParameter("@isIDBase", SqlDbType.Bit, 0);
            connection.addProcParameter("@accessionNumber", SqlDbType.VarChar, AccessionNumber);
            connection.addProcParameter("@boxNumber", SqlDbType.VarChar, BoxLocation);
            connection.addProcParameter("@description", SqlDbType.VarChar, Description);
            connection.addProcParameter("@loanAvailability", SqlDbType.Bit, IsAvailable);
            status = connection.executeProcedure();

            return status;
        }

        public int InsertHerbariumImage(string tag, BitmapImage image)
        {
            return 0;
        }

        public int DeleteHerbariumImage(string tag)
        {
            return 0;
        }
    }
}
