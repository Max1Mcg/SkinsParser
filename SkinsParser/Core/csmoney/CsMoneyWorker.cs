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
        public CsMoneyWorker(string weapon, string quality, string skin)
        {
            ChangeQuality(ref quality);
            csMoneySettings = new CsMoneySettings(weapon, quality, skin);
        }
        //method to replace quality(Field-Tested as ft for example)
        void ChangeQuality(ref string quality)
        {
            var twoSymbols = new string[2];
            if (quality.Contains(' '))
            {
                twoSymbols = quality.Split(' ');
            }
            else
            {
                twoSymbols = quality.Split('-');
            }
            quality = Convert.ToString(Char.ToLower(twoSymbols[0][0])) + Convert.ToString(Char.ToLower(twoSymbols[1][0]));
        }
        public async Task<string> GetItem()
        {
            using (var client = new HttpClient())
            {
                var content = await client.GetStringAsync($"https://cs.money/1.0/market/sell-orders?limit=1&name={csMoneySettings.Name}%20{csMoneySettings.Skin}&order=asc&quality={csMoneySettings.Quality}&sort=price");
                var domParser = new HtmlParser();
                var document = await domParser.ParseDocumentAsync(content);
                JObject json = JObject.Parse(content);
                double dollarSum = ((double)json["items"][0]["pricing"]["computed"]);
                var dollarRate = await DollarRate.GetDollarRate();
                return Math.Round(dollarRate * dollarSum, 2).ToString();
            }
        }
        public string GetURL()
        {
            return csMoneySettings.Url;
        }
    }
}
