using Shopping.Aggregator.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient<ICatalogService, CatalogService>(c =>
    c.BaseAddress = new Uri(builder.Configuration["ApiSettings:CatalogUrl"] ?? 
        throw new ArgumentNullException(nameof(builder.Configuration), "Configuration missing")));

builder.Services.AddHttpClient<IBasketService, BasketService>(c =>
    c.BaseAddress = new Uri(builder.Configuration["ApiSettings:BasketUrl"] ??
        throw new ArgumentNullException(nameof(builder.Configuration), "Configuration missing")));

builder.Services.AddHttpClient<IOrderService, OrderService>(c =>
    c.BaseAddress = new Uri(uriString: builder.Configuration["ApiSettings:OrderingUrl"] ??
        throw new ArgumentNullException(nameof(builder.Configuration), "Configuration missing")));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseAuthorization();
app.MapControllers();

app.Run();
