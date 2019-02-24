using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Windows.UI.Popups;

namespace projectHerbariumMgmtIS.Model
{
    public class SubMenu
    { 
        public string MenuItem { get; set; }
        public string Page { get; set; }
        public Type TypePage { get; set; }

        public List<SubMenu> GetSubMenu(string module)
        {
            int accessLv = (StaticAccess.Role == "ADMINISTRATOR") ? 3 : ((StaticAccess.Role == "CURATOR") ? 2 : 1);
            List<SubMenu> menus = new List<SubMenu>();

            DatabaseConnection connection = new DatabaseConnection();
            connection.setQuery("SELECT strSubMenu, strPageLocation " +
                                "FROM tblSystemMenu " +
                                "WHERE strMainMenu = @mainMenu AND strLevel = 'B' AND intAccessLevel <= @accessLevel");
            connection.addQueryParameter("@mainMenu", SqlDbType.VarChar, module);
            connection.addQueryParameter("@accessLevel", SqlDbType.VarChar, accessLv);
            SqlDataReader sqlData = connection.executeResult();

            while (sqlData.Read())
            {
                menus.Add(new SubMenu()
                {
                    MenuItem = sqlData[0].ToString(),
                    Page = sqlData[1].ToString()
                });
            }
            connection.closeResult();

            //XElement xelement = XElement.Load("Model\\SubMenu.xml");
            //var main_menu = from element in xelement.Elements("SubMenu")
            //                where (string)element.Element("MainMenu") == module
            //                where (int)element.Element("AccessLevel") <= accessLv
            //                select element;

            //MessageDialog dialog = new MessageDialog(main_menu.Count().ToString());
            //var result = dialog.ShowAsync();

            //foreach (var menu in main_menu)
            //{
            //    menus.Add(new SubMenu()
            //    {
            //        MenuItem = menu.Element("MenuName").Value,
            //        Page = menu.Element("Page").Value
            //    });
            //}

            return menus;
        }
    }
}
