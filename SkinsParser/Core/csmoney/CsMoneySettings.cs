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
        public string Url { get; }= "https://cs.money/";

        public string Name { get; set; }
        public string Quality { get; set; }
        public string Skin { get; set; }
        public CsMoneySettings()
        {
            Name = default(string);
            Quality = default(string);
            Skin = default(string);
        }
        public CsMoneySettings(string name, string quality, string skin)
        {
            Name = name;
            Quality = quality;
            Skin = skin;
        }
    }
}
