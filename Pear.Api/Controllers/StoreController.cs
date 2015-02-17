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

    [RoutePrefix("stores")]
    public class StoreController : ControllerBase
    {
        [Route("distance")]
        public IHttpActionResult GetStoresWithinDistance(float curLatitude, float curLongitude, float maxDistance)
        {
            var stores = dbPear.fnGetStoresByDistance(curLatitude, curLongitude, maxDistance);
            var response = new StoreApiResponse(stores.ToList());

            return Ok(response);
        }

        [Route("{storeId:int}")]
        public IHttpActionResult GetStore(int storeId)
        {
            var store = dbPear.Stores.Find(storeId);
            
            if (store == null)
            {
                return NotFound();
            }

            return Ok(store);
        }

        public IHttpActionResult PostStore(int merchantId, string name, string address)
        {
            var store = new Store();

            store.MerchantId = merchantId;
            store.Name = name;
            store.Address = address;
            store.CreatedDate = DateTime.Now;

            dbPear.Stores.Add(store);
            dbPear.SaveChanges();

            return Ok(store);
        }
    }
}