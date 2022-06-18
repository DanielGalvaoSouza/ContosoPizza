using Microsoft.EntityFrameworkCore;
using ContosoPizza.Models;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Linq;

namespace ContosoPizza.Data;

public class PizzaContext : DbContext
{
    public PizzaContext(DbContextOptions<PizzaContext> options) : base(options)
    {

    }

    public DbSet<Pizza> Pizzas => Set<Pizza>();
    public DbSet<Topping> Toppings => Set<Topping>();
    public DbSet<Sauce> Sauces => Set<Sauce>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        List<Sauce>? SauceCollection;
        List<Topping>? ToppingCollection;
        List<Pizza>? PizzaCollection;

        SauceCollection = new List<Sauce>()
        {
            new Sauce(){ Id = 1, Name = "Tomate", IsVegan= false},
            new Sauce(){ Id = 2, Name = "Tomate Vegano", IsVegan= true}
        };

        ToppingCollection = new List<Topping>()
        {
            new Topping(){ Id = 1, Name = "Calabresa", Calories=5},
            new Topping(){ Id = 2, Name = "Mussarela", Calories=10},
            new Topping(){ Id = 3, Name = "Frango", Calories=15},
            new Topping(){ Id = 4, Name = "Catupiry", Calories=20}
        };

        PizzaCollection = new List<Pizza>()
        {
            new Pizza(){ 
                Id = 1,
                Name = "Pizza de Frango com Catupiry",
                Sauce = SauceCollection.Find(f => f.Id == 1),
                Toppings = ToppingCollection.Where(t=> t.Id >= 1 && t.Id <= 3).ToList()}
        };

        //modelBuilder.Entity<Pizza>()
        //    .HasMany<Topping>(b => b.Toppings);

        //modelBuilder.Entity<Pizza>()
        //    .HasOne(s => s.Sauce)
        //    .HasForeingKey(s => s.SauceId);

        //modelBuilder.Entity<Topping>()
        //    .HasMany<Pizza>();

        //modelBuilder.Entity<PizzaTopping>()
        //    .HasOne(pt => pt.Pizza)
        //    .WithMany(t => t.Toppings);

        //modelBuilder.Entity<PizzaTopping>()
        //    .HasOne(pt => pt.Topping)
        //    .WithMany(t => t.Pizzas);

        //modelBuilder.Entity < Pizza
        
        //modelBuilder.Entity<Sauce>().HasData(SauceCollection);
        //modelBuilder.Entity<Topping>().HasData(ToppingCollection);
        //modelBuilder.Entity<Pizza>().HasData(PizzaCollection);
    }
    

    public static void DataSeedingEvents(ref MigrationBuilder migrationBuilder)
    {
        //migrationBuilder.InsertData(
        //    table: "Topping",
        //    columns: new[] { "Id", "Name", "Calories" },
        //    values: new object[] { 1, "Calabresa", 40 }
        //);

        //migrationBuilder.InsertData(
        //    table: "Topping",
        //    columns: new[] { "Id", "Name", "Calories" },
        //    values: new object[] { 2, "Mussarela", 80 }
            
        //);

        //migrationBuilder.InsertData(
        //    table: "Topping",
        //    columns: new[] { "Id", "Name", "Calories" },
        //    values: new object[] { 3, "Oregano", 8 }
        //);

        //migrationBuilder.InsertData(
        //    table: "Sauce",
        //    columns: new[] { "Id", "Name", "IsVegan" },
        //    values: new object[] { 1, "Tomate", false}
        //);

        //migrationBuilder.InsertData(
        //    table: "Pizzas",
        //    columns: new[] { "Id", "Nome", "Molho", "Coberturas" },
        //    values: new object[] { 1, "Pizza de Calabresa", 1, 1 }
        //);

        //migrationBuilder.InsertData(
        //    table: "Pizzas",
        //    columns: new[] { "Id", "Nome", "Molho", "Coberturas" },
        //    values: new object[] {1, "Frango com Catupiry", new Sauce() { Id = 1, Name= "Tomate", IsVegan=false}, new Topping[] {
        //        new Topping() { Id=2, Name="Mussarela", Calories=80 },
        //        new Topping() { Id=4, Name="Peito de Frango Desfiado", Calories=50 },
        //        new Topping() { Id=3, Name="Oregano", Calories=5 }
        //    } }
        //);
    }
}
