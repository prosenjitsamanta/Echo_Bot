using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EchoBot
{
    public class DocumentModel
    {
        [JsonProperty("@search.score")]
        public float searchScore { get; set; }

        [JsonProperty("Doc_ID")]
        public string docId { get; set; }

        [JsonProperty("Doc_Name")]
        public string docName { get; set; }

        [JsonProperty("Doc_Link")]
        public string docLink { get; set; }
    }
}
