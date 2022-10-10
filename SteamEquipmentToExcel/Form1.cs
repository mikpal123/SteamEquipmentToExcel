using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.Json;
using System.Net.Http;


namespace SteamEquipmentToExcel
{
    public partial class Form1 : Form
    {

        public List<string> marketValues = new List<string>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            debugOutput("open");
        }

        private void generate_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(text_Id.Text))
            {
                DownloadEqupment(text_Id);
            }
        }

        private void DownloadEqupment(TextBox name)
        {
            statusBox.BackColor = Color.Red;
            RestCient rClient = new RestCient();
            PriceClient pClient = new PriceClient();

            rClient.endPoint = name.Text;

            string strITEM = string.Empty;

            string strJSON = string.Empty;
            strJSON = rClient.makeRequest();
            

            FileStream fs = File.Create(filePathBox.Text + "\\SteamEquipment.txt");
            var praseString = System.Text.Json.JsonDocument.Parse(strJSON);

            byte[] firstLine = new UTF8Encoding(true).GetBytes("Nazwa przedmotu;Najniższa cena;Średnia cena;Moja najniższa cena;Moja średnia cena");
            fs.Write(firstLine, 0, firstLine.Length);
            byte[] enter = Encoding.ASCII.GetBytes(Environment.NewLine);
            fs.Write(enter, 0, enter.Length);

            for (int i = 0; i < praseString.RootElement.GetProperty("descriptions").GetArrayLength(); i++)
            {              
                marketValues.Add(praseString.RootElement.GetProperty("descriptions")[i].GetProperty("market_hash_name").ToString());
                ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                pClient.endPoint = praseString.RootElement.GetProperty("descriptions")[i].GetProperty("market_hash_name").ToString();
                

                string stritem = string.Empty; 
                stritem = pClient.makeRequest();

                string itemName;
                string lowestPrice;
                string myLowestPrice;
                string medianPrice;
                string myMedianPrice;



                Item item = JsonSerializer.Deserialize<Item>(pClient.makeRequest());
                item.deleteZl();


                if (item.lowest_price != null)
                {                   
                    lowestPrice = item.lowest_price;
                    float val = Convert.ToSingle(item.lowest_price) * 0.7f;
                    int intVal = (int)val;
                    myLowestPrice = intVal.ToString();
                }
                else 
                {
                    lowestPrice = "";
                    myLowestPrice = "";
                }


                if(item.median_price != null)
                {
                    medianPrice = item.median_price;
                    float val = Convert.ToSingle(item.median_price) * 0.7f;
                    int intVal = (int)val;
                    myMedianPrice = intVal.ToString();
                }
                else
                {
                    medianPrice = "";
                    myMedianPrice = "";
                }

                itemName= marketValues[i];




                byte[] info = new UTF8Encoding(true).GetBytes(itemName + ";" + lowestPrice + ";" + medianPrice + ";" + myLowestPrice + ";" + myMedianPrice);
                fs.Write(info, 0, info.Length);
                byte[] newline = Encoding.ASCII.GetBytes(Environment.NewLine);
                fs.Write(newline, 0, newline.Length);

                debugOutput("pauza");
                System.Threading.Thread.Sleep(5000);
            }
            statusBox.BackColor = Color.Green;
            debugOutput("koniec");
        }

        private void debugOutput(string strDebugText)
        {
            try
            {
                System.Diagnostics.Debug.Write(strDebugText + Environment.NewLine);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Write(ex.Message, ToString() + Environment.NewLine);
            }
        }

        private void filePathButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog open = new FolderBrowserDialog();

            if (open.ShowDialog() == DialogResult.OK)
            {
                filePathBox.Text = open.SelectedPath;
            }
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
