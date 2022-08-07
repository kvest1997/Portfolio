using HtmlAgilityPack;

namespace ProductEvolutionV1._3.Core
{
    interface IParser<T> where T: class
    {
        T Parse(HtmlDocument htmlDocument);
    }
}
