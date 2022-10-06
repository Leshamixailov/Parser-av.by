using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Парсер
{
    internal class HtmlLoader
    {
        readonly HttpClient client;
        readonly string Url;
        public HtmlLoader(IParserSettings settings)
        {
            client = new HttpClient();
            Url = $"{settings.BaseURL}?{settings.Prefix}";
        }
        public async Task<string> GetSourceByPageId(int id)
        {
            var countUrl = Url.Replace("{CurrentId}", id.ToString());
            var response = await client.GetAsync(countUrl);
            string source = null;
            if (response != null && response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                source=await response.Content.ReadAsStringAsync();
            }
            return source;
        }
    }
}
