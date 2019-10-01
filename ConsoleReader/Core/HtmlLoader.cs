using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;
using System.IO;
namespace ConsoleReader.Core
{
    class HtmlLoader
    {
        private HttpClient _client;
        private string _baseUrl;
        private string _postfix;
        public HtmlLoader(IParserSettings settings)
        {
            _baseUrl = settings.baseUrl;
            _postfix = settings.targetUrlPart;
            _client = new HttpClient();
        }
        public async Task<string> GetPage()
        {
            var currentUrl = _baseUrl + _postfix;
            var response = await _client.GetAsync(currentUrl);
            string source=null;
            if(response!=null&& response.StatusCode==HttpStatusCode.OK)
            {
                source = await response.Content.ReadAsStringAsync();
            }
            //using (StreamWriter sw = new StreamWriter("1.html"))
            //{
            //    sw.WriteLine(source);
            //}
            return source;
        }
    }
}
