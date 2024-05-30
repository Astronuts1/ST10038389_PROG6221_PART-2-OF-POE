using System;
using System.Collections.Generic;
using System.Linq;

namespace ST10038389_PROG6221___Part_2_of_POE
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<RecipeClass> recipes = new List<RecipeClass>();
            bool running = true;

            while (running)
            {
                Console.Clear(); //Clears the console's screen to start with a clean slate.
                Console.ForegroundColor = ConsoleColor.Blue; //Sets the text Color  to the blue of the heading of the Recipe Application!
                Console.WriteLine("Welcome to the Recipe Application Menu!"); //Displays the application heading.

                Console.ResetColor(); //Resets the text color to the default version to avoid unwanted  color warnings.
                Console.ForegroundColor = ConsoleColor.Magenta;
                //Setting the menu option to magenta purple color.
                //Making it stand out for the user's ease  and buttons are easier to allocate to.

                Console.WriteLine("1. Add a New Recipe?");
                //Displays the Menu options 1 to 5.
                //Option 1: Allows the user to add a new recipe to the application.
                Console.WriteLine("2. Display All Recipes!"); 
                //Option 2: Allows the user to view all the recipes collected from the application.
                Console.WriteLine("3. Select a Scale for Recipe!"); 
                //Allows the user to Choose a scaling factor from {0.5 to 2 to 3}.
                Console.WriteLine("4. Remove all Recipes!"); 
                //Allows the user to delete the recipe from the application.
                Console.WriteLine("5. Quit Program!"); 
                //Exit the program!
                Console.ResetColor();
                Console.Write("Please select an option: "); 
                string choice = Console.ReadLine();

                try
                {
                    // 5 Menu Option Selections of code structure.
                    switch (choice)
                    {
                        case "1":
                            Console.Clear();
                            AddRecipe(recipes);
                            break;
                        case "2":
                            Console.Clear();
                            DisplayAllRecipes(recipes);
                            break;
                        case "3":
                            Console.Clear();
                            ScaleRecipe(recipes);
                            break;
                        case "4":
                            Console.Clear();
                            recipes.Clear();
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("All recipes cleared.");
                            Console.ResetColor();
                            break;
                        case "5":
                            running = false;
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            //This checks if the user has inputed the correct information otherwise it outputs false and requires the user to give the correct information needed.
                            Console.WriteLine("Invalid option. Please select a valid menu item.");
                            Console.ResetColor();
                            break;
                    }
                }
                catch (Exception ex) //Exception Error Handeling.
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"An error occurred: {ex.Message}"); //Error handeling to check if the user entered the correct details if not then error message is being outputed!
                    Console.ResetColor();
                }

                Console.WriteLine("Press any key to return to the menu...");
                // Press and key to go back to menu options.
                Console.ReadKey();
            }
        }

        static void AddRecipe(List<RecipeClass> recipes)
        {
            RecipeClass recipe = new RecipeClass();

            recipe.CaloriesExceeded += OnCaloriesExceeded;

            Console.Write("Input the name of the recipe: "); //User enters name of the recipe he wants to create in application.
            recipe.Name = Console.ReadLine();

            Console.Write("Input the number of ingredients: "); //User then adds the number of ingredients needed for the recipe.
            int ingredientCount = GetValidIntegerInput();

            recipe.SetIngredients(ingredientCount);

            Console.Write("Input the number of steps: "); //User enters the amount of steps taken into account of proceeding this recipe.
            int stepCount = GetValidIntegerInput();

            recipe.SetSteps(stepCount);
            recipes.Add(recipe);
        }

        static void DisplayAllRecipes(List<RecipeClass> recipes)
        {
            // IF Statement to check if data passed through or never collected.
            if (recipes.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ZERO RECIPES AVAILABLE RIGHT NOW!");
                Console.ResetColor();
                return;
            }

            var sortedRecipes = recipes.OrderBy(r => r.Name).ToList();

            for (int i = 0; i < sortedRecipes.Count; i++)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"{i + 1}. {sortedRecipes[i].Name}");
                Console.ResetColor();
            }

            Console.Write("Choose a recipe number to display: "); //Input Field 4.

            int recipeNumber = GetValidIntegerInput(1, sortedRecipes.Count);

            sortedRecipes[recipeNumber - 1].DisplayRecipeClass();
        }

        static void ScaleRecipe(List<RecipeClass> recipes)
        {
            if (recipes.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ZERO RECIPES TO SCALE!"); // ZERO RECIPES ADDED TO SCALE!!!
                Console.ResetColor();
                return;
            }

            var sortedRecipes = recipes.OrderBy(r => r.Name).ToList();

            for (int i = 0; i < sortedRecipes.Count; i++)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine($"{i + 1}. {sortedRecipes[i].Name}");
                Console.ResetColor();
            }

            Console.Write("Select a recipe number to scale: "); //Input Field 6.
            int recipeNumber = GetValidIntegerInput(1, sortedRecipes.Count);

            Console.Write("Enter the scaling factor (0.5, 2, or 3): "); //Input Field 7. | Scale factor to the amount of calories.
            double factor = GetValidDoubleInput(new double[] { 0.5, 2, 3 });

            sortedRecipes[recipeNumber - 1].ScaleRecipeClass(factor);
            Console.ForegroundColor = ConsoleColor.Yellow; //Text Color set to Yellow to determine what the SCALE FACTOR IS!
            Console.WriteLine("Recipe scaled successfully!"); //Output message data collected successfully!
            Console.ResetColor();
        }

        static int GetValidIntegerInput()
        {
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int value) && value > 0)
                    return value;

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("INCORRECT ANSWER! Please ENTER a valid positive integer."); //Text Color set to red determine which details was entered INCORRECTLY!!!
                Console.ResetColor();
            }
        }

        static int GetValidIntegerInput(int min, int max)
        {
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int value) && value >= min && value <= max)
                    return value;

                Console.ForegroundColor = ConsoleColor.Red; //Text Color set to red for INCORRECT DATA ENTERED!!!
                Console.WriteLine($"INCORRECT ANSWER! Please enter a valid integer between {min} and {max}."); //Re-enter the corrected details.
                Console.ResetColor();
            }
        }

        static double GetValidDoubleInput(double[] validOptions)
        {
            while (true)
            {
                if (double.TryParse(Console.ReadLine(), out double value) && Array.Exists(validOptions, element => element == value))
                    return value;

                Console.ForegroundColor = ConsoleColor.Red; //Text Color set to red for INCORRECT DATA ENTERED!!!
                Console.WriteLine($"INCORRECT ANSWER! Please enter a valid option ({string.Join(", ", validOptions)})."); //Re-enter the corrected details in.
                Console.ResetColor();
            }
        }

        static void OnCaloriesExceeded(object sender, EventArgs e)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Warning:Total calories exceed 300!");
            Console.ResetColor();
        }
    }
}
//------------------------------------------ END OF FILE ---------------------------------------------------------------------
