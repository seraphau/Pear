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
            var apiResponse = new StoreApiResponse(stores.ToList());

            return Ok(stores);
        }

        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}