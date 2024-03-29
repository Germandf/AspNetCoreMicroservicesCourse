﻿using AspnetRunBasics.Models;
using AspnetRunBasics.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspnetRunBasics;

public class OrderModel : PageModel
{
    private readonly IOrderService _orderService;

    public OrderModel(IOrderService orderService)
    {
        _orderService = orderService;
    }

    public IEnumerable<OrderResponseModel> Orders { get; set; } = new List<OrderResponseModel>();

    public async Task<IActionResult> OnGetAsync()
    {
        var userName = "german";
        Orders = await _orderService.GetOrdersByUserName(userName);

        return Page();
    }       
}
