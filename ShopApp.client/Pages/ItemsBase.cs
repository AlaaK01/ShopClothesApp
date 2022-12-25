using Microsoft.AspNetCore.Components;
using ShopApp.client.ClientServices;
using ShopApp.shared.Dtos;

namespace ShopApp.client.Pages
{
    public class ItemsBase : ComponentBase
    {
        [Inject]
        public IClientItemsService _clientItemsService { get; set; }
        [Inject]
        public NavigationManager _navigationManager { get; set; }
        public List<CartItemDto> _cartItems { get; set; }
        protected string _totalPrice { get; set; }
        protected int _totalQuantity { get; set; }
        public string ErrorMessage { get; set;  }

        protected override async Task OnInitializedAsync()
        {
             _cartItems = await _clientItemsService.GetItems(HardCoded.UserId);
            CalculateCartSummaryTotals();
        }
        protected async Task DeleteCartItem_Clic(string id)
        {
            var cartItemDto = await _clientItemsService.DeleteItem(id);
            RemoveCartItem(id);
            CalculateCartSummaryTotals();
        }
        protected async Task UpdateQtyCartItem_Click(string id, int qty)
        {
            if(qty > 0)
            {
                var updateItemDto = new UpdateItemQuantityDto
                {
                    CartItemId = id,
                    Quantity = qty
                };
                var returnedUpdateItemDto = await _clientItemsService.UpdateQuantity(updateItemDto);
                updateItemTotalPrice(returnedUpdateItemDto);
                CalculateCartSummaryTotals();
            }
            else
            {
                var item = _cartItems.FirstOrDefault(X => X.Id == id);
                if(item != null)
                {
                    item.Quantity = 1;
                    item.TotalPrice = item.Price;
                }
            }
        }
        private CartItemDto GetCartItem(string id)
        {
            return _cartItems.FirstOrDefault(x => x.Id == id);
        }
        private void RemoveCartItem(string id)
        {
            var cartItemDto = GetCartItem(id);
            _cartItems.Remove(cartItemDto);
            
        }
        private void SetTotalPrice()
        {
            _totalPrice = _cartItems.Sum(X => X.TotalPrice).ToString("C");
        }
        private void SetTotalQuantity()
        {
            _totalQuantity = _cartItems.Sum(x => x.Quantity);
        }
        private void CalculateCartSummaryTotals()
        {
            SetTotalPrice();
            SetTotalQuantity();
        }
        private void updateItemTotalPrice(CartItemDto cartItemDto)
        {
            var item = GetCartItem(cartItemDto.Id);
            if(item != null)
            {
                item.TotalPrice = cartItemDto.Price * cartItemDto.Quantity;
            }
        }
    }
}
