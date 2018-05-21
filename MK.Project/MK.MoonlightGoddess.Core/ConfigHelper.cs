﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace MK.MoonlightGoddess.Core
{
    public static class ConfigHelper
    {
        private static string siteroot = System.Web.Hosting.HostingEnvironment.MapPath("~/");

        /// <summary>
        /// 获取配置文件中AppSetting节点的相对路径对应的绝对路径
        /// </summary>
        /// <param name="key">相对路径设置的键值</param>
        /// <returns>绝对路径</returns>
        public static string AppSettingMapPath(string key)
        {
            if (String.IsNullOrEmpty(siteroot))
            {
                siteroot = System.Web.Hosting.HostingEnvironment.MapPath("~/");
            }

            //拼接路径
            string path = siteroot + ConfigurationManager.AppSettings[key].ToString();
            return path;
        }

        /// <summary>
        /// 将虚拟路径转换为物理路径
        /// </summary>
        /// <param name="virtualPath">虚拟路径</param>
        /// <returns>虚拟路径对应的物理路径</returns>
        public static string MapPath(string virtualPath)
        {
            if (String.IsNullOrEmpty(siteroot))
            {
                siteroot = System.Web.Hosting.HostingEnvironment.MapPath("~/");
            }

            //拼接路径
            string path = siteroot + virtualPath;
            return path;
        }

        /// <summary>
        /// 获取配置文件中AppSetting节点的值
        /// </summary>
        /// <param name="key">设置的键值</param>
        /// <returns>键值对应的值</returns>
        public static string AppSetting(string key) => ConfigurationManager.AppSettings[key].ToString();

        /// <summary>
        /// 获取配置文件中ConnectionStrings节点的值
        /// </summary>
        /// <param name="key">键值</param>
        /// <returns>键值对应的连接字符串值</returns>
        public static string ConnectionString(string key) => System.Configuration.ConfigurationManager.ConnectionStrings[key].ConnectionString;

        public static bool UpdateAppSettings(string key, string value)
        {
            string filename = System.Web.Hosting.HostingEnvironment.MapPath("~/web.config");
            XmlDocument xmldoc = new XmlDocument();
            try
            {
                xmldoc.Load(filename);
            }
            catch (Exception)
            {
                return false;
            }

            XmlNodeList DocdNodeNameArr = xmldoc.DocumentElement.ChildNodes;//文档节点名称数组

            foreach (XmlElement element in DocdNodeNameArr)
            {
                if (element.Name == "appSettings")//找到名称为 appSettings 的节点
                {
                    XmlNodeList KeyNameArr = element.ChildNodes;//子节点名称数组
                    if (KeyNameArr.Count > 0)
                    {
                        foreach (XmlElement xmlElement in KeyNameArr)
                        {
                            //找到键值，修改为想要修改的值
                            if (xmlElement.Attributes["key"].InnerXml.Equals(key))
                            {
                                xmlElement.Attributes["value"].Value = value;
                                ConfigurationManager.RefreshSection("appSettings");
                                return true;
                            }
                        }
                        //没有相应的节点
                        return false;
                    }
                    else
                    {
                        //不存在 AppSettings 节点
                        return false;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// 将虚拟路径转换为物理路径
        /// </summary>
        /// <param name="virtualPath">虚拟路径</param>
        /// <returns>虚拟路径对应的物理路径</returns>
        public static string MapPath(string virtualPath,bool z = true) => System.Web.Hosting.HostingEnvironment.MapPath("~/") + virtualPath;
    }
}
