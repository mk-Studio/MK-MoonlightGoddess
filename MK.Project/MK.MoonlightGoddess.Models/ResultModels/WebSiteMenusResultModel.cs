using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MK.MoonlightGoddess.Models.ResultModels
{
    public class WebSiteMenusResultModel
    {
        public static object GetMenus(DataTable data)
        {
            if (data == null)
                throw new ArgumentNullException(nameof(data));
            List<Navigation>  Navigations = new List<Navigation>();
            DataRowCollection rows = data.Rows;
            for (int i = 0; i < rows.Count; i++)
            {
                var menuString = rows[i]["Menus"].ToString();
                List<Menus> menuList = SerializableMenus(menuString);
                if (menuList.Count == 0)
                    continue;
                Navigation navigation = new Navigation();
                navigation.ID = rows[i]["ID"].ToString();
                navigation.NavigationName = rows[i]["NavigationName"].ToString();
                navigation.Tips = rows[i]["Tips"].ToString();
                navigation.Directio = rows[i]["Directio"].ToString();
                navigation.Menus = menuList;
                Navigations.Add(navigation);
            }
            return Navigations;
        }

        static List<Menus> SerializableMenus(string ms)
        {
            if (string.IsNullOrEmpty(ms))
                return new List<Menus>();
            string[] menuObj = ms.TrimEnd(';').Split(';');
            List<Menus> menus = new List<Menus>();
            for (int i = 0; i < menuObj.Length; i++)
            {
                Menus _menu = new Menus();
                var menu = menuObj[i].ToString().Split(',');
                if (menu.Length < 4)
                    throw new Exception("要序列化的菜单格式不正确。");
                _menu.ID = menu[0];
                _menu.NavigationID = menu[1];
                _menu.PowerName = menu[2];
                _menu.MenuAddress = menu[3];
                menus.Add(_menu);
            }
            return menus;
        }
    }

    public class Navigation
    {
        public string ID { get; set; }
        public string NavigationName { get; set; }
        public List<Menus> Menus { get; set; }
        public string Tips { get; set; }
        public string Directio { get; set; }
    }

    public class Menus
    {
        public string ID { get; set; }
        public string NavigationID { get; set; }
        public string PowerName { get; set; }
        public string MenuAddress { get; set; }
    }
}
