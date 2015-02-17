namespace Pear.Api.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    using Pear.Entity;
    using Newtonsoft.Json;

    public class CategoryApiResponse : ApiResponseBase
    {
        [JsonProperty("categories")]
        public List<CategoryResponse> Categories { get; set; }

        public CategoryApiResponse(IEnumerable<Category> categories)
        {
            this.Categories = new List<CategoryResponse>();

            foreach(var category in categories)
            {
                this.Categories.Add(new CategoryResponse(category));
            }
        }
    }

    public class CategoryResponse : ResponseBase
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("parent_id")]
        public int ParentId { get; set; }

        public CategoryResponse(Category category)
        {
            this.Id = category.CategoryId;
            this.Name = category.Name;
            this.ParentId = category.ParentCategoryId;
        }
    }
}