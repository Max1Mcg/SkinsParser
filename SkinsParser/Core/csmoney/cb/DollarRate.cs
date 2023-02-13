using AngleSharp.Dom;
using AngleSharp.Html.Parser;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SkinsParser.Core.csmoney.cb
{
    internal class DollarRate : ISiteSettings
    {
        public string Url { get; } = "https://www.cbr.ru/";
        public static async Task<double> GetDollarRate()
        {
            var client = new HttpClient();
            var content = await client.GetStringAsync("http://www.cbr.ru/");
            var domParser = new HtmlParser();
            var document = await domParser.ParseDocumentAsync(content);
            var items = document.QuerySelectorAll("div.main-indicator_rate");
            string price = default(string);
            foreach (var v in items)
            {
                if (v.InnerHtml.Contains("col-md-2 col-xs-9 _dollar"))
                {
                    var dollarHtml = await domParser.ParseDocumentAsync(v.InnerHtml);
                    var dollarsRate = dollarHtml.QuerySelectorAll("div").Where(item => item.ClassName != null && item.ClassName.Contains("col-md-2 col-xs-9 _right mono-num"));
                    string rateBuy = dollarsRate.ElementAt<AngleSharp.Dom.IElement>(1).InnerHtml;
                    price = (rateBuy.Substring(0, rateBuy.IndexOf(' ')));
                }
            }
            return Double.Parse(price);
        }
    }
}
