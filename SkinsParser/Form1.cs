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

namespace SkinsParser
{
    public partial class Form1 : Form
    {
        CsgotmWorker csgotm;
        CsMoneyWorker csMoney;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            csgotm = new CsgotmWorker("", "");
            listBox1.Items.Add(csgotm.GetItem("AWP | Worm God (Factory New)"));
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private async void button2_Click(object sender, EventArgs e)
        {
            csMoney = new CsMoneyWorker("", "");
            listBox1.Items.Add(await csMoney.GetItem("M4A4%20Neo-Noir"));
        }
    }
}
