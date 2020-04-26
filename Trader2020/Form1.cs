using PowerTrader.Enumerator;
using PowerTrader.Model;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Dynamic;
using System.Linq;
using System.Windows.Forms;

namespace Trader2020
{
    public partial class Form1 : Form
    {
        //public PriceData Data = new PriceData(); 
        public Form1()
        {
            InitializeComponent();
            
        }

        private async void button1_Click(object sender, EventArgs e)
        {
              DoLoadJob();
               
        }
        private async void DoLoadJob()
        {
            var a = new PowerTrader.Class.AlphaVantageDataRetreiver();
            var Request = new DataRequest("AAPL", SecurityType.STOCK ,  BarSize.DAY);
            //Data = new PriceData(Request);
            


            var Data = await a.GetHistoricalDataAsync(Request);
            


            var result = Data.SecurityPriceData 
                .Select(r => new
                {
                    r.PriceDate,
                    r.Open,
                    r.High,
                    r.Low,
                    r.Close,
                    r.Volume
                }).ToList();

            dataGridView1.DataSource = result;
            MessageBox.Show(Data.SecurityPriceData.Count + " records retreived");
        }

         
         

        private void Form1_Load(object sender, EventArgs e)
        {
            //Data.PriceDataChanged  += Data_PriceDataChanged1;
        }

        private void Data_PriceDataChanged1(object sender, NotifyCollectionChangedEventArgs e)
        {
            MessageBox.Show("Happened");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dictionary<DateTime,string> Values = new Dictionary<DateTime, string>();
            Values[new DateTime(2020,12,1,1,1,1)] = "FIRST DEC";
            Values[new DateTime(2020, 10, 1, 1, 1, 1)] = "FIRST OCT";
            Values[new DateTime(2020, 9, 1, 1, 1, 1)] = "FIRST SEP";
            Values[new DateTime(2020, 11, 1, 1, 1, 1)] = "FIRST NOV";
            List<DateTime> z = new List<DateTime>(Values.Keys).Where(d=> d < new DateTime(2020, 9, 1, 1, 1, 1)).ToList();
            z.Sort((x, y) => (-1) * DateTime.Compare(x, y));
            DateTime PreviousTime = z.FirstOrDefault();

            MessageBox.Show(Values[PreviousTime]);
        }
    }
}
