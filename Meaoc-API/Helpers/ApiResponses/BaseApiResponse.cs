using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;

namespace Meaoc_API.Helpers.ApiResponses
{
    public class BaseApiResponse
    {
        public HttpStatusCode Code { get; private set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Title { get; private set; }

        public Dictionary<string, string> Errors { get; set; } = new Dictionary<string, string>();

        public BaseApiResponse(HttpStatusCode code, string title)
        {
            this.Code = code;
            this.Title = title;
        }
        
        public BaseApiResponse(HttpStatusCode code, string title, Dictionary<string, string> errors) 
            : this(code, title)
        {
            this.Errors = errors;
        }
    }
}