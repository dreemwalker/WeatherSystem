using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleReader.Core
{
    interface IParserSettings
    {
        string baseUrl  {get; set; }
        string targetUrlPart { get; set; }

    }
}
