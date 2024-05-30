using System;
using System.Collections.Generic;
using System.Linq;

namespace ST10038389_PROG6221___Part_2_of_POE
{
    public class RecipeClass
    {
        public string Name { get; set; } 
        //Getters + Setters for collecting the ingredient's name in the application.
        //It is used to identify the ingredients in the recipe!

        private List<IngredientClass> ingredients;

        private List<RecipeSteps> steps;

        public delegate void CaloriesExceededEventHandler(object sender, EventArgs e);
        public event CaloriesExceededEventHandler CaloriesExceeded;

        public void SetIngredients(int count) //Method that sets the Ingredients of the Recipe!
        {
            ingredients = new List<IngredientClass>();

            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"Input the Name of  the Ingredient {i + 1}:");
                //Users enter the Name of the Ingredient  in the Recipe Application!
                string name = Console.ReadLine();

                Console.WriteLine($"Input the Quantity of {name}:");
                //How much is needed for the recipe process?
                double quantity = GetValidDoubleInput();

                Console.WriteLine($"Input the Unit of Measurement for {name}:");
                //Allows the User to enter the Unit of Measurement for the Ingredient!
                string unit = Console.ReadLine();

                Console.WriteLine($"Input the Number of Calories for {name}:");
                //Allows the User to enter the Number of Calories  of the Ingredient!
                int calories = GetValidIntegerInput();

                Console.WriteLine($"Enter the Food Group for {name}:");
                //Allows the User to enter the type of Food Group of the Ingredient!
                string foodGroup = Console.ReadLine();

                ingredients.Add(new IngredientClass //Creates a new Ingredient Class with Input details and assigns it to the ArrayList.
                {
                    Name = name,
                    Quantity = quantity,
                    Unit = unit,
                    Calories = calories,
                    FoodGroup = foodGroup
                });
            }
        }

        public void SetSteps(int count) //Method to clarify the steps for counting user details.
        {
            steps = new List<RecipeSteps>();

            for (int i = 0; i < count; i++)
            {
                //Allows the User to enter Recipe Steps details.
                Console.WriteLine($"Enter step {i + 1}:");
                string description = Console.ReadLine();

                steps.Add(new RecipeSteps { Description = description });
            }
        }

        public void DisplayRecipeClass() //Method to display the Recipe Details of the Users in the Application.
        {
            if (ingredients == null || steps == null) //Checks if the Ingredients or Steps was set to NULL VALUE,
                                                      //, which determines that 0 Recipe data has been collected!
            {
                Console.ForegroundColor = ConsoleColor.Red; //TextColor set to Red.
                Console.WriteLine("ZERO RECIPES ADDED! Please add a recipe first!");
                Console.ResetColor();
                return;
            }

            Console.ForegroundColor = ConsoleColor.Blue; //TextColor set to Blue.
            //Display Recipe Name:
            Console.WriteLine($"Recipe: {Name}");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Magenta; //TextColor set to purplish.
            //Display Ingredients Name:
            Console.WriteLine("Ingredients:");

            foreach (var ingredient in ingredients)
            {
                Console.WriteLine($"{ingredient.Quantity} {ingredient.Unit} of {ingredient.Name} ({ingredient.Calories} calories, {ingredient.FoodGroup})");
                //Displays the Ingredients Details.
            }

            Console.WriteLine("Steps:");

            for (int i = 0; i < steps.Count; i++) //Displays the steps for the user's recipe entered details in the application.
            {
                Console.WriteLine($"{i + 1}. {steps[i].Description}");
            }

            Console.ResetColor();

            //Calculate and display the total calories of the recipe added by the user in the application.
            int totalCalories = CalculateTotalCalories();
            Console.WriteLine($"\nTotal Calories: {totalCalories}");

            if (totalCalories > 300)
            {
                CaloriesExceeded?.Invoke(this, EventArgs.Empty);
            }
        }

        public void ScaleRecipeClass(double factor)
        {
            if (ingredients == null) //Checks if the ArrayList of Ingredients is set to NULL!
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No ingredients to scale. Please add a recipe first.");
                Console.ResetColor();
                return;
            }

            foreach (var ingredient in ingredients) //Taking each Ingredient quantity to multiply it by a scaling factor.
            {
                ingredient.Quantity *= factor;
            }
        }

        public void ClearRecipe()
        //This Method removes the data from the recipe.
        //Allows the user to enter a new recipe with new data.
        {
            ingredients = null;
            steps = null;
        }

        private double GetValidDoubleInput() //Method to get a double input from the user-entered details from the application.
        {
            while (true)
            {
                if (double.TryParse(Console.ReadLine(), out double value) && value > 0)
                    return value;

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input. Please enter a valid positive number.");
                Console.ResetColor();
            }
        }

        private int GetValidIntegerInput() //IF Statement to test if the value went through successfully or unsuccessfully.
        //This Method gets the valid integer input from the user.
        {
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int value) && value > 0)
                    return value;

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input. Please enter a valid positive integer.");
                Console.ResetColor();
            }
        }

        private int CalculateTotalCalories() //Method 8:Calculates the total calories of a recipe.
        {
            return ingredients.Sum(ingredient => ingredient.Calories); //Sums up all calories of all the ingredients in the recipe.
        }
    }
}
//---------------------------------------- END OF FILE --------------------------------------------------------------------------
