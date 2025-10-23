using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KASHOP.DAL.Models
{
    public class Product : BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public int Quantity { get; set; }
        public int Rate { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
        public int? BrandID { get; set; }
        public Brand? Brand { get; set; }
        public string Thumbnail { get; set; }
    }
}
