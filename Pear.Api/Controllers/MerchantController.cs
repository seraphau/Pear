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

    [RoutePrefix("merchants")]
    public class MerchantController : ControllerBase
    {
        [Route("{merchantId:int}")]
        public IHttpActionResult GetMerchant(int merchantId)
        {
            return Ok();
        }

        public IHttpActionResult PostMerchant(string name)
        {
            var merchant = new Merchant();

            merchant.Name = name;
            merchant.CreatedDate = DateTime.Now;

            dbPear.Merchants.Add(merchant);
            dbPear.SaveChanges();

            return Ok();
        }
    }
}