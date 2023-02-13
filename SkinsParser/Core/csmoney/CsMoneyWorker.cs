using AngleSharp.Html.Parser;
using Newtonsoft.Json.Linq;
using SkinsParser.Core.csgotm;
using SkinsParser.Core.csmoney.cb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


namespace SkinsParser.Core.csmoney
{
    internal class CsMoneyWorker
    {
        private CsMoneySettings csMoneySettings;
        public CsMoneyWorker(string name, string quality)
        {
            csMoneySettings = new CsMoneySettings(name, quality);
        }
        //example MarketName = M4A4%20Neo-Noir
        public async Task<double> GetItem(string MarketName)
        {
            var client = new HttpClient();
            //OLD = https://cs.money/1.0/market/sell-orders?limit=1&name=M4A4%20Neo-Noir&order=asc&quality=bs&sort=price
            var content = await client.GetStringAsync($"https://cs.money/1.0/market/sell-orders?limit=1&name={MarketName.Substring(0, MarketName.IndexOf('%'))}%{MarketName.Substring(MarketName.IndexOf('%') +1, MarketName.Length - MarketName.IndexOf('%') - 1)}&order=asc&quality=bs&sort=price");
            var domParser = new HtmlParser();
            var document = await domParser.ParseDocumentAsync(content);
            JObject json = JObject.Parse(content);
            double dollarSum = ((double)json["items"][0]["pricing"]["computed"]);
            var dollarRate = await DollarRate.GetDollarRate();
            return dollarRate * dollarSum;
        }
    }
}
