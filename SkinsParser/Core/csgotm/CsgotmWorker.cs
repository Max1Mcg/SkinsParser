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
        private CsgotmSettings csgotmSettings;
        public CsgotmWorker(string name, string quality)
        {
            csgotmSettings = new CsgotmSettings(name, quality);
        }
        //example add
        public string GetItem(string MarketHashName)
        {
            var SbfullUrl = new StringBuilder();
            SbfullUrl.Append(csgotmSettings.Url);
            SbfullUrl.Append(csgotmSettings.ApiVersion);
            SbfullUrl.Append($"search-item-by-hash-name?key={csgotmSettings.SecurityKey}&hash_name={MarketHashName}");
            var fullUrl = SbfullUrl.ToString();
            var client = new HttpClient();
            var content = client.GetStringAsync(fullUrl);   
            JObject json = JObject.Parse(content.Result);
            return(json["data"][0].ToString());
        }
    }
}
