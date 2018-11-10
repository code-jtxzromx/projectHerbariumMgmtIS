using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectHerbariumMgmtIS.Model
{
    public class TaxonClass
    {
        // Properties
        public string ClassID { get; set; }
        public string PhylumName { get; set; }
        public string ClassName { get; set; }

        // Constructor
        public TaxonClass()
        {
            this.ClassID = "";
            this.PhylumName = "";
            this.ClassName = "";
        }

        // Methods
        public List<TaxonClass> GetClasses()
        {
            List<TaxonClass> classes = new List<TaxonClass>();
            DatabaseConnection connection = new DatabaseConnection();
            
            connection.setQuery("SELECT strClassNo, strPhylumName, strClassName " +
                                "FROM viewTaxonClass " +
                                "ORDER BY strPhylumName, strClassName");
            SqlDataReader sqlData = connection.executeResult();

            while (sqlData.Read())
            {
                classes.Add(new TaxonClass()
                {
                    ClassID = sqlData[0].ToString(),
                    PhylumName = sqlData[1].ToString(),
                    ClassName = sqlData[2].ToString()
                });
            }
            connection.closeResult();
            return classes;
        }

        public List<string> GetVerifiedClasses()
        {
            List<string> classes = new List<string>();
            DatabaseConnection connection = new DatabaseConnection();

            connection.setQuery("SELECT DISTINCT strClassName FROM tblSpeciesData ORDER BY strClassName");
            SqlDataReader sqlData = connection.executeResult();

            while (sqlData.Read())
            {
                classes.Add(sqlData[0].ToString());
            }
            connection.closeResult();
            return classes;
        }

        public List<string> GetClassList()
        {
            List<string> classes = new List<string>();
            DatabaseConnection connection = new DatabaseConnection();

            connection.setQuery("SELECT strClassName FROM tblClass ORDER BY strClassName");
            SqlDataReader sqlData = connection.executeResult();

            while (sqlData.Read())
            {
                classes.Add(sqlData[0].ToString());
            }
            connection.closeResult();
            return classes;
        }

        public int AddClass()
        {
            int status;
            DatabaseConnection connection = new DatabaseConnection();

            connection.setStoredProc("dbo.procInsertClass");
            connection.addProcParameter("@isIDBase", SqlDbType.Bit, 0);
            connection.addProcParameter("@phylumName", SqlDbType.VarChar, PhylumName);
            connection.addProcParameter("@className", SqlDbType.VarChar, ClassName);
            status = connection.executeProcedure();

            return status;
        }

        public int EditClass()
        {
            int status;
            DatabaseConnection connection = new DatabaseConnection();

            connection.setStoredProc("dbo.procUpdateClass");
            connection.addProcParameter("@isIDBase", SqlDbType.Bit, 0);
            connection.addProcParameter("@classNo", SqlDbType.VarChar, ClassID);
            connection.addProcParameter("@phylumName", SqlDbType.VarChar, PhylumName);
            connection.addProcParameter("@className", SqlDbType.VarChar, ClassName);
            status = connection.executeProcedure();

            return status;
        }
    }
}
