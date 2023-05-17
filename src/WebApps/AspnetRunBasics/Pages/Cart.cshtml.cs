using AspnetRunBasics.Models;
using AspnetRunBasics.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspnetRunBasics;

public class CartModel : PageModel
{
    private readonly IBasketService _basketService;

    public CartModel(IBasketService basketService)
    {
        _basketService = basketService;
    }

    public BasketModel? Cart { get; set; }

    public async Task<IActionResult> OnGetAsync()
    {
        var userName = "german";
        Cart = await _basketService.GetBasket(userName);            

        return Page();
    }

    public async Task<IActionResult> OnPostRemoveToCartAsync(string productId)
    {
        var userName = "german";
        var basket = await _basketService.GetBasket(userName);

        var item = basket.Items.Single(x => x.ProductId == productId);
        basket.Items.Remove(item);

        await _basketService.UpdateBasket(basket);

        return RedirectToPage();
    }
}
