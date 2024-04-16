using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Remoting.Lifetime;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

//Deslynn Fenyes
//STD: ST10251981
//Module: PROG6221
//PROG POE PART 1

namespace PART_1
{

//-------------------------------------------------------------------------------------------------------
//                                               RECIPE APP CLASS
    internal class RecipeApp
    {
        RecipeMethods recipe = new RecipeMethods();

        //------------------------------------------------------------------
        // Method called Run which:
        // - welcomes user
        // - provides user with options
        // - performs actions based on user input
        public void Run()
        {
            Console.WriteLine("Welcome to Sanele's Recipe App!");
            int choice;

            while (true)
            {
                //Prompt the user to choose what action they'd like to take.
                Console.WriteLine("\nPick a option: ");
                try
                {
                    // Providing user with options:
                    Console.WriteLine("1) Enter details of the recipe");
                    Console.WriteLine("2) Display your recipe: ");
                    Console.WriteLine("3) Scale your recipe: ");
                    Console.WriteLine("4) Reset quantities: ");
                    Console.WriteLine("5) Clear all data: ");
                    Console.WriteLine("6) Exit the program: ");
                    Console.WriteLine("Enter your choice: ");

                    //Taking in user input.
                    choice = int.Parse(Console.ReadLine());

                    // Performing an action based on the user input.
                    switch (choice)
                    {
                        case 1:
                            recipe.RecipeMeasurement();
                            recipe.CountingSteps();
                            break;
                        case 2:
                            recipe.DisplayRecipe();
                            break;
                        case 3:
                            recipe.ScaleRecipe();
                            break;
                        case 4:
                            recipe.QuantitiesReset();
                            break;
                        case 5:
                            recipe.Clear();
                            break;
                        case 6:
                            recipe.Exit();
                            break;
                        default:
                            Console.WriteLine("Invalid choice, please pick a option between 1 and 6");
                            continue;

                    }
                   
                } catch (FormatException) {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input. Please enter a number");
                    Console.ResetColor();   
                }
            }
        }
    }

//                                                 END OF RECIPE APP CLASS
//-----------------------------------------------------------------------------------------------------------


//-----------------------------------------------------------------------------------------------------------
//                                                   RECIPE METHODS CLASS
    internal class RecipeMethods
    {
        // Declaring variables
        private String recipeName;
        private int ingredientAmount;
        private int steps;
        private double quantityD;

        //Creating Arrays
        private string[] ingredients;
        private double[] quantities;
        private double[] originalQuantities;
        private String[] measurement;
        string[] stepDescriptions;

        //------------------------------------------------------------------------
        // Method called RecipeMeasurement which captures and stores user input 
        // about the recipe such as ingredients, quantities and measurement.
        public void RecipeMeasurement()
        {

            Console.WriteLine("Lets make a recipe!");

            // Prompts user to enter the name they'd like to give the recipe.   
            Console.WriteLine("What would you like to name the recipe?");
            recipeName = Console.ReadLine();
                
            while(String.IsNullOrWhiteSpace(recipeName))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Field is empty! Please enter an input", Console.ForegroundColor);
                Console.ResetColor();
                Console.WriteLine("What would you like to name the recipe?");
                recipeName = Console.ReadLine();
            }

            //          -----------------------------------------------------

            // Prompts user to enter the number of ingredients they would like to capture.               
            while (true)
            {
                Console.WriteLine("Enter the number of ingredients: ");

                try
                {
                    string input = Console.ReadLine();
                    ingredientAmount = int.Parse(input);

                    // Checks if the input is a integer + the input id not empty.
                    if (ingredientAmount <= 0)
                    {
                        throw new ArgumentOutOfRangeException();

                    }
                    break;

                }
                catch (FormatException)
                {

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input. Please enter a number.", Console.ForegroundColor);
                    Console.ResetColor();
                }

                catch (ArgumentOutOfRangeException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Field is empty. Please enter the number of ingredients.", Console.ForegroundColor);
                    Console.ResetColor();
                }
            }
                // Declaring the array length to be the amount of ingredients.
                ingredients = new string[ingredientAmount];
                quantities = new double[ingredientAmount];
                originalQuantities = new double[ingredientAmount];
                measurement = new String[ingredientAmount];

            //          -----------------------------------------------------

            // Loops and captures information for each ingredient.
            for (int i = 0; i < ingredients.Length; i++)
                {
                    Console.WriteLine("--------INGREDIENT-----------");
                    Console.Write("Ingredient name:");
                    string ingredient = Console.ReadLine();

                    Console.ForegroundColor = ConsoleColor.Red;

                    while (string.IsNullOrWhiteSpace(ingredient))
                    {
                        Console.WriteLine("*Please enter a recipe name.*", Console.ForegroundColor);
                        Console.Write("Ingredient name:");
                        ingredient = Console.ReadLine();
                    }
                    ingredients[i] = ingredient;

                //--------


                while (true)
                {
                    Console.ResetColor();
                    Console.Write("Quantity:");

                    try
                    {
                        string input = Console.ReadLine();
                        quantityD = double.Parse(input);

                        // Checks if the input is a integer + the input id not empty.
                        if (quantityD <= 0)
                        {
                            throw new ArgumentOutOfRangeException();

                        }
                        break;

                    }
                    catch (FormatException)
                    {

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("*Please enter a number.*", Console.ForegroundColor);
                        Console.ResetColor();
                    }

                    catch (ArgumentOutOfRangeException)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("*Field is empty. Please enter a quantity.*", Console.ForegroundColor);
                        Console.ResetColor();
                    }
                    quantities[i] = quantityD;

                    originalQuantities[i] = quantities[i];
                }
                  

                //--------

                    
                    Console.Write("Meansurement (teaspoon, tablespoon or cup): ");
                    string measurementInput = Console.ReadLine();
                    while (string.IsNullOrWhiteSpace(measurementInput))
                    {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("*Please enter a measurement*", Console.ForegroundColor);
                    Console.ResetColor();
                    Console.Write("Ingredient name:");
                    measurementInput = Console.ReadLine();
                    }
                    measurement[i] = measurementInput;

                }
            
        } 

        //----------------------------------------------------------------------
        // Method called CountingSteps which asks the user how many steps they'd
        // like to add and captures a description for each.
        public void CountingSteps() 
        {
            Console.ResetColor(); 
            
            string description;

            while (true)
            {
              
                try  // --------- error handling step input -----------------
                {
                    // Prompts the user to enter the amount of steps to take.
                    Console.WriteLine("\nEnter the number of steps: ");
                    string input = Console.ReadLine();
                    steps = int.Parse(input);
                    stepDescriptions = new string[steps];

                    // Checks if the input is a integer and not empty.
                    if (steps <= 0)
                    {
                        throw new ArgumentOutOfRangeException();
                    }

                   
                    break; 
                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input. Please enter a number.", Console.ForegroundColor);
                    Console.ResetColor();
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Field is empty. Please enter the number of steps", Console.ForegroundColor);
                    Console.ResetColor();
                }

            }


            int numbering = 1;
            for (int i = 0; i < steps; i++)
            {
                
                Console.WriteLine("Step " + numbering + " - ");
                numbering++;

                // Prompt user for step description
                Console.Write("Description: ");
                description = Console.ReadLine().Trim();
                
                //-------- error handling description input -----------
                while (String.IsNullOrWhiteSpace(description))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Field is empty. Please enter a description.", Console.ForegroundColor);
                    Console.ResetColor();
                    Console.Write("Description: ");
                    description = Console.ReadLine().Trim();
                   
                }

                stepDescriptions[i] = description;
               
            }

        }

        //----------------------------------------------------------------------
        // Method called DisplayRecipe which displays the recipe information.
        public void DisplayRecipe()
        {
            Console.WriteLine("------------------------------------");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("           RECIPE: " + recipeName);
            Console.ResetColor();
            Console.WriteLine("------------------------------------");
           

            //If the fields are empty, displays the error message and prompts user to proceed to step 1.
            if (quantities != null && measurement.Length > 0 && ingredients.Length > 0) {  // Error handling

                Console.WriteLine("\nIngredients:");
                for (int i = 0; i < ingredients.Length; i++)
                {   // Displays all ingredients as well as their quantities and measurememts.     
                    Console.WriteLine("*  " + quantities[i] + " " + measurement[i] + " of " + ingredients[i]);
                }

                int numbering = 1; // Numbering for displaying the steps
                Console.WriteLine("\nSteps:");
                for (int i = 0; i < stepDescriptions.Length; i++)
                {
                    Console.WriteLine(numbering + " - " + stepDescriptions[i]); // displays each step as well as its dscription.
                    numbering++;
                }

            } else
            {
                Console.WriteLine("Fields are empty. Please proceed to step 1");
            }
           
        }

        //----------------------------------------------------------------------------
        // Method called ScaleRecipe which scales the recipe up or down depending
        // on the users choice.
        public void ScaleRecipe()
        {
            Console.WriteLine("Lets scale the recipe! The more the merrier.");

            Console.WriteLine("\nEnter scaling factor (0.5, 2 or 3)");
            double factor = double.Parse(Console.ReadLine()); // User enters the factor theyd like to scale.
            
            for(int i = 0; i < quantities.Length; i++)
            {
                quantities[i] = originalQuantities[i] * factor;  // Multiplying the original values by the factor
                                                                 // and assigning the values to quantities.
               
                if (measurement[i] == "teaspoon")
                {
                    quantities[i] /= 3.0;
                    measurement[i] = "tablespoon";

                } else if (measurement[i] == "cup"){
                    quantities[i] *= 16.0;
                    measurement[i] = "tablespoon";
                }

            }

            for (int i = 0; i < quantities.Length; i++)
            {
                Console.WriteLine("*  " + quantities[i] + " " + measurement[i] + " of " + ingredients[i]);
            }

            Console.WriteLine("\nAll done!");
        }

        //-----------------------------------------------------------------------------
        // Method called QuantitiesReset which resets the quantities back to the original
        // scale before scaling up or down.
        public void QuantitiesReset()
        {
            for(int i = 0; i < quantities.Length; i++)
            {
                quantities[i] = originalQuantities[i];  // Resests the mutiplied values to the orgininal values.
            }

            Console.WriteLine("All done!");
        }

        //-------------------------------------------------------------------------------
        // Method called Clear which clears all the recipe input.
        public void Clear()
        {
            Console.WriteLine("Are you sure you'd like to reset? (Yes or No)");
            string confirmation = Console.ReadLine();

            if (confirmation.Equals("Yes"))
            {
                ingredients = null;
                quantities = null;       // Set all variables to null (empty)
                measurement = null;
                stepDescriptions = null;
                recipeName = null;

                Console.WriteLine("Oops! Your data has been cleared.");
            }
           
        }

        //--------------------------------------------------------------------------------
        // 
        public void Exit()
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("Awwww :( Sad to see you go.");
                Console.ResetColor();
                Console.WriteLine("Are you sure you would like to exit? (Yes or No)"); // Confirming if the user would like to exit.
                String exiting = Console.ReadLine();

                if (exiting.Equals("Yes"))
                {
                    Environment.Exit(0);  // Exits application
                }

            } catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input. Please enter Yes or No.", Console.ForegroundColor);
                Console.ResetColor();
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Field is empty. Please enter Yes or No", Console.ForegroundColor);
                Console.ResetColor();
            }
        }


    }
//-----------------------------------------------------------------------------------------------------------
//                              END OF RECIPE METHODS CLASS


} //--------------------------------------<<< End Of File >>>-------------------------------------------------------