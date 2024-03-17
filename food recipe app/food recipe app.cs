using System;
using System.Collections.Generic;

public class Recipe
{
    public string Name { get; set; }
    public List<string> Ingredients { get; set; }
    public string Instructions { get; set; }
}

public class RecipeBook
{
    public List<Recipe> Recipes { get; set; }

    public RecipeBook()
    {
        Recipes = new List<Recipe>();
    }

    public void AddRecipe(Recipe recipe)
    {
        Recipes.Add(recipe);
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
        var recipeBook = new RecipeBook();

        var recipe = new Recipe
        {
            Name = "Pasta",
            Ingredients = new List<string> { "200g pasta", "2 cloves of garlic", "Olive oil", "Salt", "Pepper" },
            Instructions = "Boil the pasta. Sauté the garlic in olive oil. Mix the pasta with the garlic and oil. Season with salt and pepper."
        };

        recipeBook.AddRecipe(recipe);

        recipeBook.DisplayRecipes();
    }
}
