using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EchoBot
{
    public class AzureSearchResultModel
    {
        [JsonProperty("@odata.context")]
        public string docContext { get; set; }

        [JsonProperty("value")]
        public List<DocumentModel> values { get; set; }
    }
}
