using Microsoft.AspNetCore.Mvc;
using ShopApp.server.Extension;
using ShopApp.shared.Dtos;
using ShopApp.shared.Services;




namespace ShopApp.server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly IItemServices _itemsServices;
        private readonly IClothesServices _clothesServices;

        public ItemsController(IItemServices itemsServices, IClothesServices clothesServices)
        {
            _itemsServices = itemsServices;
            _clothesServices = clothesServices;
        }




        [HttpGet]
        [Route("{userId}/GetItems")]
        public async Task<ActionResult<List<CartItemDto>>> GetItems(string userId)
        {
            var cartItems = await _itemsServices.GetItems(userId);
            if (cartItems == null)
            {
                return NoContent();
            }
            var clothes = await _clothesServices.GetClothes();
            if (clothes == null)
            {
                throw new Exception("No clothes exist in the system");
            }
            var cartItemsDto = cartItems.ConvertToDto(clothes);
            return Ok(cartItemsDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CartItemDto>> GetItem(string id)
        {
            var cartItem = await _itemsServices.GetItem(id);
            if (cartItem == null)
            {
                return NotFound();
            }
            var cloth = await _clothesServices.GetClothById(cartItem.ClothId);
            if (cloth == null)
            {
                throw new Exception("No cloth exist in the system");
            }
            var cartItemDto = cartItem.ConvertToDto(cloth);
            return Ok(cartItemDto);
        }

        [HttpPost]
        public async Task<ActionResult<CartItemDto>> PostItem([FromBody] ItemToAddDto itemToAddDto)
        {
            var newCartItem = await _itemsServices.AddItem(itemToAddDto);
            if (newCartItem == null)
            {
                return NoContent();
            }
            var cloth = await _clothesServices.GetClothById(newCartItem.ClothId);
            if (cloth == null)
            {
                throw new Exception($"Something went wrong when attempting to retrieve cloth (productId:({itemToAddDto.ClothId})");
            }
            var newCartItemDto = newCartItem.ConvertToDto(cloth);

            return CreatedAtAction(nameof(GetItem), new { id = newCartItemDto.Id }, newCartItemDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<CartItemDto>> DeleteItem(string id)
        {
            var cartItem = await _itemsServices.DeleteItem(id);
            if (cartItem == null)
            {
                return NotFound();
            }
            var cloth = await _clothesServices.GetClothById(cartItem.ClothId);
            if (cloth == null) return NotFound();
            var cartItemDto = cartItem.ConvertToDto(cloth);

            return Ok(cartItemDto);
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult<CartItemDto>> UpdateQuantity(string id, UpdateItemQuantityDto updateItemQuantityDto)
        {
            var cartItem = await _itemsServices.UpdateQuantity(id, updateItemQuantityDto);
            if (cartItem == null)
            {
                return NotFound();
            }
            var cloth = await _clothesServices.GetClothById(cartItem.ClothId);
            var cartItemDto = cartItem.ConvertToDto(cloth);
            return Ok(cartItemDto);
        }
    }
}
