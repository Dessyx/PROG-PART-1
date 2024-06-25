using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Remoting.Lifetime;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

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
    public class RecipeApp
    {
        private RecipeMethods recipe = new RecipeMethods();
        
        //------------------------------------------------------------------
        // Method called Run which:
        // - welcomes user
        // - provides user with options
        // - performs actions based on user input
        public void Run()
        {
            Console.WriteLine("Welcome to Sanele's Recipe App!");
            Console.WriteLine("How many recipes do you want to enter?");
            int numRecipes = int.Parse(Console.ReadLine());
            try
            {

                // Checks if the input is not empty.
                if (numRecipes <= 0)
                {
                    // -------- From w3schools -------
                    throw new ArgumentOutOfRangeException();  // Throw statement was taken from w3schools
                    // -------------------------------
                }
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
                Console.WriteLine("*Field is empty. Please enter a number.*", Console.ForegroundColor);
                Console.ResetColor(); // < -- Code taken from TutorialsPoint
            }

            int count = 0;
            bool cleared = false;
            while (true)
            {
               
                if (cleared)
                {
                    
                    Console.WriteLine("Would you like to add more recipes? Answer 'yes' or 'no'");
                    string moreRecipes = Console.ReadLine();

                    if ( moreRecipes == "yes")
                    {
                        count = 0;
                        Console.WriteLine("How many recipes do you want to enter?");
                        numRecipes = int.Parse(Console.ReadLine());
                        try 
                        { 
                        

                            // Checks if the input is not empty.
                            if (numRecipes <= 0)
                            {
                                // -------- From w3schools -------
                                throw new ArgumentOutOfRangeException();  // Throw statement was taken from w3schools
                                                                          // -------------------------------
                            }
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
                            Console.WriteLine("*Field is empty. Please enter a number.*", Console.ForegroundColor);
                            Console.ResetColor(); // < -- Code taken from TutorialsPoint
                        }

                        cleared = false;
                    }
                }
                   
                   
                
                while (count < numRecipes)
                {
                                    
                    Recipe recipes = new Recipe();
                    recipe.RecipeInformation(recipes);
                    recipe.CountingSteps(recipes);

                    count++;
                }
                

                Console.WriteLine("----------------------------");
                Console.WriteLine("       YOUR RECIPES");              
                Console.WriteLine("----------------------------");
                recipe.displayRecipeNames();

                int choice;
                Console.WriteLine("\n1) Scale your recipe: ");
                Console.WriteLine("2) Reset quantities: ");
                Console.WriteLine("3) Display your recipe: ");
                Console.WriteLine("4) Clear a recipes data: ");
                Console.WriteLine("5) Exit the program: ");
                Console.WriteLine("Enter your choice: ");

                //Taking in user input.
                choice = int.Parse(Console.ReadLine());

                // Performing an action based on the user input.
                switch (choice)
                {

                    case 1:
                        recipe.ScaleRecipe();
                        continue;
                    case 2:
                        recipe.QuantitiesReset();                       
                        continue;
                        
                    case 3:
                        
                        recipe.DisplayRecipe();
                        continue;
                    case 4:
                        recipe.Clear();
                        cleared = true;
                        continue;                       
                    case 5:
                        recipe.Exit();
                        break;
                    default:
                        Console.WriteLine("Invalid choice, please pick a option between 1 and 6");
                        continue;

                }

                if (choice >= 1 && choice <= 4)
                {
                    break;
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

        private List<Recipe> recipeLst = new List<Recipe>();

        //------------------------------------------------------------------------
        // Method called RecipeMeasurement which captures and stores user input 
        // about the recipe such as ingredients, quantities and measurement.
        public void RecipeInformation(Recipe recipes)
        {
            
            Console.WriteLine("Lets make a recipe!");

            // Prompts user to enter the name they'd like to give the recipe.   
            Console.WriteLine("What would you like to name the recipe?");
            recipeName = Console.ReadLine();

            while (string.IsNullOrEmpty(recipeName))
            {
                Console.ForegroundColor = ConsoleColor.Red; // < -- Code taken from TutorialsPoint
                Console.WriteLine("Field is empty! Please enter an input", Console.ForegroundColor);
                Console.ResetColor(); // < -- Code taken from TutorialsPoint
                Console.WriteLine("What would you like to name the recipe?");
                recipeName = Console.ReadLine();
            }

            recipes.setRecipeName(recipeName);
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


            //          -----------------------------------------------------

            for (int i = 0; i < ingredientAmount; i++)
            {

                Console.WriteLine("--------INGREDIENT " + i + "-----------");
                Console.Write("Ingredient name:");
                string ingredient = Console.ReadLine();

                // Loops and captures information for each ingredient.


                while (string.IsNullOrWhiteSpace(ingredient))   // loops until the user inputs the recipe name
                {
                    Console.ForegroundColor = ConsoleColor.Red;  // < -- Code taken from TutorialsPoint
                    Console.WriteLine("*Please enter a ingredient name.*", Console.ForegroundColor);
                    Console.ResetColor(); // < -- Code taken from TutorialsPoint
                    Console.Write("Ingredient name:");
                    ingredient = Console.ReadLine();
                }

                recipes.setIngredient(ingredient);
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

                        recipes.setQuantity(quantityD);
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

                

                Console.Write("The Meansurement (teaspoon, tablespoon or cup): ");  // Only accepts teaspoon, tablespoon and cup
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

                recipes.setMeasurement(measurementInput);


                try  
                {
                    // Prompts the user to enter the amount of steps to take.
                    Console.WriteLine("\nPlease enter the number of calories: ");
                    string caloriesInput = Console.ReadLine();
                    double calories = double.Parse(caloriesInput);


                    // Checks if the input is a integer and not empty.
                    if (calories <= 0)
                    {
                        
                        Console.WriteLine("Calories must be greater than 0");  
                        
                    } else
                    {
                        recipes.setCalories(calories);
                       
                        recipes.CheckCalorieAlert();
                       
                       
                    }


                    // Prompts user to enter the food group the ingredient belongs to.   
                    Console.WriteLine("What food group does this ingredient belong to?");

                    string foodGroup;

                    Console.WriteLine(  // Information taken from sweetlife.com (sweetlife, 2022)
                        "1) Starchy foods !! [These are commonly known as Carbohydrates. These have a great source of energy and nutrients.]"
                        + "\n2) Vegetables and fruits  [These contain alot of vitimins and minerals as well as fibre.]"
                        + "\n3) Dry beans, peas, lentils and soya  [These are low in fat being a good source of fibre, vitimins and minerals.]"
                        + "\n4) Chicken, fish, meat and eggs  [Contains a good amount of protein, vitamins and minerals.]"
                        + "\n5) Milk and dairy products  [Has alot of calcium as well as protein and vitamins.]"
                        + "\n6) Fats and oil  [These plant based fats are way healthier than saturated fats.]"
                        + "\n7) Water  [Your body constantly loses water throughout the day and night. Important to keep hydrated.]"
                        );

                    Console.WriteLine("What food group does this ingredient belong to?");
                    foodGroup = Console.ReadLine();

                    while (string.IsNullOrEmpty(foodGroup))
                    {
                        Console.ForegroundColor = ConsoleColor.Red; // < -- Code taken from TutorialsPoint
                        Console.WriteLine("Field is empty! Please enter an input", Console.ForegroundColor);
                        Console.ResetColor(); // < -- Code taken from TutorialsPoint
                        Console.WriteLine("What food group does this ingredient belong to?");
                        foodGroup = Console.ReadLine();
                        
                    }

                    recipes.setFoodGroup(foodGroup);

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
                    Console.WriteLine("Field is empty. Please enter the number of calories", Console.ForegroundColor);
                    Console.ResetColor(); // < -- Code taken from TutorialsPoint
                }

               


            }


           
        }



        //----------------------------------------------------------------------
        // Method called CountingSteps which asks the user how many steps they'd
        // like to add and captures a description for each.
        public void CountingSteps(Recipe recipes) 
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
                recipes.setDescription(description);
                recipeLst.Add(recipes);

            }

        }


        //----------------------------------------------------------------------------
        // Method called ScaleRecipe which scales the recipe up or down depending
        // on the users choice.
        public void ScaleRecipe()
        {
            displayRecipeNames();
            Console.WriteLine("Enter the number of the recipe you would like to scale: ");
            int recipeChoice = int.Parse(Console.ReadLine());

            recipeLst[recipeChoice - 1].scaling();
        }

        //-----------------------------------------------------------------------------
        // Method called QuantitiesReset which resets the quantities back to the original
        // scale before scaling up or down.
        public void QuantitiesReset()
        {

            displayRecipeNames();
            Console.WriteLine("Enter the number of the recipe you would like to reset: ");
            int recipeChoice = int.Parse(Console.ReadLine());

            Console.WriteLine("Are you sure you'd like to reset the data?");
                Console.WriteLine("(yes) to reset.\n(no) to keep data");
                string reset = Console.ReadLine();

                if(reset.Equals("yes")) {

                    

                    recipeLst[recipeChoice - 1].reset();

                Console.WriteLine("All done!");
            } else
            {
                Console.WriteLine("Data has not been reset");
            }
                            
        }

        //----------------------------------------------------------------------
        // Method called DisplayRecipe which displays the recipe information.
        public void DisplayRecipe()
        {
            if (recipeLst.Count > 0)
            {
                displayRecipeNames();
                Console.WriteLine("Enter the number of the recipe you would like to view: ");
                int recipeChoice = int.Parse(Console.ReadLine());

                recipeLst[recipeChoice - 1].printRecipeValues();
            }
              else
            {
                Console.WriteLine("There are no recipes to be displayed.");
            }
        }


        public void displayRecipeNames()
        {
            Console.ForegroundColor = ConsoleColor.Blue; // < -- Code taken from TutorialsPoint
            recipeLst.Sort((x, y) => x.getRecipeName().CompareTo(y.getRecipeName()));

            for (int i = 0; i < recipeLst.Count; i++)
            {
              
                Console.WriteLine((i + 1) + " " + recipeLst[i].getRecipeName(), Console.ForegroundColor);


            }
            Console.ResetColor(); // < -- Code taken from TutorialsPoint
        }



        //-------------------------------------------------------------------------------
        // Method called Clear which clears all the recipe input.
        public void Clear()
        {
            while (true)
            {

                displayRecipeNames();
                Console.WriteLine("Enter the number of the recipe you would like to clear: ");
                int recipeChoice = int.Parse(Console.ReadLine());

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

                        recipeLst[recipeChoice - 1].clearData();
                        recipeLst.Remove(recipeLst[recipeChoice - 1]);
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



    //          REFERENCES
    // sweetlife, 2022. What are the different food groups? A simple explanation.. [Online] 
    //Available at: https://sweetlife.org.za/what-are-the-different-food-groups-a-simple-explanation/
    //[Accessed 30 May 2024].

} //------------------------------------------<<< End Of File >>>-------------------------------------------------------