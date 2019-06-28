using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace EchoBot
{
    public static class AzureSearch
    {
        public static async Task<List<DocumentModel>> searchAzureSqlIndexer(List<string> keys)
        {
            string strSearchParam = string.Empty;
            foreach (string key in keys)
            {
                strSearchParam += " " + key;
            }

            var client = new HttpClient();
            var queryString = HttpUtility.ParseQueryString("api-version=2019-05-06&search=" + strSearchParam.Trim());
            var uri = "https://pacificlifesearch.search.windows.net/indexes/azuresql-index/docs?" + queryString;
            client.DefaultRequestHeaders.Add("api-key", "2418B9CE8B9F0C5972667588FBE497B5");

            //client.DefaultRequestHeaders.Add("Content-Type", "application/json");
            //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            //byte[] byteData = Encoding.UTF8.GetBytes("{body}");


            //List<DocumentModel> docNamesResult = new List<DocumentModel>();
            try
            {
                var response = await client.GetAsync(uri);

                var jsonString = await response.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<AzureSearchResultModel>(jsonString);
                return value.values;
            }
            catch(Exception ex)
            {

            }

            return new List<DocumentModel>();
        }
    }
}
