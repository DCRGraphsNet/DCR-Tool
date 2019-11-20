using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;


namespace DCRTasksTool.AppCode
{
    class FunctionalityFromRepository
    {
        static string SiteURL = System.Configuration.ConfigurationSettings.AppSettings["SiteUrl"];
        public static string GetDCRXML(string graphID)
        {
            string result = string.Empty;
            string GetXMLURL = string.Format("{0}/api/graphs/{1}", SiteURL, graphID);

            // Create the web request  
            HttpWebRequest request = WebRequest.Create(GetXMLURL) as HttpWebRequest;
            request.Method = "GET";
            request.Headers["Authorization"] = getPasswordForAuthentication();
            // request.Headers["Authorization"] = ("Basic " + Convert.ToBase64String(Encoding.Default.GetBytes("ahtesham:ahtesham")));
            // Get response  
            try
            {
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    StreamReader reader = new StreamReader(response.GetResponseStream());
                    result = reader.ReadToEnd();
                }
            }
            catch (Exception ex)
            {

                result = string.Empty;
            }

            return result.ToString();
        }


        public static string IntializeDCRXML(string graphID, ref string error)
        {
            string simulationID = string.Empty;
            string PosTinitURL = string.Format("{0}/api/graphs/{1}/sims", SiteURL, graphID);

            // Create the web request  
            HttpWebRequest request = WebRequest.Create(PosTinitURL) as HttpWebRequest;
            request.Headers["Authorization"] = getPasswordForAuthentication();
            request.Method = "POST";
            request.ContentLength = 0;

            // Get response  
            try
            {
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;

                using (response)
                {
                    simulationID = response.Headers["X-DCR-simulation-ID"].ToString();
                }
            }
            catch (WebException webex)
            {
                WebResponse errResp = webex.Response;
                using (Stream respStream = errResp.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(respStream);
                    error = reader.ReadToEnd();
                }

                //throw;
            }

            return simulationID.ToString();
        }



        public static string GetEventXML(string graphID, string simID, ref string error)
        {
            string result = string.Empty;
            string PosTinitURL = string.Format("{0}/api/graphs/{1}/sims/{2}/events?filter=all", SiteURL, graphID, simID);

            // Create the web request  
            HttpWebRequest request = WebRequest.Create(PosTinitURL) as HttpWebRequest;
            request.Headers["Authorization"] = getPasswordForAuthentication();
            request.Method = "GET";

            // Get response  
            //using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            //{
            //    StreamReader reader = new StreamReader(response.GetResponseStream());
            //    result = reader.ReadToEnd();
            //}

            try
            {
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;

                using (response)
                {
                    StreamReader reader = new StreamReader(response.GetResponseStream());
                    result = reader.ReadToEnd();
                }
            }
            catch (WebException webex)
            {
                WebResponse errResp = webex.Response;
                using (Stream respStream = errResp.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(respStream);
                    error = reader.ReadToEnd();
                }

                //throw;
            }

            return result.ToString();
        }

        public static string GetGraphInstance(string graphID, string simID)
        {
            string result = string.Empty;
            string PosTinitURL = string.Format("{0}/api/graphs/{1}/sims/{2}", SiteURL, graphID, simID);

            // Create the web request  
            HttpWebRequest request = WebRequest.Create(PosTinitURL) as HttpWebRequest;
            request.Headers["Authorization"] = getPasswordForAuthentication();
            request.Method = "GET";

            // Get response  
            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                StreamReader reader = new StreamReader(response.GetResponseStream());
                result = reader.ReadToEnd();
            }

            return result.ToString();
        }


        public static bool GetIsAccepting(string graphID, string simID)
        {
            string result = string.Empty;
            string PosTinitURL = string.Format("{0}/api/graphs/{1}/sims/{2}?filter=IsAccepting", SiteURL, graphID, simID);

            // Create the web request  
            HttpWebRequest request = WebRequest.Create(PosTinitURL) as HttpWebRequest;
            request.Headers["Authorization"] = getPasswordForAuthentication();
            request.Method = "GET";

            // Get response  
            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                StreamReader reader = new StreamReader(response.GetResponseStream());
                result = reader.ReadToEnd();
            }
            if (result.ToString() == "true")
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public static List<Events> GetExecutedEvents(string graphID, string simID, string eventName, ref string error)
        {
            List<Events> lst = new List<Events>();
            string PostInitURL = string.Format("{0}/api/graphs/{1}/sims/{2}/events/{3}", SiteURL, graphID, simID, eventName);

            // Create the web request  
            HttpWebRequest request = WebRequest.Create(PostInitURL) as HttpWebRequest;
            request.Headers["Authorization"] = getPasswordForAuthentication();
            request.ContentType = "application/json";
            request.Method = "POST";
            request.ContentLength = 0;
            try
            {
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;

                if (response.StatusCode == HttpStatusCode.NoContent)
                {
                    // Get response  
                    using (response)
                    {
                        var a = 0;
                    }

                    string evXML = GetEventXML(graphID, simID, ref error);
                    lst = HelpingFunctions.ParseXML(HelpingFunctions.GetEventsXmlDocumentFromString(evXML));

                }
            }

            catch (WebException webex)
            {
                WebResponse errResp = webex.Response;
                using (Stream respStream = errResp.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(respStream);
                    error = reader.ReadToEnd();
                }
            }
            return lst;
        }


        public static List<Events> GetAllEvents(string id, ref string SimID, ref string error)
        {
            List<Events> lst = new List<Events>();
            string simulationID = IntializeDCRXML(id, ref error);

            if (string.IsNullOrWhiteSpace(error))
            {
                string evXML = GetEventXML(id, simulationID, ref error);
                if (string.IsNullOrWhiteSpace(error))
                {
                    SimID = simulationID;
                    lst = HelpingFunctions.ParseXML(HelpingFunctions.GetEventsXmlDocumentFromString(evXML));
                }
            }

            return lst;
        }

        private static string getPasswordForAuthentication(string userName = "", string Password = "")
        {
            if (string.IsNullOrWhiteSpace(userName) == false && string.IsNullOrWhiteSpace(Password) == false)
            {
                return ("Basic " + Convert.ToBase64String(Encoding.Default.GetBytes(string.Format("{0}:{1}", userName, Password))));
            }
            else
            {
                return ("Basic " + Convert.ToBase64String(Encoding.Default.GetBytes(string.Format("{0}:{1}", CommonSetting.UserName, CommonSetting.Password))));
            }
        }


        public static bool GetAccess(string userName, string password, ref string error)
        {
            bool isAccess = false;
            string GetXMLURL = string.Format("{0}/api/graphs", SiteURL);

            // Create the web request  
            HttpWebRequest request = WebRequest.Create(GetXMLURL) as HttpWebRequest;
            request.Method = "GET";
            request.Headers["Authorization"] = getPasswordForAuthentication(userName, password);
            // Get response  

            try
            {
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    isAccess = true;
                }
            }
            catch (Exception ex)
            {
                if (((System.Net.WebException)ex).Response != null)
                {
                    HttpStatusCode code = ((System.Net.HttpWebResponse)((System.Net.WebException)ex).Response).StatusCode;
                    if (code == HttpStatusCode.Forbidden)
                    {
                        isAccess = false;
                    }
                }
                else
                {
                    error = "Unable to connect to DCR , please contact Admin";
                    isAccess = false;
                }
            }
            return isAccess;

        }

        public static List<Events> GetLatestEvents(string id, string SimID, ref string error)
        {
            string evXML = GetEventXML(id, SimID, ref error);
            List<Events> lst = HelpingFunctions.ParseXML(HelpingFunctions.GetEventsXmlDocumentFromString(evXML));
            return lst;
        }


    }
}
