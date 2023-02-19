using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;

namespace SkinsParser.Core.csgotm
{
    internal class CsgotmWorker
    {
        private CsgotmSettings csgotmSettings;
        private string MarketHashName;
        public CsgotmWorker(string weapon, string quality, string skin)
        {
            csgotmSettings = new CsgotmSettings(weapon, quality, skin);
            MarketHashName = $"{weapon} | {skin} ({quality})";
        }
        public async Task<string> GetItem()
        {
            var SbfullUrl = new StringBuilder();
            SbfullUrl.Append(csgotmSettings.Url);
            SbfullUrl.Append(csgotmSettings.ApiVersion);
            SbfullUrl.Append($"search-item-by-hash-name?key={csgotmSettings.SecurityKey}&hash_name={MarketHashName}");
            var fullUrl = SbfullUrl.ToString();
            using (var client = new HttpClient())
            {
                var content = await client.GetStringAsync(fullUrl);
                JObject json = JObject.Parse(content);
                var price = json["data"][0]["price"].ToString();
                return (price.Insert(price.Length - 2, ","));
            }
        }
        public string GetURL()
        {
            return csgotmSettings.Url;
        }
    }
}
