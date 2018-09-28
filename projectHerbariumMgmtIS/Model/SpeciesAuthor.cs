using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectHerbariumMgmtIS.Model
{
    public class SpeciesAuthor
    {
        // Properties
        public int AuthorID { get; set; }
        public string AuthorName { get; set; }
        public string AuthorSuffix { get; set; }

        // Constructors
        public SpeciesAuthor()
        {
            this.AuthorID = 0;
            this.AuthorName = "";
            this.AuthorSuffix = "";
        }

        // Methods
        public List<SpeciesAuthor> GetAuthors()
        {
            List<SpeciesAuthor> authors = new List<SpeciesAuthor>();
            DatabaseConnection connection = new DatabaseConnection();
            
            connection.setQuery("SELECT intAuthorID, strAuthorsName, strSpeciesSuffix " +
                                "FROM tblAuthor " +
                                "ORDER BY strAuthorsName");
            SqlDataReader sqlData = connection.executeResult();

            while (sqlData.Read())
            {
                authors.Add(new SpeciesAuthor()
                {
                    AuthorID = Convert.ToInt32(sqlData[0]),
                    AuthorName = sqlData[1].ToString(),
                    AuthorSuffix = sqlData[2].ToString()
                });
            }
            connection.closeResult();
            return authors;
        }

        public List<string> GetAuthorList()
        {
            List<string> author = new List<string>();
            DatabaseConnection connection = new DatabaseConnection();

            connection.setQuery("SELECT strAuthorsName FROM tblAuthor ORDER BY strAuthorsName");
            SqlDataReader sqlData = connection.executeResult();

            while (sqlData.Read())
            {
                author.Add(sqlData[0].ToString());
            }
            connection.closeResult();
            return author;
        }

        public int AddAuthor()
        {
            int status;
            DatabaseConnection connection = new DatabaseConnection();

            connection.setStoredProc("dbo.procInsertSpeciesAuthor");
            connection.addProcParameter("@author", SqlDbType.VarChar, AuthorName);
            connection.addProcParameter("@speciesSuffix", SqlDbType.VarChar, AuthorSuffix);
            status = connection.executeProcedure();

            return status;
        }

        public int EditAuthor()
        {
            int status;
            DatabaseConnection connection = new DatabaseConnection();

            connection.setStoredProc("dbo.procUpdateSpeciesAuthor");
            connection.addProcParameter("@authorID", SqlDbType.Int, AuthorID);
            connection.addProcParameter("@author", SqlDbType.VarChar, AuthorName);
            connection.addProcParameter("@speciesSuffix", SqlDbType.VarChar, AuthorSuffix);
            status = connection.executeProcedure();

            return status;
        }
    }
}
