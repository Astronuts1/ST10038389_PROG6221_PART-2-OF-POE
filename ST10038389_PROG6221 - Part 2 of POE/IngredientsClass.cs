using System;

namespace ST10038389_PROG6221___Part_2_of_POE
{
    public class IngredientClass
    {
        //<Summary>
        //Getters and Setters for Ingredient Class.
        public string Name { get; set; }
        //Gets the String Name of the Recipe and sets it into the application.
        //This property represents the name of the ingredient as a string.
        //It's used to identify the ingredient in the Recipe Application!
        //Example: Milk | Sugar | Strawberries and etc.....
        public double Quantity { get; set; }
        //Getters and Setters of Quantity in Recipe Class.
        //This property represents how much is needed!
        public string Unit { get; set; }
        //Getters and Setters for the unit of measurement in recipe class.
        //This property is used to measure what the quantity is in!
        //For example: Teaspoon | Cups | Bowls | Liters(L) and Millimeters(ML).
        public int Calories { get; set; }
        //Getters and Setters are used to calculate the number of calories in the recipe application.
        //This property represents the calories towards the quantity of the Recipe Application.
        //For example: 50Calories | 100Calories | 150Calories | 200Calories and max is set to 300Calories!
        public string FoodGroup { get; set; }
        //Getters and Setters manage which ingredient is labeled for Food Group.
        //For example: {DIARY} | {PROTEIN} | {SWEETS} | {FAT}
        //</Summary>
    }
}
//----------------------- END OF LINE -------------------------------------------------------------------------------------------------------------------------------- 
