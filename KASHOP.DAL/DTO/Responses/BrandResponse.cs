using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace KASHOP.DAL.DTO.Responses
{
    public class BrandResponse
    {
        public int ID { set; get; }
        public string Name { get; set; }
        [JsonIgnore]
        public string Thumbnail { get; set; }
        public string ThumbnailURL => $"https://localhost:7267/Images/{Thumbnail}";
    }
}
