using Newtonsoft.Json.Linq;
using SkinsParser.Core.csgotm;
using SkinsParser.Core.csmoney.cb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SkinsParser.Core.steam_community_market
{
    internal class SteamCommunityMarketWorker
    {
        SteamCommunityMarketSettings steamCommunityMarketSettings = null;
        public SteamCommunityMarketWorker(string weapon, string quality, string skin) {
            steamCommunityMarketSettings = new SteamCommunityMarketSettings(weapon, quality, skin);
        }
        public async Task<string> GetItem()
        {
            var personalUrlForItem = $"{steamCommunityMarketSettings.Name}%20%7C%20{steamCommunityMarketSettings.Skin}%20%28{steamCommunityMarketSettings.Quality}%29&currency=1";
            using (var client = new HttpClient())
            {
                var sb = new StringBuilder(steamCommunityMarketSettings.Url);
                sb.Append(steamCommunityMarketSettings.priceViewUrl);
                sb.Append(personalUrlForItem);
                var content = await client.GetStringAsync(sb.ToString());
                var json = JObject.Parse(content);
                return Math.Round(Convert.ToDouble(json["lowest_price"].ToString().Substring(1).Replace('.', ',')) * (await DollarRate.GetDollarRate()), 2).ToString();
            }
        }
        public string GetURL()
        {
            return steamCommunityMarketSettings.Url;
        }
    }
}
