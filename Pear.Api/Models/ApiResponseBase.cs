namespace Pear.Api.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    using Newtonsoft.Json;

    public class ApiConfig
    {
        public const string Version = "1.0";
    }

    public abstract class ApiResponseBase
    {
        [JsonProperty("meta")]
        public ApiResponseMeta Meta { get; set; }

        public ApiResponseBase()
        {
            this.Meta = new ApiResponseMeta();
            this.Meta.ApiVersion = ApiConfig.Version;
        }
    }

    public class ApiResponseMeta
    {
        [JsonProperty("apiVersion")]
        public string ApiVersion { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("length")]
        public int Length { get; set; }
    }
}