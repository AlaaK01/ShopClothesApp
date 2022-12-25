using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.shared.Dtos
{
    public class UpdateItemQuantityDto
    {
        public string CartItemId { get; set; }
        public int Quantity { get; set; }
    }
}
