using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PART_1
{
    internal class RecipeApp
    {
        RecipeMethods recipe = new RecipeMethods();

        public void Run()
        {
            Console.WriteLine("Welcome to Sanele's Recipe App!");

            while (true)
            {
                //Prompt the user to choose what action theyd like to take.
                Console.WriteLine("\nPick a option: ");

                // Providing user with options:
                Console.WriteLine("1) Enter details of the recipe");
                Console.WriteLine("2) Display your recipe: ");
                Console.WriteLine("3) Scale your recipe: ");
                Console.WriteLine("4) Reset quantities: ");
                Console.WriteLine("5) Clear all data: ");
                Console.WriteLine("6) Exit the program: ");

                //Taking in user input.
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:

                        break;
                    case 2:

                        break;
                    case 3:

                        break;
                    case 4:

                        break;
                    case 5:

                        break;
                    case 6:

                        break;
                    default:
                        Console.WriteLine("Invalid choice, please pick a option between 1 and 6");
                        break;

                }

            }
        }
    }

    internal class RecipeMethods
    {

        // Creating Arrays
        private string[] ingredients;
        private double[] quantities;
        private String[] measurement;

        public void CreateRecipe()
        {
            Console.WriteLine("Lets make a recipe!");

            //Prompts user to enter the number of ingredients they would like to capture.
            Console.WriteLine("Enter the number of ingredients: ");
            int ingredientAmount = int.Parse(Console.ReadLine());

            // Declaring the array length to be the amount of ingredients.
            ingredients = new string[ingredientAmount];
            quantities = new double[ingredientAmount];
            measurement = new String[ingredientAmount];

            // Loops and captures information for each ingredient.
            for(int i = 0; i < ingredients.Length; i++)
            {
                Console.WriteLine("Ingredient" + ingredients[i+1]);
                Console.WriteLine("Ingredient name:");
                ingredients[i] = Console.ReadLine();
                Console.WriteLine("Quantity:");
                quantities[i] = double.Parse(Console.ReadLine());
                Console.WriteLine("Meansurement (in Units): ");
            }




        }
    }
}
