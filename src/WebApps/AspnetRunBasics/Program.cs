using AspnetRunBasics.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient<ICatalogService, CatalogService>(c =>
    c.BaseAddress = new Uri(builder.Configuration["ApiSettings:GatewayAddress"] ??
        throw new ArgumentNullException(nameof(builder.Configuration), "Configuration missing")));

builder.Services.AddHttpClient<IBasketService, BasketService>(c =>
    c.BaseAddress = new Uri(builder.Configuration["ApiSettings:GatewayAddress"] ??
        throw new ArgumentNullException(nameof(builder.Configuration), "Configuration missing")));

builder.Services.AddHttpClient<IOrderService, OrderService>(c =>
    c.BaseAddress = new Uri(uriString: builder.Configuration["ApiSettings:GatewayAddress"] ??
        throw new ArgumentNullException(nameof(builder.Configuration), "Configuration missing")));

builder.Services.AddRazorPages();

var app = builder.Build();

app.UseDeveloperExceptionPage();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapRazorPages();

app.Run();
