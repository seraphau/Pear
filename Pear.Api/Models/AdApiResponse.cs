namespace Pear.Api.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    using Pear.Entity;
    using Newtonsoft.Json;

    public class AdApiResponse : ApiResponseBase
    {
        [JsonProperty("ads")]
        public List<AdResponse> Ads { get; set; }

        public AdApiResponse(IEnumerable<Advertisement> ads)
        {
            this.Ads = new List<AdResponse>();

            foreach (var ad in ads)
            {
                this.Ads.Add(new AdResponse(ad));
            }
        }
    }

    public class AdResponse : ResponseBase
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("merchant_name")]
        public string MerchantName { get; set; }

        public AdResponse(Advertisement ad)
        {
            this.Title = ad.Title;
            this.MerchantName = ad.Merchant.Name;
        }
    }
}