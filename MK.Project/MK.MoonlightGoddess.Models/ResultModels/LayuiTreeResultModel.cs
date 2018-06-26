using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MK.MoonlightGoddess.Models.ResultModels
{
    public class LayuiTreeResultModel
    {
        public string id { get; set; }
        public string name { get; set; }
        public List<LayuiTreeResultModel> children { get; set; }
    }
    public class TextTree
    {
        public List<LayuiTreeResultModel> result { get; set; }
        public List<LayuiTreeResultModel> PowerGroup(System.Data.DataTable data)
        {
            List<LayuiTreeResultModel> result = new List<LayuiTreeResultModel>();
            LayuiTreeResultModel nodes = new LayuiTreeResultModel();
            DataRow root = data.Select("id='00000000-0000-0000-0000-000000000000'")[0];
            nodes.id = root["id"].ToString();
            nodes.name = root["name"].ToString();
            List<LayuiTreeResultModel> outList = null;
            AddChildren(data, root["id"].ToString(), out outList);
            nodes.children = outList;
            result.Add(nodes);
            return result;
        }
        public void AddChildren(DataTable data,string pId,out List<LayuiTreeResultModel> outList)
        {
            List<LayuiTreeResultModel> _root = new List<LayuiTreeResultModel>();
            System.Data.DataRow[] nodes = data.Select("onid='" + pId + "'");
            foreach (System.Data.DataRow row in nodes)
            {
                LayuiTreeResultModel node = new LayuiTreeResultModel();
                node.id = row["id"].ToString();
                node.name = row["name"].ToString();
                List<LayuiTreeResultModel> _outList = null;
                AddChildren(data, row["id"].ToString(), out _outList);
                node.children = _outList;
                _root.Add(node);
            }
            outList = _root;
        }
    }

    public class NavigationbarTree
    {
        public List<LayuiTreeResultModel> result { get; set; }
        public List<LayuiTreeResultModel> Navigation(System.Data.DataTable data)
        {
            List<LayuiTreeResultModel> result = new List<LayuiTreeResultModel>();
            LayuiTreeResultModel nodes = new LayuiTreeResultModel();
            nodes.id = "00000000-0000-0000-0000-000000000000";
            nodes.name = "导航栏";
            List<LayuiTreeResultModel> outList = null;
            AddChildren(data, nodes.id, out outList);
            nodes.children = outList;
            result.Add(nodes);
            return result;
        }
        public void AddChildren(DataTable data, string pId, out List<LayuiTreeResultModel> outList)
        {
            List<LayuiTreeResultModel> _root = new List<LayuiTreeResultModel>();
            System.Data.DataRow[] nodes = data.Select();
            foreach (System.Data.DataRow row in nodes)
            {
                LayuiTreeResultModel node = new LayuiTreeResultModel();
                node.id = row["id"].ToString();
                node.name = row["name"].ToString();
                List<LayuiTreeResultModel> _outList = null;
                //AddChildren(data, row["id"].ToString(), out _outList);
                node.children = _outList;
                _root.Add(node);
            }
            outList = _root;
        }
    }
}
