using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectHerbariumMgmtIS.Model
{
    public class PlantType
    {
        // Properties
        public int PlantTypeID { get; set; }
        public string Code { get; set; }
        public string Type { get; set; }

        // Constructor
        public PlantType()
        {
            this.PlantTypeID = 0;
            this.Code = "";
            this.Type = "";
        }

        // Methods
        public List<PlantType> GetPlantTypes()
        {
            List<PlantType> types = new List<PlantType>();
            DatabaseConnection connection = new DatabaseConnection();

            connection.setQuery("SELECT intPlantTypeID, strPlantTypeCode, strPlantTypeName " +
                                "FROM tblPlantType " +
                                "ORDER BY strPlantTypeCode");
            SqlDataReader sqlData = connection.executeResult();

            while (sqlData.Read())
            {
                types.Add(new PlantType()
                {
                    PlantTypeID = Convert.ToInt32(sqlData[0]),
                    Code = sqlData[1].ToString(),
                    Type = sqlData[2].ToString()
                });
            }
            connection.closeResult();

            return types;
        }

        public List<string> GetPlantTypeList()
        {
            List<string> types = new List<string>();
            DatabaseConnection connection = new DatabaseConnection();

            connection.setQuery("SELECT strPlantTypeName FROM tblPlantType ORDER BY strPlantTypeName");
            SqlDataReader sqlData = connection.executeResult();

            while (sqlData.Read())
            {
                types.Add(sqlData[0].ToString());
            }
            connection.closeResult();
            return types;
        }

        public int AddPlantType()
        {
            int status;
            DatabaseConnection connection = new DatabaseConnection();

            connection.setStoredProc("dbo.procInsertPlantType");
            connection.addProcParameter("@plantCode", SqlDbType.VarChar, Code);
            connection.addProcParameter("@plantType", SqlDbType.VarChar, Type);
            status = connection.executeProcedure();

            return status;
        }

        public int EditPlantType()
        {
            int status;
            DatabaseConnection connection = new DatabaseConnection();

            connection.setStoredProc("dbo.procUpdatePlantType");
            connection.addProcParameter("@plantTypeID", SqlDbType.Int, PlantTypeID);
            connection.addProcParameter("@plantCode", SqlDbType.VarChar, Code);
            connection.addProcParameter("@plantType", SqlDbType.VarChar, Type);
            status = connection.executeProcedure();

            return status;
        }
    }
}
