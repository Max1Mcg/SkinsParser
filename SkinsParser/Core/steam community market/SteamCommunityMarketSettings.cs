using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace SkinsParser.Core
{
    internal class SteamCommunityMarketSettings : ISiteSettings, IItemSettings
    {
        public string Url { get; } = "https://steamcommunity.com/market/";
        public string Name { get; set; }
        public string Quality { get; set; }
        public string Skin { get; set; }
        public string priceViewUrl { get; } = "priceoverview/?appid=730&market_hash_name=";
        public SteamCommunityMarketSettings() {
            Name = default(string);
            Quality = default(string);
            Skin = default(string);
        }
        public SteamCommunityMarketSettings(string name, string quality, string skin)
        {
            Name = name;
            Quality = quality;
            Skin = skin;
        }

    }
}
