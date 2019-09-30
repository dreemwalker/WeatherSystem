using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleReader.Core.Gismeteo
{
    class GismeteoSettings : IParserSettings
    {
        public string baseUrl { get; set; } = "https://www.gismeteo.by/";
        public string targetUrlPart { get; set; } = "";
    }
}
