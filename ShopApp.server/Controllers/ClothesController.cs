using Microsoft.AspNetCore.Mvc;
using ShopApp.server.Extension;
using ShopApp.shared.Dtos;
using ShopApp.shared.Services;


namespace ShopApp.server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClothesController : ControllerBase
    {
        private readonly IClothesServices _services;

       public ClothesController(IClothesServices services) => _services = services;

       
        [HttpGet]
        public async Task<ActionResult<List<ClothDto>>> GetItems()
        {
            var clothes = await this._services.GetClothes();
            //var categories = await this._services.GetCategories();
            if (clothes == null) return NotFound();
            else
            {
                var ClothDtos = clothes.ConvertToDto();
                return Ok(ClothDtos);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ClothDto>> GetItem(string id)
        {
            var cloth = await this._services.GetClothById(id);
            if (cloth == null) return BadRequest();
            else
            {
                var ClothDto = cloth.ConvertToDto();
                return Ok(ClothDto);
            }

        }
       

        [HttpGet]
        [Route(nameof(GetCategories))]
        public async Task<ActionResult<List<CategoryDto>>> GetCategories()
        {
            var categories = await _services.GetCategories();
            var categoryDtos = categories.ConvertToDto();
            return Ok(categoryDtos);
        }

        [HttpGet]
        [Route("{categoryId}/GetItemsByCategory")]
        public async Task<ActionResult<List<ClothDto>>> GetItemsByCategory(string categoryId)
        {
            var products = await _services.GetClothByCategory(categoryId);
            var ClothDtos = products.ConvertToDto();
            return Ok(ClothDtos);
        }
       
    }
}
