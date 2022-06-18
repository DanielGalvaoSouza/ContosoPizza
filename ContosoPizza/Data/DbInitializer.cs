using ContosoPizza.Models;

namespace ContosoPizza.Data;

public static class DbInitializer
{
    public static void Initialize(PizzaContext context)
    {
        if (context.Pizzas.Any() &&
            context.Sauces.Any() &&
            context.Toppings.Any())
        {
            return;
        }

        var pepperoniTopping = new Topping { Id = 1, Name = "Pepperoni", Calories = 130 };
        var sausageTopping = new Topping { Id = 2, Name = "Sausage", Calories = 100 };
        var hamTopping = new Topping { Id = 3, Name = "Ham", Calories = 70 };
        var chickenTopping = new Topping { Id = 4, Name = "Chicken", Calories =  50 };
        var pineappleTopping = new Topping { Id = 5, Name = "Pineapple", Calories = 75 };

        var tomatoSauce = new Sauce { Id = 1, Name = "Tomato", IsVegan = true };
        var alfredoSauce = new Sauce { Id = 2, Name = "Alfredo", IsVegan = false };

        var pizzas = new Pizza[]
        {
            new Pizza
                {
                    Id = 1,
                    Name = "Meat Lovers",
                    Sauce = tomatoSauce,
                    Toppings = new List<Topping>
                        {
                            pepperoniTopping,
                            sausageTopping,
                            hamTopping,
                            chickenTopping
                        }
                },
            new Pizza
                {
                    Id = 2,
                    Name = "Hawaiian",
                    Sauce = tomatoSauce,
                    Toppings = new List<Topping>
                        {
                            pineappleTopping,
                            hamTopping
                        }
                },
            new Pizza
                {
                    Id = 3,
                    Name = "Alfredo Chicken",
                    Sauce = alfredoSauce,
                    Toppings = new List<Topping>
                        {
                            chickenTopping
                        }
                }
        };

        context.Pizzas.AddRange(pizzas);
        context.SaveChanges();

    }
}