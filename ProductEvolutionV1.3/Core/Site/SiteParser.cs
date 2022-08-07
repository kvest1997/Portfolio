using HtmlAgilityPack;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductEvolutionV1._3.Core.Site
{
    internal class SiteParser : IParser<string[]>
    {
        public string[] Parse(HtmlDocument htmlDocument)
        {
            var title = new List<string>();
            var price = new List<string>();
            //Название
            foreach (HtmlNode node in htmlDocument.DocumentNode.SelectNodes("//div[contains(@class, 'iva-item-body-KLUuy')]//a[@title]"))
            {
                title.Add(node.InnerText);
            }
            //цена
            foreach (HtmlNode node in htmlDocument.DocumentNode.SelectNodes("//div[contains(@class, 'iva-item-body-KLUuy')]//span[contains(@class, 'price-text-_YGDY text-text-LurtD text-size-s-BxGpL')]"))
            {
                price.Add(node.InnerText);
            }

            var result = new List<string>();


            for (int i = 0; i < title.Count; i++)
            {
                result.Add($"{title[i]} - {price[i]}");
            }

            return result.ToArray();
        }
    }
}
