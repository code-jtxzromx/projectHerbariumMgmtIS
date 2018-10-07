using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

namespace projectHerbariumMgmtIS.Model
{
    public class PlantDeposit
    {
        // Properties
        public string AccessionNumber { get; set; }
        public string DepositNumber { get; set; }
        public string PlantType { get; set; }
        public string Collector { get; set; }
        public string Locality { get; set; }
        public string Staff { get; set; }
        public DateTimeOffset DateCollected { get; set; }
        public DateTimeOffset DateDeposited { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }

        public string TaxonName { get; set; }
        public DateTimeOffset DateVerified { get; set; } = DateTime.Now;
        public string NewAccesion { get; set; }
        public string Validator { get; set; }

        // Constructor
        public PlantDeposit()
        {
            this.AccessionNumber = "";
            this.DepositNumber = "";
            this.PlantType = "";
            this.Collector = "";
            this.Locality = "";
            this.Staff = StaticAccess.StaffName;
            this.DateCollected = DateTime.Now;
            this.DateDeposited = DateTime.Now;
            this.Description = "";
            this.Status = "";
        }

        // Method
        public List<PlantDeposit> GetReceivedDeposits()
        {
            List<PlantDeposit> plantDeposits = new List<PlantDeposit>();
            DatabaseConnection connection = new DatabaseConnection();

            connection.setQuery("SELECT strDepositNumber, strPlantTypeName, strCollector, strFullLocality, strStaff, " +
                                    "CONVERT(VARCHAR, dateCollected, 107), CONVERT(VARCHAR, dateDeposited, 107), " +
                                    "strDescription, strStatus " +
                                "FROM viewReceivedDeposit " +
                                "WHERE strStatus IN ('New Deposit', 'Resubmitted')");

            SqlDataReader sqlData = connection.executeResult();
            while (sqlData.Read())
            {
                plantDeposits.Add(new PlantDeposit()
                {
                    DepositNumber = sqlData[0].ToString(),
                    PlantType = sqlData[1].ToString(),
                    Collector = sqlData[2].ToString(),
                    Locality = sqlData[3].ToString(),
                    Staff = sqlData[4].ToString(),
                    DateCollected = Convert.ToDateTime(sqlData[5]),
                    DateDeposited = Convert.ToDateTime(sqlData[6]),
                    Description = sqlData[7].ToString(),
                    Status = sqlData[8].ToString()
                });
            }
            connection.closeResult();
            return plantDeposits;
        }

        public List<PlantDeposit> GetRejectedDeposits()
        {
            List<PlantDeposit> plantDeposits = new List<PlantDeposit>();
            DatabaseConnection connection = new DatabaseConnection();

            connection.setQuery("SELECT strDepositNumber, strPlantTypeName, strCollector, strShortLocation, strStaff, " +
                                    "CONVERT(VARCHAR, dateCollected, 107), CONVERT(VARCHAR, dateDeposited, 107), " +
                                    "strDescription, strStatus " +
                                "FROM viewReceivedDeposit " +
                                "WHERE strStatus = 'Rejected'");

            SqlDataReader sqlData = connection.executeResult();
            while (sqlData.Read())
            {
                plantDeposits.Add(new PlantDeposit()
                {
                    DepositNumber = sqlData[0].ToString(),
                    PlantType = sqlData[1].ToString(),
                    Collector = sqlData[2].ToString(),
                    Locality = sqlData[3].ToString(),
                    Staff = sqlData[4].ToString(),
                    DateCollected = Convert.ToDateTime(sqlData[5]),
                    DateDeposited = Convert.ToDateTime(sqlData[6]),
                    Description = sqlData[7].ToString(),
                    Status = sqlData[8].ToString()
                });
            }
            connection.closeResult();
            return plantDeposits;
        }

        public List<PlantDeposit> GetVerifyingDeposits()
        {
            List<PlantDeposit> plantDeposits = new List<PlantDeposit>();
            DatabaseConnection connection = new DatabaseConnection();

            connection.setQuery("SELECT strAccessionNumber, strCollector, strFullLocality, strStaff, " +
                                    "CONVERT(VARCHAR, dateCollected, 107), CONVERT(VARCHAR, dateDeposited, 107), " +
                                    "strDescription, strStatus " +
                                "FROM viewPlantDeposit " +
                                "WHERE strStatus = 'For Verification'");

            SqlDataReader sqlData = connection.executeResult();
            while (sqlData.Read())
            {
                plantDeposits.Add(new PlantDeposit()
                {
                    AccessionNumber = sqlData[0].ToString(),
                    Collector = sqlData[1].ToString(),
                    Locality = sqlData[2].ToString(),
                    Staff = sqlData[3].ToString(),
                    DateCollected = Convert.ToDateTime(sqlData[4]),
                    DateDeposited = Convert.ToDateTime(sqlData[5]),
                    Description = sqlData[6].ToString(),
                    Status = sqlData[7].ToString()
                });
            }
            connection.closeResult();
            return plantDeposits;
        }

        public List<string> GetVerifiedAccessions(string taxonName)
        {
            List<string> accessionNumbers = new List<string>();
            DatabaseConnection connection = new DatabaseConnection();

            connection.setQuery("SELECT DISTINCT strReferenceAccession " +
                                "FROM viewHerbariumSheet " +
                                "WHERE strScientificName = @taxonName");
            connection.addQueryParameter("@taxonName", SqlDbType.VarChar, taxonName);
            SqlDataReader sqlData = connection.executeResult();

            while (sqlData.Read())
            {
                accessionNumbers.Add(sqlData[0].ToString());
            }
            connection.closeResult();
            
            return accessionNumbers;
        }

        public bool IsAccessionUnique(int accessionNo)
        {
            bool result;

            DatabaseConnection connection = new DatabaseConnection();
            connection.setQuery("SELECT intAccessionNumber FROM viewPlantDeposit WHERE intAccessionNumber = @accession");
            connection.addQueryParameter("@accession", SqlDbType.Int, accessionNo);

            SqlDataReader sqlData = connection.executeResult();
            result = sqlData.HasRows;
            connection.closeResult();

            return result;
        }

        public bool IsDuplicateHerbarium(string taxonName, ref string refAccession)
        {
            bool result;

            DatabaseConnection connection = new DatabaseConnection();
            connection.setQuery("SELECT DISTINCT strReferenceAccession " +
                                "FROM viewHerbariumSheet " +
                                "WHERE strCollector = @collector " +
                                    "AND strFullLocality = @locality " +
                                    "AND CONVERT(VARCHAR, dateCollected, 107) = @dateCollected " +
                                    "AND strDescription = @description " +
                                    "AND strScientificName = @taxonName");
            connection.addQueryParameter("@collector", SqlDbType.VarChar, Collector);
            connection.addQueryParameter("@locality", SqlDbType.VarChar, Locality);
            connection.addQueryParameter("@dateCollected", SqlDbType.VarChar, DateCollected);
            connection.addQueryParameter("@description", SqlDbType.VarChar, Description);
            connection.addQueryParameter("@taxonName", SqlDbType.VarChar, taxonName);

            SqlDataReader sqlData = connection.executeResult();
            while (sqlData.Read())
            {
                refAccession = sqlData[0].ToString();
            }
            result = sqlData.HasRows;
            connection.closeResult();

            return result;
        }
        
        public int SaveNewDeposit(bool pictureEmpty, byte[] picture = null)
        {
            int status;
            
            DatabaseConnection connection = new DatabaseConnection();
            connection.setStoredProc("dbo.procInsertPlantDeposit");
            connection.addProcParameter("@isIDBase", SqlDbType.Bit, 0);
            if (pictureEmpty)
                connection.addProcParameter("@herbariumSheet", SqlDbType.VarBinary, picture);
            connection.addProcParameter("@locality", SqlDbType.VarChar, Locality);
            connection.addProcParameter("@collector", SqlDbType.VarChar, Collector);
            connection.addProcParameter("@staff", SqlDbType.VarChar, Staff);
            connection.addProcParameter("@dateCollected", SqlDbType.Date, DateCollected.ToString());
            connection.addProcParameter("@description", SqlDbType.VarChar, Description);
            connection.addProcParameter("@plantType", SqlDbType.VarChar, PlantType);
            status = connection.executeProcedure();

            return status;
        }

        public int SaveUnverifiedDeposit(bool pictureEmpty, byte[] picture = null)
        {
            int status;
            int accessionDigit = Convert.ToInt32(DepositNumber);

            DatabaseConnection connection = new DatabaseConnection();
            connection.setStoredProc("dbo.procInsertPlantDeposit");
            connection.addProcParameter("@isIDBase", SqlDbType.Bit, 0);
            if (pictureEmpty)
                connection.addProcParameter("@herbariumSheet", SqlDbType.VarBinary, picture);
            connection.addProcParameter("@locality", SqlDbType.VarChar, Locality);
            connection.addProcParameter("@collector", SqlDbType.VarChar, Collector);
            connection.addProcParameter("@staff", SqlDbType.VarChar, Staff);
            connection.addProcParameter("@dateCollected", SqlDbType.Date, DateCollected.ToString());
            connection.addProcParameter("@description", SqlDbType.VarChar, Description);
            connection.addProcParameter("@plantType", SqlDbType.VarChar, PlantType);
            connection.addProcParameter("@accessionDigits", SqlDbType.Int, accessionDigit);
            connection.addProcParameter("@dateDeposited", SqlDbType.Date, DateDeposited.ToString());
            status = connection.executeProcedure();
            
            return status;
        }

        public int SaveVerifiedDeposit(bool sameAccession, bool pictureEmpty, byte[] picture = null)
        {
            int status;
            int accessionDigit = Convert.ToInt32(DepositNumber);

            DatabaseConnection connection = new DatabaseConnection();
            connection.setStoredProc("dbo.procInsertVerifiedDeposit");
            connection.addProcParameter("@isIDBase", SqlDbType.Bit, 0);
            connection.addProcParameter("@accessionDigits", SqlDbType.Int, accessionDigit);
            if (sameAccession)
                connection.addProcParameter("@newDeposit", SqlDbType.VarChar, NewAccesion);
            connection.addProcParameter("@sameAccession", SqlDbType.Bit, sameAccession);
            if (pictureEmpty)
                connection.addProcParameter("@herbariumSheet", SqlDbType.VarBinary, picture);
            connection.addProcParameter("@locality", SqlDbType.VarChar, Locality);
            connection.addProcParameter("@species", SqlDbType.VarChar, TaxonName);
            connection.addProcParameter("@collector", SqlDbType.VarChar, Collector);
            connection.addProcParameter("@validator", SqlDbType.VarChar, Validator);
            connection.addProcParameter("@staff", SqlDbType.VarChar, Staff);
            connection.addProcParameter("@dateCollected", SqlDbType.Date, DateCollected.ToString());
            connection.addProcParameter("@dateDeposited", SqlDbType.Date, DateDeposited.ToString());
            connection.addProcParameter("@dateVerified", SqlDbType.Date, DateVerified.ToString());
            connection.addProcParameter("@description", SqlDbType.VarChar, Description);
            connection.addProcParameter("@plantType", SqlDbType.VarChar, PlantType);
            status = connection.executeProcedure();

            return status;
        }

        public int ConfirmDeposit(string acceptStatus)
        {
            int status;
            DatabaseConnection connection = new DatabaseConnection();

            connection.setStoredProc("dbo.procConfirmDeposit");
            connection.addProcParameter("@depositNumber", SqlDbType.VarChar, DepositNumber);
            connection.addProcParameter("@receiveStatus", SqlDbType.VarChar, acceptStatus);
            status = connection.executeProcedure();
            
            return status;
        }

        public int ResubmitDeposit(byte[] bytestream)
        {
            int status;
            
            DatabaseConnection connection = new DatabaseConnection();
            connection.setStoredProc("dbo.procPlantResubmission");
            connection.addProcParameter("@isIDBase", SqlDbType.Bit, 0);
            connection.addProcParameter("@depositNumber", SqlDbType.VarChar, DepositNumber);
            connection.addProcParameter("@herbariumSheet", SqlDbType.VarBinary, bytestream);
            connection.addProcParameter("@locality", SqlDbType.VarChar, Locality);
            connection.addProcParameter("@staff", SqlDbType.VarChar, StaticAccess.StaffName);
            connection.addProcParameter("@description", SqlDbType.VarChar, Description);
            connection.addProcParameter("@plantType", SqlDbType.VarChar, PlantType);
            status = connection.executeProcedure();

            return status;
        }

        public int VerifyDeposit(string taxonName, string newDeposit)
        {
            int status;
            
            DatabaseConnection connection = new DatabaseConnection();
            connection.setStoredProc("dbo.procVerifyPlantDeposit");
            connection.addProcParameter("@isIDBase", SqlDbType.Bit, 0);
            connection.addProcParameter("@orgDeposit", SqlDbType.VarChar, AccessionNumber);
            connection.addProcParameter("@newDeposit", SqlDbType.VarChar, newDeposit);
            connection.addProcParameter("@species", SqlDbType.VarChar, taxonName);
            connection.addProcParameter("@validator", SqlDbType.VarChar, StaticAccess.StaffName);
            
            status = connection.executeProcedure();

            return status;
        }

        public int FurtherVerifyDeposit(string taxonName = null, string newDeposit = null)
        {
            int status;
            string refAccession = newDeposit ?? AccessionNumber;

            DatabaseConnection connection = new DatabaseConnection();
            connection.setStoredProc("dbo.procExternalVerifyDeposit");
            connection.addProcParameter("@isIDBase", SqlDbType.Bit, 0);
            connection.addProcParameter("@orgDeposit", SqlDbType.VarChar, AccessionNumber);
            if (taxonName != null)
            {
                connection.addProcParameter("@newDeposit", SqlDbType.VarChar, refAccession);
                connection.addProcParameter("@species", SqlDbType.VarChar, taxonName);
            }
            status = connection.executeProcedure();

            return status;
        }
    }
}
