namespace ProductEvolutionV1._3.Core.Site
{
    internal class SiteSettings : IParserSettings
    {
        public SiteSettings(string nameItem)
        {
            NameItem = nameItem;
        }
        public string BaseUrl { get; set; } = "https://www.avito.ru";
        public string Prefix { get; set; } = "rossiya?q=";
        public string NameItem { get; set; }

    }
}
