using KASHOP.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace KASHOP.DAL.DTO.Responses
{
    public class ProductResponse
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public int Rate { get; set; }
        [JsonIgnore]
        public string Thumbnail { get; set; }
        public string ThumbnailURL => $"https://localhost:7267/Images/{Thumbnail}";
    }
}
