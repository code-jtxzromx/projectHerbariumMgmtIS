using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectHerbariumMgmtIS.Model
{
    public class TaxonOrder
    {
        // Properties
        public string OrderID { get; set; }
        public string ClassName { get; set; }
        public string OrderName { get; set; }

        // Constuctor
        public TaxonOrder()
        {
            this.OrderID = "";
            this.ClassName = "";
            this.OrderName = "";
        }

        // Methods
        public List<TaxonOrder> GetOrders()
        {
            List<TaxonOrder> orders = new List<TaxonOrder>();
            DatabaseConnection connection = new DatabaseConnection();
            
            connection.setQuery("SELECT strOrderNo, strClassName, strOrderName " +
                                "FROM viewTaxonOrder " +
                                "ORDER BY strClassName, strOrderName");
            SqlDataReader sqlData = connection.executeResult();

            while (sqlData.Read())
            {
                orders.Add(new TaxonOrder()
                {
                    OrderID = sqlData[0].ToString(),
                    ClassName = sqlData[1].ToString(),
                    OrderName = sqlData[2].ToString()
                });
            }
            connection.closeResult();
            return orders;
        }

        public List<string> GetOrderList()
        {
            List<string> orders = new List<string>();
            DatabaseConnection connection = new DatabaseConnection();

            connection.setQuery("SELECT strOrderName FROM tblOrder ORDER BY strOrderName");
            SqlDataReader sqlData = connection.executeResult();

            while (sqlData.Read())
            {
                orders.Add(sqlData[0].ToString());
            }
            connection.closeResult();
            return orders;
        }

        public int AddOrder()
        {
            int status;
            DatabaseConnection connection = new DatabaseConnection();

            connection.setStoredProc("dbo.procInsertOrder");
            connection.addProcParameter("@isIDBase", SqlDbType.Bit, 0);
            connection.addProcParameter("@className", SqlDbType.VarChar, ClassName);
            connection.addProcParameter("@orderName", SqlDbType.VarChar, OrderName);
            status = connection.executeProcedure();

            return status;
        }

        public int EditOrder()
        {
            int status;
            DatabaseConnection connection = new DatabaseConnection();

            connection.setStoredProc("dbo.procUpdateOrder");
            connection.addProcParameter("@isIDBase", SqlDbType.Bit, 0);
            connection.addProcParameter("@orderNo", SqlDbType.VarChar, OrderID);
            connection.addProcParameter("@className", SqlDbType.VarChar, ClassName);
            connection.addProcParameter("@orderName", SqlDbType.VarChar, OrderName);
            status = connection.executeProcedure();

            return status;
        }
    }
}
