using AngleSharp.Html.Dom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleReader.Core
{
    interface IParser<T> where T:class
    {
       IEnumerable<T> Parse(IHtmlDocument document);
       
    }
}
