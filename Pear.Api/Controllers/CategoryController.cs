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

    public class CategoryController : ControllerBase
    {
        [Route("{categoryId:int}")]
        public IHttpActionResult GetCategories(int parentCategoryId)
        {
            var categories = dbPear.Categories.Where(c => c.ParentCategoryId == parentCategoryId);
            var response = new CategoryApiResponse(categories.ToList());

            return Ok(response);
        }
    }
}