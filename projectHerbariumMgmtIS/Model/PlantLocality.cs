using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectHerbariumMgmtIS.Model
{
    public class PlantLocality
    {
        // Properties
        public int LocalityID { get; set; }
        public string FullLocation { get; set; }
        public string Country { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string SpecificLocation { get; set; }
        public string ShortLocation { get; set; }
        public string Latitude { get; set; }
        public string Longtitude { get; set; }

        // Constructor
        public PlantLocality()
        {
            this.LocalityID = 0;
            this.FullLocation = "";
            this.Country = "Philippines";
            this.Province = "";
            this.City = "";
            this.SpecificLocation = "";
            this.ShortLocation = "";
            this.Latitude = "";
            this.Longtitude = "";
        }

        // Methods
        public List<PlantLocality> GetPlantLocalities()
        {
            List<PlantLocality> localities = new List<PlantLocality>();
            DatabaseConnection connection = new DatabaseConnection();

            connection.setQuery("SELECT intLocalityID, strCountry, strProvince, strCity, strSpecificLocation, " +
                                        "strShortLocation, strFullLocality, strLatitude, strLongtitude " +
                                "FROM viewLocality " +
                                "ORDER BY strFullLocality");
            SqlDataReader sqlData = connection.executeResult();

            while (sqlData.Read())
            {
                localities.Add(new PlantLocality()
                {
                    LocalityID = Convert.ToInt32(sqlData[0]),
                    Country = sqlData[1].ToString(),
                    Province = sqlData[2].ToString(),
                    City = sqlData[3].ToString(),
                    SpecificLocation = sqlData[4].ToString(),
                    ShortLocation = sqlData[5].ToString(),
                    FullLocation = sqlData[6].ToString(),
                    Latitude = sqlData[7].ToString(),
                    Longtitude = sqlData[8].ToString()
                });
            }
            connection.closeResult();
            return localities;
        }

        public List<string> GetLocalityList()
        {
            List<string> localities = new List<string>();
            DatabaseConnection connection = new DatabaseConnection();

            connection.setQuery("SELECT strShortLocation FROM tblLocality ORDER BY strShortLocation");
            SqlDataReader sqlData = connection.executeResult();

            while (sqlData.Read())
            {
                localities.Add(sqlData[0].ToString());
            }
            connection.closeResult();
            return localities;
        }

        public List<string> GetCountryList()
        {
            List<string> countries = new List<string>();
            DatabaseConnection connection = new DatabaseConnection();

            connection.setQuery("SELECT strCountry FROM tblCountry ORDER BY strCountry");
            SqlDataReader sqlData = connection.executeResult();

            while (sqlData.Read())
            {
                countries.Add(sqlData[0].ToString());
            }
            connection.closeResult();
            return countries;
        }

        public List<string> GetProvinceList()
        {
            List<string> provinces = new List<string>();
            DatabaseConnection connection = new DatabaseConnection();

            connection.setQuery("SELECT strProvince FROM tblProvince ORDER BY strProvince");
            SqlDataReader sqlData = connection.executeResult();

            while (sqlData.Read())
            {
                provinces.Add(sqlData[0].ToString());
            }
            connection.closeResult();
            return provinces;
        }

        public List<string[]> GetCityList()
        {
            List<string[]> cities = new List<string[]>();
            DatabaseConnection connection = new DatabaseConnection();
            connection.setQuery("SELECT strProvince, strCity FROM tblCity Ci INNER JOIN tblProvince Pr ON Ci.intProvinceID = Pr.intProvinceID ORDER BY strProvince, strCity");

            SqlDataReader sqlData = connection.executeResult();
            while (sqlData.Read())
            {
                cities.Add(new string[]
                {
                    sqlData[0].ToString(), sqlData[1].ToString()
                });
            }
            connection.closeResult();
            return cities;
        }

        public int AddLocality()
        {
            int status;
            DatabaseConnection connection = new DatabaseConnection();
            
            connection.setStoredProc("dbo.procInsertLocality");
            connection.addProcParameter("@isIDBase", SqlDbType.Bit, 0);
            connection.addProcParameter("@country", SqlDbType.VarChar, Country);
            connection.addProcParameter("@province", SqlDbType.VarChar, Province);
            connection.addProcParameter("@city", SqlDbType.VarChar, City);
            connection.addProcParameter("@specificLocation", SqlDbType.VarChar, SpecificLocation);
            connection.addProcParameter("@shortLocation", SqlDbType.VarChar, ShortLocation);
            connection.addProcParameter("@fullLocation", SqlDbType.VarChar, FullLocation);
            connection.addProcParameter("@latitude", SqlDbType.VarChar, Latitude);
            connection.addProcParameter("@longtitude", SqlDbType.VarChar, Longtitude);
            status = connection.executeProcedure();

            return status;
        }

        public int EditLocality()
        {
            int status;
            DatabaseConnection connection = new DatabaseConnection();

            connection.setStoredProc("dbo.procUpdateLocality");
            connection.addProcParameter("@isIDBase", SqlDbType.Bit, 0);
            connection.addProcParameter("@localityID", SqlDbType.Int, LocalityID);
            connection.addProcParameter("@country", SqlDbType.VarChar, Country);
            connection.addProcParameter("@province", SqlDbType.VarChar, Province);
            connection.addProcParameter("@city", SqlDbType.VarChar, City);
            connection.addProcParameter("@specificLocation", SqlDbType.VarChar, SpecificLocation);
            connection.addProcParameter("@shortLocation", SqlDbType.VarChar, ShortLocation);
            connection.addProcParameter("@fullLocation", SqlDbType.VarChar, FullLocation);
            connection.addProcParameter("@latitude", SqlDbType.VarChar, Latitude);
            connection.addProcParameter("@longtitude", SqlDbType.VarChar, Longtitude);
            status = connection.executeProcedure();

            return status;
        }
    }
}
