using AngleSharp.Html.Dom;
using System.Collections.Generic;

namespace ConsoleReader.Core
{
    interface IParser<T> where T:class
    {
       IEnumerable<T> Parse(IHtmlDocument document);
       
    }
}
