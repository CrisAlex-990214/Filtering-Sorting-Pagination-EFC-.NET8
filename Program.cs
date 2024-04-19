using Filters;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ShopDbContext>(opts => opts.UseInMemoryDatabase("ShopDb"));

var app = builder.Build();

app.MapGet("/products", (ShopDbContext db) =>
{
    db.Database.EnsureCreated();

    return new GenericRepo<Product>(db).Get(
        filter: f=> f.Price < 50,
        orderBy: o => o.OrderBy(p=> p.Price),
        pageNumber: 1, pageSize: 5
        );
});

app.MapGet("/orders", (ShopDbContext db) =>
{
    return new GenericRepo<Order>(db).Get(
        includeProperties: "User,Items.Product"
        );
});

app.Run();
