using System;
using System.Collections.Generic;
using System.Linq;

public class Recipe
{
    public string Name { get; set; }
    public List<string> Ingredients { get; set; }
    public string Instructions { get; set; }
}

public class RecipeDatabase
{
    private List<Recipe> Recipes { get; set; }

    public RecipeDatabase()
    {
        Recipes = new List<Recipe>();
    }

    public void AddRecipe(Recipe recipe)
    {
        Recipes.Add(recipe);
    }

    public void RemoveRecipe(string name)
    {
        var recipe = Recipes.FirstOrDefault(r => r.Name == name);
        if (recipe != null)
        {
            Recipes.Remove(recipe);
        }
    }

    public void UpdateRecipe(string name, Recipe updatedRecipe)
    {
        var recipe = Recipes.FirstOrDefault(r => r.Name == name);
        if (recipe != null)
        {
            recipe.Ingredients = updatedRecipe.Ingredients;
            recipe.Instructions = updatedRecipe.Instructions;
        }
    }

    public void DisplayRecipes()
    {
        foreach (var recipe in Recipes)
        {
            Console.WriteLine($"Recipe Name: {recipe.Name}");
            Console.WriteLine("Ingredients:");
            foreach (var ingredient in recipe.Ingredients)
            {
                Console.WriteLine($"- {ingredient}");
            }
            Console.WriteLine($"Instructions: {recipe.Instructions}");
            Console.WriteLine("-----------------------------");
        }
    }
}

public class Program
{
    public static void Main()
    {
        var recipeDatabase = new RecipeDatabase();

        var recipe1 = new Recipe
        {
            Name = "Pasta",
            Ingredients = new List<string> { "200g pasta", "2 cloves of garlic", "Olive oil", "Salt", "Pepper" },
            Instructions = "Boil the pasta. Sauté the garlic in olive oil. Mix the pasta with the garlic and oil. Season with salt and pepper."
        };

        var recipe2 = new Recipe
        {
            Name = "Chicken Soup",
            Ingredients = new List<string> { "1 whole chicken", "2 carrots", "1 onion", "Salt", "Pepper" },
            Instructions = "Boil the chicken. Add chopped carrots and onion. Season with salt and pepper."
        };

        var recipe3 = new Recipe
        {
            Name = "Salad",
            Ingredients = new List<string> { "Lettuce", "Tomato", "Cucumber", "Olive oil", "Lemon juice" },
            Instructions = "Chop the lettuce, tomato, and cucumber. Mix with olive oil and lemon juice."
        };

        var recipe4 = new Recipe
        {
            Name = "Fried Rice",
            Ingredients = new List<string> { "1 cup rice", "2 eggs", "Soy sauce", "Green onions" },
            Instructions = "Cook the rice. Scramble the eggs. Mix the rice and eggs with soy sauce. Top with chopped green onions."
        };

        recipeDatabase.AddRecipe(recipe1);
        recipeDatabase.AddRecipe(recipe2);
        recipeDatabase.AddRecipe(recipe3);
        recipeDatabase.AddRecipe(recipe4);

        while (true)
        {
            Console.WriteLine("1. Add Recipe");
            Console.WriteLine("2. Remove Recipe");
            Console.WriteLine("3. Update Recipe");
            Console.WriteLine("4. Display Recipes");
            Console.WriteLine("5. Exit");
            Console.Write("Select an option: ");
            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    Console.Write("Enter recipe name: ");
                    var name = Console.ReadLine();
                    Console.Write("Enter ingredients (comma separated): ");
                    var ingredients = Console.ReadLine().Split(',').ToList();
                    Console.Write("Enter instructions: ");
                    var instructions = Console.ReadLine();
                    var recipe = new Recipe { Name = name, Ingredients = ingredients, Instructions = instructions };
                    recipeDatabase.AddRecipe(recipe);
                    break;
                case "2":
                    Console.Write("Enter recipe name to remove: ");
                    name = Console.ReadLine();
                    recipeDatabase.RemoveRecipe(name);
                    break;
                case "3":
                    Console.Write("Enter recipe name to update: ");
                    name = Console.ReadLine();
                    Console.Write("Enter new ingredients (comma separated): ");
                    ingredients = Console.ReadLine().Split(',').ToList();
                    Console.Write("Enter new instructions: ");
                    instructions = Console.ReadLine();
                    recipe = new Recipe { Name = name, Ingredients = ingredients, Instructions = instructions };
                    recipeDatabase.UpdateRecipe(name, recipe);
                    break;
                case "4":
                    recipeDatabase.DisplayRecipes();
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }
}
