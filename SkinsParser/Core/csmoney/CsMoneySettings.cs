using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace SkinsParser.Core.csmoney
{
    internal class CsMoneySettings : ISiteSettings, IItemSettings
    {
        public string Url { get; }= "https://cs.money/1.0/market/sell-orders?limit=1";

        public string Name { get; set; }
        public string Quality { get; set; }
        public CsMoneySettings()
        {
            Name = default(string);
            Quality = default(string);
        }
        public CsMoneySettings(string name, string quality)
        {
            Name = name;
            Quality = quality;
        }
    }
}
