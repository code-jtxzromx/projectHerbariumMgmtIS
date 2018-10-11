using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectHerbariumMgmtIS.Model
{
    public class CheckBoxList
    {
        public bool IsChecked { get; set; }
        public string Item { get; set; }

        public List<CheckBoxList> GetPhylumList()
        {
            List<CheckBoxList> listItems = new List<CheckBoxList>();
            DatabaseConnection connection = new DatabaseConnection();
            connection.setQuery("SELECT intPhylumID, strPhylumName FROM viewTaxonPhylum");

            SqlDataReader sqlData = connection.executeResult();
            while (sqlData.Read())
            {
                listItems.Add(new CheckBoxList()
                {
                    IsChecked = false,
                    Item = sqlData[1].ToString()
                });
            }
            connection.closeResult();

            return listItems;
        }

        public List<CheckBoxList> GetClassList()
        {
            List<CheckBoxList> listItems = new List<CheckBoxList>();
            DatabaseConnection connection = new DatabaseConnection();
            connection.setQuery("SELECT intClassID, strClassName FROM viewTaxonClass");

            SqlDataReader sqlData = connection.executeResult();
            while (sqlData.Read())
            {
                listItems.Add(new CheckBoxList()
                {
                    IsChecked = false,
                    Item = sqlData[1].ToString()
                });
            }
            connection.closeResult();

            return listItems;
        }

        public List<CheckBoxList> GetOrderList()
        {
            List<CheckBoxList> listItems = new List<CheckBoxList>();
            DatabaseConnection connection = new DatabaseConnection();
            connection.setQuery("SELECT intOrderID, strOrderName FROM viewTaxonOrder");

            SqlDataReader sqlData = connection.executeResult();
            while (sqlData.Read())
            {
                listItems.Add(new CheckBoxList()
                {
                    IsChecked = false,
                    Item = sqlData[1].ToString()
                });
            }
            connection.closeResult();

            return listItems;
        }

        public List<CheckBoxList> GetFamilyList()
        {
            List<CheckBoxList> listItems = new List<CheckBoxList>();
            DatabaseConnection connection = new DatabaseConnection();
            connection.setQuery("SELECT intFamilyID, strFamilyName FROM viewTaxonFamily");

            SqlDataReader sqlData = connection.executeResult();
            while (sqlData.Read())
            {
                listItems.Add(new CheckBoxList()
                {
                    IsChecked = false,
                    Item = sqlData[1].ToString()
                });
            }
            connection.closeResult();

            return listItems;
        }

        public List<CheckBoxList> GetGenusList()
        {
            List<CheckBoxList> listItems = new List<CheckBoxList>();
            DatabaseConnection connection = new DatabaseConnection();
            connection.setQuery("SELECT intGenusID, strGenusName FROM viewTaxonGenus");

            SqlDataReader sqlData = connection.executeResult();
            while (sqlData.Read())
            {
                listItems.Add(new CheckBoxList()
                {
                    IsChecked = false,
                    Item = sqlData[1].ToString()
                });
            }
            connection.closeResult();

            return listItems;
        }

        public List<CheckBoxList> GetAuthorsList()
        {
            List<CheckBoxList> listItems = new List<CheckBoxList>();
            DatabaseConnection connection = new DatabaseConnection();
            connection.setQuery("SELECT intAuthorID, strAuthorsName FROM tblAuthor");

            SqlDataReader sqlData = connection.executeResult();
            while (sqlData.Read())
            {
                listItems.Add(new CheckBoxList()
                {
                    IsChecked = false,
                    Item = sqlData[1].ToString()
                });
            }
            connection.closeResult();

            return listItems;
        }
    }
}
