using KASHOP.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace KASHOP.DAL.DTO.Requests
{
    public class ProductRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public int Quantity { get; set; }
        public int Rate { get; set; }
        public int CategoryID { get; set; }
        public int? BrandID { get; set; }
        public IFormFile Thumbnail { get; set; }
    }
}
