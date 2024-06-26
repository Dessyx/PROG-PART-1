﻿using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
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

// --- REFERENCES ---
//W3Schools, 2024. C# Exceptions - Try..Catch. [Online] 
//Available at: https://www.w3schools.com/cs/cs_exceptions.php
//[Accessed 14 April 2024].

//TutorialsPoint, 2024. How to change the Foreground Color of Text in C# Console?. [Online] 
//Available at: https://www.tutorialspoint.com/how-to-change-the-foreground-color-of-text-in-chash-console
//[Accessed 12 April 2024].


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
                    Console.WriteLine("2) Scale your recipe: ");
                    Console.WriteLine("3) Reset quantities: ");
                    Console.WriteLine("4) Display your recipe: ");
                    Console.WriteLine("5) Clear all data: "); 
                    Console.WriteLine("6) Exit the program: ");
                    Console.WriteLine("Enter your choice: ");

                    //Taking in user input.
                    choice = int.Parse(Console.ReadLine());

                    // Performing an action based on the user input.
                    switch (choice)
                    {
                        case 1:
                            recipe.RecipeInformation();
                            recipe.CountingSteps();
                            break;
                        case 2:
                            recipe.ScaleRecipe();
                            break;
                        case 3:
                            recipe.QuantitiesReset();

                            break;
                        case 4:
                             recipe.DisplayRecipe();
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
    internal class RecipeMethods   // Helper class
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
        private String[] originalMeasurement;
        string[] stepDescriptions;

        //------------------------------------------------------------------------
        // Method called RecipeMeasurement which captures and stores user input 
        // about the recipe such as ingredients, quantities and measurement.
        public void RecipeInformation()
        {

            Console.WriteLine("Lets make a recipe!");

            // Prompts user to enter the name they'd like to give the recipe.   
            Console.WriteLine("What would you like to name the recipe?");
            recipeName = Console.ReadLine();

            while (String.IsNullOrWhiteSpace(recipeName))
            {
                Console.ForegroundColor = ConsoleColor.Red; // < -- Code taken from TutorialsPoint
                Console.WriteLine("Field is empty! Please enter an input", Console.ForegroundColor);
                Console.ResetColor(); // < -- Code taken from TutorialsPoint
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

                    // Checks if the input is a integer + the input is not empty.
                    if (ingredientAmount <= 0)
                    {
                        // -------- From w3schools -------
                        throw new ArgumentOutOfRangeException();  // Throw statement was takenfrom w3schools
                        // -------------------------------
                    }
                    break;

                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red; // < -- Code taken from TutorialsPoint
                    Console.WriteLine("Invalid input.\nPlease enter a number OR the field is empty", Console.ForegroundColor);
                    Console.ResetColor(); // < -- Code taken from TutorialsPoint
                }

                catch (ArgumentOutOfRangeException)
                {
                    Console.ForegroundColor = ConsoleColor.Red; // < -- Code taken from TutorialsPoint
                    Console.WriteLine("Ingredient amount must be greater than 0", Console.ForegroundColor);
                    Console.ResetColor(); // < -- Code taken from TutorialsPoint
                }

            }
            // Declaring the array length to be the amount of ingredients.
            ingredients = new string[ingredientAmount];
            quantities = new double[ingredientAmount];
            originalQuantities = new double[ingredientAmount];
            measurement = new String[ingredientAmount];

            //          -----------------------------------------------------

            for (int i = 0; i < ingredients.Length; i++)
            {

                Console.WriteLine("--------INGREDIENT-----------");
                Console.Write("Ingredient name:");
                string ingredient = Console.ReadLine();

                // Loops and captures information for each ingredient.


                while (string.IsNullOrWhiteSpace(ingredient))   // loops until the user inputs the recipe name
                {
                    Console.ForegroundColor = ConsoleColor.Red;  // < -- Code taken from TutorialsPoint
                    Console.WriteLine("*Please enter a recipe name.*", Console.ForegroundColor);
                    Console.ResetColor(); // < -- Code taken from TutorialsPoint
                    Console.Write("Ingredient name:");
                    ingredient = Console.ReadLine();
                }
                ingredients[i] = ingredient;

                //--------

                while (true)        // Aquires the quantity of each ingredient
                {
                    Console.ResetColor();
                    Console.Write("Quantity:");

                    try
                    {
                        string input = Console.ReadLine();
                        quantityD = double.Parse(input);

                        // Checks if the input is not empty.
                        if (quantityD <= 0)
                        {
                            // -------- From w3schools -------
                            throw new ArgumentOutOfRangeException();  // Throw statement was takenfrom w3schools
                            // -------------------------------
                        }

                        quantities[i] = quantityD;

                        originalQuantities[i] = quantities[i];
                        break;

                    }
                    catch (FormatException)
                    {

                        Console.ForegroundColor = ConsoleColor.Red; // < -- Code taken from TutorialsPoint
                        Console.WriteLine("*Please enter a number.*", Console.ForegroundColor);
                        Console.ResetColor(); // < -- Code taken from TutorialsPoint
                    }

                    catch (ArgumentOutOfRangeException)
                    {
                        Console.ForegroundColor = ConsoleColor.Red; // < -- Code taken from TutorialsPoint
                        Console.WriteLine("*Field is empty. Please enter a quantity.*", Console.ForegroundColor);
                        Console.ResetColor(); // < -- Code taken from TutorialsPoint
                    }

                }





                Console.Write("Meansurement (teaspoon, tablespoon or cup): ");  // Only accepts teaspoon, tablespoon and cup
                string measurementInput = Console.ReadLine();

                while (measurementInput == null        // While the user does not enter a value,
                    || (measurementInput != "teaspoon" // or "teaspoon"
                    && measurementInput != "tablespoon"// or "tablespoon"
                    && measurementInput != "cup"))     // or "cup" ...
                {
                    Console.ForegroundColor = ConsoleColor.Red; // < -- Code taken from TutorialsPoint
                    Console.WriteLine("*Please enter a measurement  (teaspoon, tablespoon or cup) *", Console.ForegroundColor);
                    Console.ResetColor(); // < -- Code taken from TutorialsPoint
                    Console.Write("Measurement:");      // The user is prompted to enter until they do.
                    measurementInput = Console.ReadLine();
                }

                measurement[i] = measurementInput;
                originalMeasurement = new string[ingredients.Length];
                originalMeasurement[i] = measurement[i];

            }
        }



        //----------------------------------------------------------------------
        // Method called CountingSteps which asks the user how many steps they'd
        // like to add and captures a description for each.
        public void CountingSteps() 
        {
            Console.ResetColor();  // < -- Code taken from TutorialsPoint

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
                        // -------- From w3schools -------
                        throw new ArgumentOutOfRangeException();  // Throw statement was takenfrom w3schools
                        // -------------------------------
                    }


                    break; 
                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red; // < -- Code taken from TutorialsPoint
                    Console.WriteLine("Invalid input. Please enter a number.", Console.ForegroundColor);
                    Console.ResetColor(); // < -- Code taken from TutorialsPoint
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.ForegroundColor = ConsoleColor.Red; // < -- Code taken from TutorialsPoint
                    Console.WriteLine("Field is empty. Please enter the number of steps", Console.ForegroundColor);
                    Console.ResetColor(); // < -- Code taken from TutorialsPoint
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
                    Console.ForegroundColor = ConsoleColor.Red; // < -- Code taken from TutorialsPoint
                    Console.WriteLine("Field is empty. Please enter a description.", Console.ForegroundColor);
                    Console.ResetColor(); // < -- Code taken from TutorialsPoint
                    Console.Write("Description: ");
                    description = Console.ReadLine().Trim();
                   
                }

                stepDescriptions[i] = description;
               
            }

        }

       
        //----------------------------------------------------------------------------
        // Method called ScaleRecipe which scales the recipe up or down depending
        // on the users choice.
        public void ScaleRecipe()
        {
            Console.WriteLine("Lets scale the recipe! The more the merrier.");
            Console.WriteLine("\nEnter scaling factor (0.5, 2 or 3)");

            double factor = double.Parse(Console.ReadLine()); // User enters the factor they'd like to scale.
            
            for(int i = 0; i < quantities.Length; i++)
            {
                quantities[i] = originalQuantities[i] * factor;  // Multiplying the original values by the factor
                                                                 // and assigning the values to quantities.

                double TeaspoonToTablespoon(double quantity)     // Methods that scale the quantities
                {
                    return quantities[i] / 3;
                }

                double TablespoonToCup(double quantity)
                {
                    return quantities[i] / 16;
                }


                    // Update units of measurement based on measurement
                    switch (measurement[i])
                    {
                        case "teaspoon":    
                            if (quantities[i] >= 3)                                    // If the measurement is teaspoon + the quantity is greater than 3 
                        {                                                              // which then means it is 1 tablespoon or more then the necessary conversion
                                quantities[i] = TeaspoonToTablespoon(quantities[i]);   // is performed.
                                measurement[i] = "tablespoon";

                            } else if (quantities[i] <=3)
                        {
                            measurement[i] = originalMeasurement[i];
                        }
                            break;
                      
                        case "tablespoon":                                              // If the measurement is teaspoon + the quantity is greater than 16
                        if (quantities[i] >= 16)                                        // which then means it is 1 cup or more then the necessary conversion
                        {                                                               // is performed.
                            quantities[i] = TablespoonToCup(quantities[i]);
                            measurement[i] = "cup";

                        } else if (quantities[i] <= 3)
                        {
                            measurement[i] = originalMeasurement[i];
                        }
                        break;

                    case "cup":                                                         // If the measurement is cup, the measurement stays the same
                        measurement[i] = "cup";
                        break;
                }
                

            }

            for (int i = 0; i < quantities.Length; i++)
            {
                Console.WriteLine();    
                Console.WriteLine("*  " + quantities[i] + " " + measurement[i] + " of " + ingredients[i]);
            }

            Console.WriteLine("\nAll done!");
        }

        //-----------------------------------------------------------------------------
        // Method called QuantitiesReset which resets the quantities back to the original
        // scale before scaling up or down.
        public void QuantitiesReset()
        {
                Console.WriteLine("Are you sure you'd like to reset the data?");
                Console.WriteLine("(yes) to reset.\n(no) to keep data");
                string reset = Console.ReadLine();

                if(reset.Equals("yes")) {

                for (int i = 0; i < quantities.Length; i++)
                {
                    quantities[i] = originalQuantities[i];  // Resests the mutiplied values to the orgininal values.
                    measurement[i] = originalMeasurement[i]; // Resets the converted measurements to the orginal measurement.
                }

                Console.WriteLine("All done!");
            } else
            {
                Console.WriteLine("Data has not been cleared");
            }
                   
            
        }

        //----------------------------------------------------------------------
        // Method called DisplayRecipe which displays the recipe information.
        public void DisplayRecipe()
        {
            Console.WriteLine("------------------------------------");
            Console.ForegroundColor = ConsoleColor.Magenta; // < -- Code taken from TutorialsPoint
            Console.WriteLine("           RECIPE: " + recipeName);
            Console.ResetColor(); // < -- Code taken from TutorialsPoint
            Console.WriteLine("------------------------------------");


            //If the fields are empty, displays the error message and prompts user to proceed to step 1.
            if (quantities != null && measurement.Length > 0 && ingredients.Length > 0)
            {  // Error handling

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

            }
            else
            {
                Console.WriteLine("Fields are empty. Please proceed to step 1");
            }

        }



        //-------------------------------------------------------------------------------
        // Method called Clear which clears all the recipe input.
        public void Clear()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Are you sure you'd like to clear data? (yes or no)");
                    string confirmation = Console.ReadLine().Trim().ToLower();

                    if (string.IsNullOrEmpty(confirmation))     // Checks if the input is empty
                    {
                        // -------- From w3schools -------
                        throw new ArgumentException(); // Throw statement was takenfrom w3schools
                        // -------------------------------
                    }

                    if (confirmation.Equals("yes")) // Clears the variables if the user says yes
                    {
                        ingredients = null;
                        quantities = null;       // Set all variables to null (empty)
                        measurement = null;
                        stepDescriptions = null;
                        recipeName = null;

                        Console.ForegroundColor = ConsoleColor.DarkCyan; // < -- Code taken from TutorialsPoint
                        Console.WriteLine("Oops! Your data has been cleared.");
                        Console.ResetColor(); // < -- Code taken from TutorialsPoint
                        break;
                    }
                    else if (confirmation.Equals("no")) // Does not clear values
                    {
                        break;
                    }

                    if (int.TryParse(confirmation, out int number))
                    {
                        // -------- From w3schools -------
                        throw new FormatException(); // Throw statement was takenfrom w3schools
                       // -------------------------------
                    }


                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red; // < -- Code taken from TutorialsPoint
                    Console.WriteLine("Invalid input. Please enter Yes or No.", Console.ForegroundColor);
                    Console.ResetColor(); // < -- Code taken from TutorialsPoint
                }
                catch (ArgumentException)
                {
                    Console.ForegroundColor = ConsoleColor.Red; // < -- Code taken from TutorialsPoint
                    Console.WriteLine("Field is empty. Please enter Yes or No", Console.ForegroundColor);
                    Console.ResetColor(); // < -- Code taken from TutorialsPoint
                }

            }
        }

        //--------------------------------------------------------------------------------
        // Method called exit which confirms if the user wishes to exit and exits 
        // the program once confirmed.
        public void Exit()
        {
            while (true)
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.DarkCyan; // < -- Code taken from TutorialsPoint
                    Console.WriteLine("Awwww :( Sad to see you go.");
                    Console.ResetColor(); // < -- Code taken from TutorialsPoint
                    Console.WriteLine("Are you sure you would like to exit? (yes or no)"); // Confirming if the user would like to exit.
                    string exiting = Console.ReadLine().Trim();
                    

                    if (string.IsNullOrEmpty(exiting))  // Checks if input is empty
                    {
                        // -------- From w3schools -------
                        throw new ArgumentNullException(); // Throw statement was takenfrom w3schools
                        // -------------------------------
                    }


                    if (int.TryParse(exiting, out int number))  // Checks if the input in the corre t format
                    {                                           // must be a number.
                        // -------- From w3schools -------
                        throw new FormatException("Can not be a number"); // Throw statement was takenfrom w3schools
                        // -------------------------------
                    }


                    if (exiting.ToLower() == "yes")
                    {
                        Console.WriteLine("Exiting... ( x _ x )");
                        Environment.Exit(0);  // Exits application
                        break;
                        
                    }
                    else if (exiting.ToLower() == "no")  // Continues 
                    {
                        break;
                    }

                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red; // < -- Code taken from TutorialsPoint
                    Console.WriteLine("Invalid input. Please enter Yes or No.", Console.ForegroundColor);
                    Console.ResetColor(); // < -- Code taken from TutorialsPoint
                }
                catch (ArgumentNullException)
                {
                    Console.ForegroundColor = ConsoleColor.Red; // < -- Code taken from TutorialsPoint
                    Console.WriteLine("Field is empty. Please enter Yes or No", Console.ForegroundColor);
                    Console.ResetColor(); // < -- Code taken from TutorialsPoint
                }
               
            }
        }


    }
//---------------------------------------------------------------------------------------------------------
//                                    END OF RECIPE METHODS CLASS


} //------------------------------------------<<< End Of File >>>-------------------------------------------------------