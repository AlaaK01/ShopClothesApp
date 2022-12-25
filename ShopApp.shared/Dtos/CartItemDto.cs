using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.shared.Dtos
{
    public class CartItemDto
    {
        public string Id { get; set; }
        public string ClothId { get; set; }
        public string CartId { get; set; }
        public string ClothName { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set; }
        public double Price { get; set; }
        public double TotalPrice { get; set; }
        public int Quantity { get; set; }

    }
}
