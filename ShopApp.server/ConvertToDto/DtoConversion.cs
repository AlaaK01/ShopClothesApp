using Microsoft.AspNetCore.Mvc;
using ShopApp.shared.Dtos;
using ShopApp.shared.Models;

namespace ShopApp.server.Extension
{
    public static class DtoConversion
    {

        public static List<CategoryDto> ConvertToDto(this List<Category> categories)
        {
            return (from category in categories
                    select new CategoryDto
                    {
                        Id = category.Id,
                        CategoryName = category.CategoryName
                    }).ToList();
        }
        public static List<ClothDto> ConvertToDto(this List<Cloth> cloths)
        {
            return (from cloth in cloths

                    select new ClothDto
                    {
                        Id = cloth.Id,
                        ClothName = cloth.ClothName,
                        Description = cloth.Description,
                        ImageUrl = cloth.ImageURL,
                        Price = cloth.Price,
                        Quantity = cloth.Quantity,
                        Category = cloth.Category
                    }).ToList();
        }
        public static ClothDto ConvertToDto(this Cloth cloth)
        {
            return new ClothDto
            {
                Id = cloth.Id,
                ClothName = cloth.ClothName,
                Description = cloth.Description,
                ImageUrl = cloth.ImageURL,
                Price = cloth.Price,
                Quantity = cloth.Quantity,
                Category = cloth.Category,

            };
        }


        public static List<CartItemDto> ConvertToDto(this List<Item> items,
                                                            List<Cloth> cloths)
        {
            return (from item in items
                    join Cloth in cloths
                    on item.ClothId equals Cloth.Id
                    select new CartItemDto
                    {
                        Id = item.Id,
                        ClothId = item.ClothId,
                        CartId = item.CartId,
                        ClothName = Cloth.ClothName,
                        Description = Cloth.Description,
                        ImageURL = Cloth.ImageURL,
                        Price = Cloth.Price,
                        Quantity = item.Quantity,
                        TotalPrice = Cloth.Price * item.Quantity
                    }).ToList();
        }
        public static CartItemDto ConvertToDto(this Item item,
                                                    Cloth cloth)
        {
            return new CartItemDto
            {
                Id = item.Id,
                ClothId = item.ClothId,
                CartId = item.CartId,
                ClothName = cloth.ClothName,
                Description = cloth.Description,
                ImageURL = cloth.ImageURL,
                Price = cloth.Price,
                Quantity = item.Quantity,
                TotalPrice = cloth.Price * item.Quantity
            };
        }



    }
}
