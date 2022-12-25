using Microsoft.AspNetCore.Components;
using ShopApp.client.ClientServices;
using ShopApp.shared.Dtos;


namespace ShopApp.client.Pages
{
    public class ProductDetailsBase : ComponentBase
    {
        [Parameter]
        public string id { get; set; }
        [Inject]
        public IClientClothesServices _clientproductServices { get; set; }
        [Inject]
        public IClientItemsService _clientItemsService { get; set; }
        [Inject]
        public NavigationManager _navigationManager { get; set; }  
        public ClothDto _cloth { get; set; }

        public string ErrorMessage { get; set; }

        private List<CartItemDto> _cartItems { get; set; }


        protected override async Task OnInitializedAsync()
        {
            _cloth = await _clientproductServices.GetItem(id);
        }

        protected async Task AddToCart_Click(ItemToAddDto itemToAddDto)
        {

            var itemCartDto = await _clientItemsService.AddItem(itemToAddDto);
            _navigationManager.NavigateTo("/Items");
        }
       


    }
}
