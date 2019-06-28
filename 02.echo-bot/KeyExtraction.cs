using Microsoft.Extensions.Configuration;
using Microsoft.ProjectOxford.Text.Core;
using Microsoft.ProjectOxford.Text.KeyPhrase;
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
    public static class KeyExtraction
    {
        //public IConfiguration configuration;

        //public KeyExtraction(IConfiguration _configuration)
        //{
        //    configuration = _configuration;
        //}

        public static async Task<List<string>> CallWebAPIAsync(string utterance)
        {
            //var client = new HttpClient();
            //var queryString = HttpUtility.ParseQueryString(String.Empty);



            // Request headers
            //client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", configuration["TextAnalylisisAPIKey"]);
            //client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "3ff10cb8e78442bab6ac035ea5c1630a");
            //client.DefaultRequestHeaders.Add("Accept", "application/json");
            //client.DefaultRequestHeaders.Add("Content-Type", "application/json");

            //var uri = configuration["TextAnalylisisAPIHostName"] + queryString;
            //var uri = "https://westus.api.cognitive.microsoft.com/text/analytics/v2.0/keyPhrases" ;

            //HttpResponseMessage response;
            //string body = "'documents': [{'language':'en','id':'1','text':'We love this trail and make the trip every year. The views are breathtaking and well worth the hike!'}]";
            //string body = "documents: [{language:en,id:1,text:We love this trail and make the trip every year. The views are breathtaking and well worth the hike!}]";
            //string body = @"{
            //    'documents': [
            //        {
            //         'language': 'en',
            //            'id': '1',
            //            'text': 'We love this trail and make the trip every year. The views are breathtaking and well worth the hike!'
            //        }
            //      ]
            //    }";
            
            //var data = JsonConvert.SerializeObject(body);

            var document = new KeyPhraseDocument()
            {
                Language = "en",
                Id = "1",
                Text = utterance
            };

            var keyclient = new KeyPhraseClient("3ff10cb8e78442bab6ac035ea5c1630a");
            var keyrequest = new KeyPhraseRequest();
            keyrequest.Documents.Add(document);

            var keyresponse = await keyclient.GetKeyPhrasesAsync(keyrequest);

            return keyresponse.Documents[0].KeyPhrases;

            // Request body
            //byte[] byteData = Encoding.UTF8.GetBytes(body);

            //using (var content = new ByteArrayContent(byteData))
            //{
            //    content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            //    response = await client.PostAsync(uri, content);
            //}


            //return null;
        }
    }
}
