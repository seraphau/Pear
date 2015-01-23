namespace Pear.Api.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    using Pear.Entity;
    using Newtonsoft.Json;

    public class StoreApiResponse : ApiResponseBase
    {
        [JsonProperty("stores")]
        public List<StoreResponse> Stores { get; set; }

        public StoreApiResponse(IEnumerable<Store> stores)
        {
            this.Stores = new List<StoreResponse>();

            foreach (var store in stores)
            {
                this.Stores.Add(new StoreResponse(store));
            }
        }
    }

    public class StoreResponse : ResponseBase
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        public StoreResponse(Store store)
        {
            this.Name = store.Name;
            this.Address = store.Address;
        }
    }
}