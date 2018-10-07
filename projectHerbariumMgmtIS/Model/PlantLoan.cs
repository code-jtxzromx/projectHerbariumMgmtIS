using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectHerbariumMgmtIS.Model
{
    public class PlantLoan
    {
        // Properties
        public string LoanNumber { get; set; }
        public string Borrower { get; set; }
        public string StartDate { get; set; }
        public string ReturningDate { get; set; }
        public string Duration { get; set; }
        public string DateProcessed { get; set; }
        public string Purpose { get; set; }
        public string Status { get; set; }

        // Constructor
        public PlantLoan()
        {
            this.LoanNumber = "";
            this.Borrower = "";
            this.StartDate = DateTime.Today.ToString();
            this.ReturningDate = DateTime.Today.ToString();
            this.Duration = "";
            this.DateProcessed = "";
            this.Purpose = "";
            this.Status = "";
        }

        public List<PlantLoan> GetCurrentLoans()
        {
            List<PlantLoan> loans = new List<PlantLoan>();
            DatabaseConnection connection = new DatabaseConnection();
            
            connection.setQuery("SELECT strLoanNumber, strBorrower, dateLoan, dateReturning, strDuration, " +
                                    "dateProcessed, strPurpose, strStatus " +
                                "FROM viewPlantLoans " +
                                "WHERE strStatus IN ('Requesting', 'Approved')");
            SqlDataReader sqlData = connection.executeResult();

            while (sqlData.Read())
            {
                loans.Add(new PlantLoan()
                {
                    LoanNumber = sqlData[0].ToString(),
                    Borrower = sqlData[1].ToString(),
                    StartDate = sqlData[2].ToString(),
                    ReturningDate = sqlData[3].ToString(),
                    Duration = sqlData[4].ToString(),
                    DateProcessed = sqlData[5].ToString(),
                    Purpose = sqlData[6].ToString(),
                    Status = sqlData[7].ToString()
                });
            }
            connection.closeResult();
            return loans;
        }

        public List<PlantLoan> GetReturningLoans()
        {
            return new List<PlantLoan>();
        }

        public int ProcessNewLoan(List<TaxonSpecies> loaningSpecies)
        {
            int status;
            int loan_status = new int();
            string loanNumber = "";
            DatabaseConnection connection = new DatabaseConnection();

            connection.setStoredProc("dbo.procProcessLoan");
            connection.addProcParameter("@isIDBase", SqlDbType.Bit, 0);
            connection.addProcParameter("@borrower", SqlDbType.VarChar, Borrower);
            connection.addProcParameter("@startDate", SqlDbType.Date, StartDate);
            connection.addProcParameter("@endDate", SqlDbType.Date, ReturningDate);
            connection.addProcParameter("@purpose", SqlDbType.VarChar, Purpose);
            connection.addProcParameter("@status", SqlDbType.VarChar, Status);
            status = connection.executeProcedure();

            if (status == 0)
            {
                connection.setQuery("SELECT strLoanNumber " +
                                    "FROM viewPlantLoans " +
                                    "WHERE strBorrower = @borrower AND dateLoan = @startdate AND dateReturning = @enddate");
                connection.addQueryParameter("@borrower", SqlDbType.VarChar, Borrower);
                connection.addQueryParameter("@startdate", SqlDbType.Date, StartDate);
                connection.addQueryParameter("@enddate", SqlDbType.Date, ReturningDate);

                SqlDataReader sqlData = connection.executeResult();
                while (sqlData.Read())
                {
                    loanNumber = sqlData[0].ToString();
                }
                connection.closeResult();

                foreach (var item in loaningSpecies)
                {
                    loan_status = item.LoanSpecies(loanNumber);
                    if (loan_status == 1)
                        break;
                }

                return loan_status;
            }
            else
                return -1;
        }
    }
}
