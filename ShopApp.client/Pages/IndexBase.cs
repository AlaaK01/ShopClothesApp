using Microsoft.AspNetCore.Components;
using ShopApp.client.ClientServices;
using ShopApp.shared.Dtos;

namespace ShopApp.client.Pages
{
    public class indexBase : ComponentBase
    {
        [Inject]
        public IClientClothesServices _clientProductServices { get; set; }
        public IEnumerable<ClothDto> clothes { get; set; }
        protected override async Task OnInitializedAsync()
        {
            clothes = await _clientProductServices.GetItems();
        }
    }
}
