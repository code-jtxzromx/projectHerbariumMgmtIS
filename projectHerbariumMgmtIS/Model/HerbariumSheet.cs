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
        public string PlantType { get; set; }
        public string BoxLocation { get; set; }
        public string FamilyName { get; set; }
        public string ScientificName { get; set; }
        public string TaxonNomenclature { get; set; }
        public string DateCollected { get; set; }
        public string DateDeposited { get; set; }
        public string DateValidated { get; set; }
        public string Province { get; set; }
        public string Locality { get; set; }
        public string Collector { get; set; }
        public string Staff { get; set; }
        public string Validator { get; set; }
        public string Description { get; set; }
        public string LoanNumber { get; set; }
        public string Borrower { get; set; }
        public string Duration { get; set; }
        public string LoanReturned { get; set; }
        public string LoanAvailability { get; set; }
        public bool IsAvailable { get; set; }
        public bool IsChecked { get; set; }
        public string Status { get; set; }
        
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

        public List<HerbariumSheet> GetHerbariumTraces()
        {
            List<HerbariumSheet> herbariumSheets = new List<HerbariumSheet>();
            DatabaseConnection connection = new DatabaseConnection();

            connection.setQuery("SELECT strAccessionNumber, strReferenceAccession, strScientificName, ISNULL(strBoxNumber, ''), " +
                                    "ISNULL(strFamilyName, ''), ISNULL(strFullNomenclature, ''), strPlantTypeName, strFullLocality, " +
                                    "strCollector, strStaff, ISNULL(strValidator, ''), CONVERT(VARCHAR, dateCollected, 107), " +
                                    "CONVERT(VARCHAR, dateDeposited, 107), ISNULL(CONVERT(VARCHAR, dateVerified, 107), ''), " +
                                    "strDescription, ISNULL(strLoanNumber, ''), ISNULL(strBorrower, ''), ISNULL(strDuration, ''), " +
                                    "CAST(ISNULL(boolLoanAvailable, 0) AS BIT), strStatus " +
                                "FROM viewHerbariumSheetTrack");

            SqlDataReader sqlData = connection.executeResult();
            while (sqlData.Read())
            {
                herbariumSheets.Add(new HerbariumSheet()
                {
                    AccessionNumber = sqlData[0].ToString(),
                    ReferenceNumber = sqlData[1].ToString(),
                    ScientificName = sqlData[2].ToString(),
                    BoxLocation = sqlData[3].ToString(),
                    FamilyName = sqlData[4].ToString(),
                    TaxonNomenclature = sqlData[5].ToString().Replace(';', '\n'),
                    PlantType = sqlData[6].ToString(),
                    Locality = sqlData[7].ToString(),
                    Collector = sqlData[8].ToString(),
                    Staff = sqlData[9].ToString(),
                    Validator = sqlData[10].ToString(),
                    DateCollected = sqlData[11].ToString(),
                    DateDeposited = sqlData[12].ToString(),
                    DateValidated = sqlData[13].ToString(),
                    Description = sqlData[14].ToString(),
                    LoanNumber = sqlData[15].ToString(),
                    Borrower = sqlData[16].ToString(),
                    Duration = sqlData[17].ToString(),
                    LoanAvailability = Convert.ToBoolean(sqlData[18]) ? "Available" : "Not Available",
                    Status = sqlData[19].ToString()
                });
            }
            connection.closeResult();
            return herbariumSheets;
        }

        public List<HerbariumSheet> GetHerbariumSheetQuery()
        {
            List<HerbariumSheet> herbariumSheets = new List<HerbariumSheet>();
            DatabaseConnection connection = new DatabaseConnection();

            connection.setQuery("SELECT PD.strAccessionNumber, ISNULL(HS.strReferenceAccession, ''), PD.strPlantTypeName, " +
                                    "ISNULL(CONCAT(' [', HS.strFamilyName, ']'), ''), ISNULL(HS.strScientificName, '- not verified yet-'), " +
                                    "ISNULL(HS.strFullNomenclature, '- not verified yet-'), PD.strProvince, PD.strFullLocality, " +
                                    "PD.strCollector, PD.strStaff, ISNULL(HS.strValidator, '- not verified yet-'), " +
                                    "CONVERT(VARCHAR, PD.dateCollected, 107), CONVERT(VARCHAR, PD.dateDeposited, 107), " +
                                    "ISNULL(CONVERT(VARCHAR, HS.dateVerified, 107), '- not verified yet -'), " +
                                    "PD.strDescription, ISNULL(HI.strBoxNumber, '- not stored yet-'), " +
                                    "ISNULL(HI.boolLoanAvailable, 0), PD.strStatus " +
                                "FROM viewPlantDeposit PD " +
                                    "LEFT JOIN viewHerbariumSheet HS ON PD.strAccessionNumber = HS.strAccessionNumber " +
                                    "LEFT JOIN viewHerbariumInventory HI ON HS.strAccessionNumber = HI.strAccessionNumber");

            SqlDataReader sqlData = connection.executeResult();
            while (sqlData.Read())
            {
                herbariumSheets.Add(new HerbariumSheet()
                {
                    AccessionNumber = sqlData[0].ToString(),
                    ReferenceNumber = sqlData[1].ToString(),
                    PlantType = sqlData[2].ToString(),
                    FamilyName = sqlData[3].ToString(),
                    ScientificName = sqlData[4].ToString(),
                    TaxonNomenclature = sqlData[5].ToString().Replace(';', '\n'),
                    Province = sqlData[6].ToString(),
                    Locality = sqlData[7].ToString(),
                    Collector = sqlData[8].ToString(),
                    Staff = sqlData[9].ToString(),
                    Validator = sqlData[10].ToString(),
                    DateCollected = sqlData[11].ToString(),
                    DateDeposited = sqlData[12].ToString(),
                    DateValidated = sqlData[13].ToString(),
                    Description = sqlData[14].ToString(),
                    BoxLocation = sqlData[15].ToString(),
                    LoanAvailability = Convert.ToBoolean(sqlData[16]) ? "Available" : "Not Available",
                    Status = sqlData[17].ToString()
                });
            }
            connection.closeResult();
            return herbariumSheets;
        }

        public List<HerbariumSheet> GetVerifiedDepositReport(string startDate, string endDate)
        {
            List<HerbariumSheet> herbariumSheets = new List<HerbariumSheet>();
            DatabaseConnection connection = new DatabaseConnection();

            connection.setQuery("SELECT strAccessionNumber, strCollector, strScientificName, CONVERT(VARCHAR, dateVerified, 107) " +
                                "FROM viewHerbariumSheet " +
                                "WHERE dateVerified BETWEEN @startDate AND @endDate");
            connection.addQueryParameter("@startDate", SqlDbType.VarChar, startDate);
            connection.addQueryParameter("@endDate", SqlDbType.VarChar, endDate);

            SqlDataReader sqlData = connection.executeResult();
            while (sqlData.Read())
            {
                herbariumSheets.Add(new HerbariumSheet()
                {
                    AccessionNumber = sqlData[0].ToString(),
                    Collector = sqlData[1].ToString(),
                    ScientificName = sqlData[2].ToString(),
                    DateValidated = sqlData[3].ToString(),
                });
            }
            connection.closeResult();
            return herbariumSheets;
        }

        public List<HerbariumSheet> GetDamagedSheetReport(string startDate, string endDate)
        {
            List<HerbariumSheet> herbariumSheets = new List<HerbariumSheet>();
            DatabaseConnection connection = new DatabaseConnection();

            connection.setQuery("SELECT strLoanNumber, strBorrower, strDuration, CONVERT(VARCHAR, dateReturned, 107), " +
                                        "strAccessionNumber, strScientificName, strStatus " +
                                "FROM viewLoanedSheets " +
                                "WHERE dateReturned BETWEEN @startDate AND @endDate AND boolCondition = 0");
            connection.addQueryParameter("@startDate", SqlDbType.VarChar, startDate);
            connection.addQueryParameter("@endDate", SqlDbType.VarChar, endDate);

            SqlDataReader sqlData = connection.executeResult();
            while (sqlData.Read())
            {
                herbariumSheets.Add(new HerbariumSheet()
                {
                    LoanNumber = sqlData[0].ToString(),
                    Borrower = sqlData[1].ToString(),
                    Duration = sqlData[2].ToString(),
                    LoanReturned = sqlData[3].ToString(),
                    AccessionNumber = sqlData[4].ToString(),
                    ScientificName = sqlData[5].ToString(),
                    Status = sqlData[6].ToString(),
                });
            }
            connection.closeResult();
            return herbariumSheets;
        }

        public List<HerbariumSheet> GetDamagedSheetReportByBorrower(string borrower)
        {
            List<HerbariumSheet> herbariumSheets = new List<HerbariumSheet>();
            DatabaseConnection connection = new DatabaseConnection();

            connection.setQuery("SELECT strLoanNumber, strBorrower, strDuration, CONVERT(VARCHAR, dateReturned, 107), " +
                                        "strAccessionNumber, strScientificName, strStatus " +
                                "FROM viewLoanedSheets " +
                                "WHERE strBorrower = @borrower AND boolCondition = 0");
            connection.addQueryParameter("@borrower", SqlDbType.VarChar, borrower);

            SqlDataReader sqlData = connection.executeResult();
            while (sqlData.Read())
            {
                herbariumSheets.Add(new HerbariumSheet()
                {
                    LoanNumber = sqlData[0].ToString(),
                    Borrower = sqlData[1].ToString(),
                    Duration = sqlData[2].ToString(),
                    LoanReturned = sqlData[3].ToString(),
                    AccessionNumber = sqlData[4].ToString(),
                    ScientificName = sqlData[5].ToString(),
                    Status = sqlData[6].ToString(),
                });
            }
            connection.closeResult();
            return herbariumSheets;
        }

        public List<HerbariumSheet> GetDamagedSheetReportByLoan(string loanNumber)
        {
            List<HerbariumSheet> herbariumSheets = new List<HerbariumSheet>();
            DatabaseConnection connection = new DatabaseConnection();

            connection.setQuery("SELECT strLoanNumber, strBorrower, strDuration, CONVERT(VARCHAR, dateReturned, 107), " +
                                        "strAccessionNumber, strScientificName, strStatus " +
                                "FROM viewLoanedSheets " +
                                "WHERE strLoanNumber = @loanNumber AND boolCondition = 0");
            connection.addQueryParameter("@loanNumber", SqlDbType.VarChar, loanNumber);

            SqlDataReader sqlData = connection.executeResult();
            while (sqlData.Read())
            {
                herbariumSheets.Add(new HerbariumSheet()
                {
                    LoanNumber = sqlData[0].ToString(),
                    Borrower = sqlData[1].ToString(),
                    Duration = sqlData[2].ToString(),
                    LoanReturned = sqlData[3].ToString(),
                    AccessionNumber = sqlData[4].ToString(),
                    ScientificName = sqlData[5].ToString(),
                    Status = sqlData[6].ToString(),
                });
            }
            connection.closeResult();
            return herbariumSheets;
        }

        public List<HerbariumSheet> GetLoanedSheets(string loanNumber)
        {
            List<HerbariumSheet> herbariumSheets = new List<HerbariumSheet>();
            DatabaseConnection connection = new DatabaseConnection();

            connection.setQuery("SELECT strAccessionNumber, strScientificName, strStatus " +
                                "FROM viewLoanedSheets " +
                                "WHERE strLoanNumber = @loanNumber " +
                                "ORDER BY strAccessionNumber ASC");
            connection.addQueryParameter("@loanNumber", SqlDbType.VarChar, loanNumber);
            SqlDataReader sqlData = connection.executeResult();

            while (sqlData.Read())
            {
                herbariumSheets.Add(new HerbariumSheet()
                {
                    AccessionNumber = sqlData[0].ToString(),
                    ScientificName = sqlData[1].ToString(),
                    Status = sqlData[2].ToString(),
                    IsChecked = false
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
            connection.addProcParameter("@staff", SqlDbType.VarChar, StaticAccess.StaffName);
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
            connection.addProcParameter("@staff", SqlDbType.VarChar, StaticAccess.StaffName);
            status = connection.executeProcedure();

            return status;
        }

        public int UpdateReturnedSheets(string loanNumber)
        {
            int status;
            DatabaseConnection connection = new DatabaseConnection();
            connection.setStoredProc("dbo.procReturnPlantCondition");
            connection.addProcParameter("@loanNumber", SqlDbType.VarChar, loanNumber);
            connection.addProcParameter("@sheetNo", SqlDbType.VarChar, AccessionNumber);
            connection.addProcParameter("@condition", SqlDbType.Bit, IsChecked);
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
