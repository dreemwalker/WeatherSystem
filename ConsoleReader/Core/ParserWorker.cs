using AngleSharp.Html.Parser;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleReader.Core
{
    class ParserWorker<T> where T:class
    {
        HtmlLoader _loader;
        IParserSettings _settings;
        IParser<T> _parser;
        public ParserWorker(IParserSettings settings,IParser<T> parser)
        {
            _settings = settings;
            _parser = parser;
            _loader = new HtmlLoader(_settings);
        }

        public async Task<IEnumerable<T>> DoWork()
        {
            var source = await _loader.GetPage();
            var domParser = new HtmlParser();
            var document = await domParser.ParseDocumentAsync(source);
            var parsedList = _parser.Parse(document);
            return parsedList.ToList();
        }
        //public async void DoWork()
        //{
        //    var source = await _loader.GetPage();
        //    var domParser = new HtmlParser();
        //    var document = await domParser.ParseDocumentAsync(source);
        //    var parsedList = _parser.Parse(document);
        // //   return parsedList.ToList();
        //}
    }
}
