namespace Pear.Api.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;

    using Pear.Api.Models;
    using Pear.Entity;

    public class AdController : ControllerBase
    {
        public IHttpActionResult GetAdsWithinDistance(float curLatitude, float curLongitude, float maxDistance)
        {
            var stores = dbPear.fnGetStoresByDistance(curLatitude, curLongitude, maxDistance);
            var ads = from s in stores
                      join ad in dbPear.Advertisements on s.MerchantId equals ad.MerchantId
                      select ad;
            var response = new AdApiResponse(ads.ToList());

            return Ok(response);
        }
    }
}