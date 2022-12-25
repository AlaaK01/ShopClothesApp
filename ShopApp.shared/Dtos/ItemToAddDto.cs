using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.shared.Dtos
{
    public class ItemToAddDto
    {
        public string CartId { get; set; }
        public string ClothId { get; set; }
        public int Quantity { get; set; }
    }
}
