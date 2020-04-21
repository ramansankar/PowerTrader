using PowerTrader.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Trader2020
{
    public partial class Form1 : Form
    {
        List<DataBar> Data = new List<DataBar>();
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
            Data = await a.GetHistoricalDataAsync(PowerTrader.Enumerator.SecurityType.STOCK, "AAPL", PowerTrader.Enumerator.BarSize.DAY, null);


            var result = Data
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
            MessageBox.Show(Data.Count + " records retreived");
        }

        

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
