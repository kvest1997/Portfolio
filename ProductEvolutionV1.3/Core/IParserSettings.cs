using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductEvolutionV1._3.Core
{
    interface IParserSettings
    {
        string BaseUrl { get; set; }
        string Prefix { get; set; }
        string NameItem { get; set; }
    }
}
