using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Threading.Tasks;

namespace SteamEquipmentToExcel
{
    public enum httpVerb
    {
        GET,
        POST,
        PUT,
        DELETE,
    }
    class PriceClient
    {
        public string webAdress { get; set; }
        public string endPoint { get; set; }
        public httpVerbs httpMethod { get; set; }

        public PriceClient()
        {
            endPoint = String.Empty;
            webAdress = "https://steamcommunity.com/market/priceoverview/?currency=6&country=DE&appid=730&market_hash_name=";
            httpMethod = httpVerbs.GET;
        }

        public string makeRequest()
        {
            
            string strResponseValue = string.Empty;
            string finalWebAdress = webAdress + endPoint;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(finalWebAdress);
            request.Headers.Add("api_key", "E620CF7605F2A63A1DEA409C065641C5");
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

        public void wait(int milliseconds)
        {
            var timer1 = new System.Windows.Forms.Timer();
            if (milliseconds == 0 || milliseconds < 0) return;

            // Console.WriteLine("start wait timer");
            timer1.Interval = milliseconds;
            timer1.Enabled = true;
            timer1.Start();

            timer1.Tick += (s, e) =>
            {
                timer1.Enabled = false;
                timer1.Stop();
                // Console.WriteLine("stop wait timer");
            };

            while (timer1.Enabled)
            {
                Application.DoEvents();
            }
        }
    }
    
}
