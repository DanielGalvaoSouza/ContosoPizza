using ContosoPizza.Data;
using ContosoPizza.Services;
// Additional using declarations

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSqlite<PizzaContext>("Data Source=Promotions/ContosoPizza.db");
builder.Services.AddSqlite<PromotionsContext>("Data Source=Promotions/Promotions.db");

// Add the PizzaContext
builder.Services.AddScoped<PizzaService>();

// Add the PromotionsContext
builder.Services.AddScoped<CouponService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// Add the CreateDbIfNotExists method call
app.CreateDbIfNotExists();

app.Run();
