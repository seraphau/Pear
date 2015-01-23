namespace Pear.Api.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    using Newtonsoft.Json;

    public abstract class ResponseBase
    {
        [JsonProperty("id")]
        public int Id { get; set; }
    }
}