using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;

namespace SkinsParser.Core.csgotm
{
    internal class CsgotmWorker
    {
        CsgotmSettings settings;
        public CsgotmWorker(string name, string quality)
        {
            settings = new CsgotmSettings(name, quality);
        }
        public void GetItem(string MarketHashName)
        {
            var SbfullUrl = new StringBuilder();
            SbfullUrl.Append(settings.Url);
            SbfullUrl.Append(settings.ApiVersion);
            SbfullUrl.Append($"search-item-by-hash-name?key={settings.SecurityKey}&hash_name={MarketHashName}");
            var fullUrl = SbfullUrl.ToString();
            var client = new HttpClient();
            var content = client.GetStringAsync(fullUrl);
            JObject json = JObject.Parse(content.Result);
            Console.WriteLine(json);
        }
    }
}
