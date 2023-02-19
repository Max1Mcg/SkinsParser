using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SkinsParser.Core.csgotm
{
    internal class CsgotmSettings : ISiteSettings, IItemSettings
    {
        public string Url { get; } = "https://market.csgo.com/";
        public string Name { get; set; }
        public string Quality { get; set; }
        public string Skin { get; set; }
        public string ApiVersion { get; set; } = "api/v2/";
        public string SecurityKey { get; set; } = "PiCf6sP5Kb0v64aiff9CaCBr66XEw22";
        public CsgotmSettings()
        {
            Name = default(string);
            Quality = default(string);
            Skin = default(string);
        }
        public CsgotmSettings(string name, string quality, string skin)
        {
            Name = name;
            Quality = quality;
            Skin = skin;
        }
    }
}
