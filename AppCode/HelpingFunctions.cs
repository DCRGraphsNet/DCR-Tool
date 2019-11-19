using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DCRTasksTool.AppCode
{
    class HelpingFunctions
    {
        public static List<Events> ParseXML(XmlDocument doc)
        {
            List<Events> lst = new List<Events>();
            XmlNodeList nodeList = doc.SelectNodes(".//events/event");
            foreach (XmlNode node in nodeList)
            {
                Events ev = new Events();
                ev.EventName = node.Attributes["id"].Value;
                ev.IsIncluded = node.Attributes["included"].Value;
                ev.IsEnabled = node.Attributes["enabled"].Value;
                ev.IsPending = node.Attributes["pending"].Value;
                ev.IsExecuted = node.Attributes["executed"].Value;
                lst.Add(ev);
            }
            return lst;
        }

        public static XmlDocument GetEventsXmlDocumentFromString(string evXML)
        {
            XmlDocument eventXML = new XmlDocument();
            evXML = evXML.Replace("\\r\\n", "").Replace("\\\"", "\"").Replace("\"<events", "<events").Replace("</events>\"", "</events>");
            eventXML.LoadXml(evXML);
            return eventXML;
        }

        public static bool checkSuccessExecute(string xml, ref string error)
        {
            bool isSuccess = false;
            xml = xml.Replace("\\\"", "\"").Replace("\"<executionResult","<executionResult").Replace("</executionResult>\"", "</executionResult>");
            XmlDocument doc = new XmlDocument();
            try
            {
                doc.LoadXml(xml);
                XmlNodeList nodeList = doc.SelectNodes(".//executionResult/accepted");
                foreach (XmlNode node in nodeList)
                {
                    if (node.InnerText == "1")
                    {
                        isSuccess = true;
                    }

                }
                if (isSuccess == false)
                {
                    error = doc.SelectSingleNode(".//executionResult/reason").InnerText.Replace("\\r\\n", "");
                }
                else
                {
                    error = string.Empty;
                }
            }
            catch (Exception ex)
            {

                isSuccess = false;
            }

            return isSuccess;
        }

    }
}
