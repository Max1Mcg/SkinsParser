using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

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
            System.Net.WebRequest reqGET = System.Net.WebRequest.Create(fullUrl);
            System.Net.WebResponse resp = reqGET.GetResponse();
            System.IO.Stream stream = resp.GetResponseStream();
            System.IO.StreamReader sr = new System.IO.StreamReader(stream);
            string s = sr.ReadToEnd();
            Console.WriteLine(s);
        }
    }
}
