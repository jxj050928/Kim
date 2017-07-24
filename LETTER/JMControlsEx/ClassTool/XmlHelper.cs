using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace JMControlsEx
{
    internal class XmlHelperEx
    {
        internal static void CreateXML(string path)
        {
            //初始化一个xml实例
            XmlDocument myXmlDoc = new XmlDocument();
            //创建xml的根节点
            XmlElement rootElement = myXmlDoc.CreateElement("DataGridViewColumns");
            //将根节点加入到xml文件中(AppendChild)
            myXmlDoc.AppendChild(rootElement);

            myXmlDoc.Save(path);
        }

        // Methods
        internal static void Delete(string path, string node, string attribute)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(path);
                XmlNode xn = doc.SelectSingleNode(node);
                XmlElement xe = (XmlElement)xn;
                if (attribute.Equals(""))
                {
                    xn.ParentNode.RemoveChild(xn);
                }
                else
                {
                    xe.RemoveAttribute(attribute);
                }
                doc.Save(path);
            }
            catch
            {
            }
        }

        internal static void Insert(string path, string node, string element, string attribute, string value)
        {
            try
            {
                XmlElement xe;
                XmlDocument doc = new XmlDocument();
                doc.Load(path);
                XmlNode xn = doc.SelectSingleNode(node);
                if (element.Equals(""))
                {
                    if (!attribute.Equals(""))
                    {
                        xe = (XmlElement)xn;
                        xe.SetAttribute(attribute, value);
                    }
                }
                else
                {
                    xe = doc.CreateElement(element);
                    if (attribute.Equals(""))
                    {
                        xe.InnerText = value;
                    }
                    else
                    {
                        xe.SetAttribute(attribute, value);
                    }
                    xn.AppendChild(xe);
                }
                doc.Save(path);
            }
            catch
            {
            }
        }

        internal static string Read(string path, string node, string attribute)
        {
            string value = "";
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(path);
                XmlNode xn = doc.SelectSingleNode(node);
                value = attribute.Equals("") ? xn.InnerText : xn.Attributes[attribute].Value;
            }
            catch
            {
            }
            return value;
        }

        internal static void Update(string path, string node, string attribute, string value)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(path);
                XmlElement xe = (XmlElement)doc.SelectSingleNode(node);
                if (attribute.Equals(""))
                {
                    xe.InnerText = value;
                }
                else
                {
                    xe.SetAttribute(attribute, value);
                }
                doc.Save(path);
            }
            catch
            {
            }
        }
    }
}
