using Newtonsoft.Json.Linq;
using SkinsParser.Core.csgotm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AngleSharp.Html.Parser;
using System.Runtime.Remoting.Contexts;
using AngleSharp.Html.Dom;
using System.IO;
using System.Net;
using System.Data.SqlTypes;
using System.Xml.Linq;
using System.Net.Http.Headers;
using System.Net.Mime;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;
using AngleSharp.Io;
using SkinsParser.Core;
using Json.Net;
using System.Numerics;
using SkinsParser.Core.csmoney;
using System.Reactive;
using SkinsParser.Core.steam_community_market;

namespace SkinsParser
{
    delegate DialogResult ErrorMessage(string a, string b, MessageBoxButtons c, MessageBoxIcon d);
    public partial class Form1 : Form
    {
        ErrorMessage errorMessage = MessageBox.Show;
        CsgotmWorker csgotm;
        CsMoneyWorker csMoney;
        SteamCommunityMarketWorker steamCommunityMarketWorker;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = "None";
            Quality.Text = "Field-Tested";
            WeaponName.Text = "AWP";
            SkinName.Text = "Neo-Noir";
            dataGridView1.RowCount = 3;
            dataGridView1.ColumnCount = 3;
            dataGridView1.Columns[0].HeaderCell.Value = "site";
            dataGridView1.Columns[1].HeaderCell.Value = "price";
            dataGridView1.Columns[2].HeaderCell.Value = "URL";
            dataGridView1.Rows[0].Cells[0].Value = "csgotm";
            dataGridView1.Rows[1].Cells[0].Value = "csMoney";
            dataGridView1.Rows[2].Cells[0].Value = "steamMarket";
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Height = dataGridView1.Rows.GetRowsHeight(DataGridViewElementStates.Visible) + 
                dataGridView1.ColumnHeadersHeight;
        }
        private async void button4_Click(object sender, EventArgs e)
        {
            var minPriceUrl = new Tuple<string, double>("None", Double.MaxValue);
            var quality = Quality.Text;
            var weapon = WeaponName.Text;
            var skin = SkinName.Text;
            csgotm = new CsgotmWorker(weapon, quality, skin);
            csMoney = new CsMoneyWorker(weapon, quality, skin);
            steamCommunityMarketWorker = new SteamCommunityMarketWorker(weapon, quality, skin);
            dataGridView1.Rows[0].Cells[2].Value = csgotm.GetURL();
            dataGridView1.Rows[1].Cells[2].Value = csMoney.GetURL();
            dataGridView1.Rows[2].Cells[2].Value = steamCommunityMarketWorker.GetURL();
            try
            {
                dataGridView1.Rows[0].Cells[1].Value = (await csgotm.GetItem());
                Double.TryParse((string)dataGridView1.Rows[0].Cells[1].Value, out double result);
                if (minPriceUrl.Item2 > result)
                    minPriceUrl = new Tuple<string, double>(csgotm.GetURL(), result);
            }
            catch (Exception ex)
            {
                dataGridView1.Rows[0].Cells[1].Value = "None";
                errorMessage(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                dataGridView1.Rows[1].Cells[1].Value = (await csMoney.GetItem());
                Double.TryParse((string)dataGridView1.Rows[1].Cells[1].Value, out double result);
                if (minPriceUrl.Item2 > result)
                    minPriceUrl = new Tuple<string, double>(csMoney.GetURL(), result);
            }
            catch (Exception ex)
            {
                dataGridView1.Rows[1].Cells[1].Value = "None";
                errorMessage(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                dataGridView1.Rows[2].Cells[1].Value = (await steamCommunityMarketWorker.GetItem());
                Double.TryParse((string)dataGridView1.Rows[2].Cells[1].Value, out double result);
                if (minPriceUrl.Item2 > result)
                    minPriceUrl = new Tuple<string, double>(steamCommunityMarketWorker.GetURL(), result);
            }
            catch (Exception ex)
            {
                dataGridView1.Rows[2].Cells[1].Value = "None";
                errorMessage(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            textBox1.Text = minPriceUrl.Item1;
        }
    }
}
