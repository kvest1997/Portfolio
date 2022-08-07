using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductEvolutionV1._3.Core
{
    class HtmlLoader
    {
        readonly HtmlWeb htmlWeb;
        readonly string url;
        public HtmlLoader(IParserSettings settings)
        {
            htmlWeb = new HtmlWeb();
            htmlWeb.OverrideEncoding = Encoding.UTF8;
            url = $"{settings.BaseUrl}/{settings.Prefix}{settings.NameItem}";
        }

        public HtmlDocument GetSourceByItem()
        {
            var currentUrl = url;

            var response = htmlWeb.Load(currentUrl);
            HtmlDocument source = null;


            if (response != null && htmlWeb.StatusCode == System.Net.HttpStatusCode.OK)
            {
                source = response;
            }

            return source;
        }
    }
}
