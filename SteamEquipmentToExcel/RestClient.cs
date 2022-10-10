using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Threading.Tasks;

namespace SteamEquipmentToExcel
{
    public enum httpVerbs
    {
        GET,
        POST,
        PUT,
        DELETE,
    }

    class RestCient
    {
        public string webAdress1 { get; set; }
        public string webAdress2 { get; set; }
        public string endPoint { get; set; }
        public httpVerbs httpMethod { get; set; }

        public RestCient()
        {
            endPoint = String.Empty;
            webAdress1 = "https://steamcommunity.com/inventory/";
            webAdress2 = "/730/2?l=english&count=5000";
            httpMethod = httpVerbs.GET;
        }

        public string makeRequest()
        {
            string strResponseValue = string.Empty;
            string finalWebAdress = webAdress1 + endPoint + webAdress2;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(finalWebAdress);

            request.UserAgent = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 6.0; WOW64; " +
                "Trident/4.0; SLCC1; .NET CLR 2.0.50727; Media Center PC 5.0; " +
                ".NET CLR 3.5.21022; .NET CLR 3.5.30729; .NET CLR 3.0.30618; " +
                "InfoPath.2; OfficeLiveConnector.1.3; OfficeLivePatch.0.0)";
            request.Method = httpMethod.ToString();

            HttpWebResponse response = null;

            try
            {
                response = (HttpWebResponse)request.GetResponse();


                using (Stream responseStream = response.GetResponseStream())
                {
                    if (responseStream != null)
                    {
                        using (StreamReader reader = new StreamReader(responseStream))
                        {
                            strResponseValue = reader.ReadToEnd();

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                strResponseValue = "{\"errorMessages\":[\"" + ex.Message.ToString() + "\"],\"errors\":{}}";
            }
            finally
            {
                if (response != null)
                {
                    ((IDisposable)response).Dispose();
                }
            }

            return strResponseValue;
        }

    }
}
