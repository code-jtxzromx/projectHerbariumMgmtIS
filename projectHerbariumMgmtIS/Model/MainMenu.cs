using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace projectHerbariumMgmtIS.Model
{
    public class MainMenu
    {
        // Properties
        public string Menu { get; set; }
        public string TagPage { get; set; }
        public string GlyphCode { get; set; }

        // Constructor
        public MainMenu()
        {
            this.Menu = "";
            this.TagPage = "";
            this.GlyphCode = "";
        }

        public List<MainMenu> GetMenus()
        {
            int accessLv = (StaticAccess.Role == "ADMINISTRATOR") ? 3 : ((StaticAccess.Role == "CURATOR") ? 2 : 1);
            List<MainMenu> menus = new List<MainMenu>();

            DatabaseConnection connection = new DatabaseConnection();
            connection.setQuery("SELECT strMainMenu, strPageLocation, strGlyphCode " +
                                "FROM tblSystemMenu " +
                                "WHERE strLevel = 'A' AND intAccessLevel <= @accessLevel");
            connection.addQueryParameter("@accessLevel", SqlDbType.VarChar, accessLv);
            SqlDataReader sqlData = connection.executeResult();

            while (sqlData.Read())
            {
                menus.Add(new MainMenu()
                {
                    Menu = sqlData[0].ToString(),
                    TagPage = sqlData[1].ToString(),
                    GlyphCode = sqlData[2].ToString()
                });
            }
            connection.closeResult();

            //XElement xelement = XElement.Load("Model\\MainMenu.xml");
            //var main_menu = from element in xelement.Elements("MainMenu")
            //                where (int)element.Element("AccessLevel") <= accessLv
            //                select element;

            //foreach (var menu in main_menu)
            //{
            //    menus.Add(new MainMenu()
            //    {
            //        Menu = menu.Element("MenuName").Value,
            //        TagPage = menu.Element("Page").Value,
            //        GlyphCode = menu.Element("Icon").Value
            //    });
            //}

            return menus;
        }
    }
}
