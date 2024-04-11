﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

//Deslynn Fenyes
//STD: ST10251981
//Module: PROG6221

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
                        recipe.RecipeMeasurement();
                        recipe.CountingSteps();
                        break;
                    case 2:
                        recipe.DisplayRecipe();
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
        // Declaring variables
        private String recipeName;

        //Creating Arrays
        // - Class 1
        private string[] ingredients;
        private double[] quantities;
        private String[] measurement;

        // - Class 2
        private String[] stepNum;

        public void RecipeMeasurement()
        {
            Console.WriteLine("Lets make a recipe!");

            Console.WriteLine("What would you like to name the recipe?");
            recipeName = Console.ReadLine(); 

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
                Console.WriteLine("--------INGREDIENT-----------");
                Console.Write("Ingredient name:");
                ingredients[i] = Console.ReadLine();
                Console.Write("Quantity:");
                quantities[i] = double.Parse(Console.ReadLine());
                Console.Write("Meansurement (in Units): ");
                measurement[i] = Console.ReadLine();
   
            }
       
        }


        public void CountingSteps() 
        {
            // Prompts the user to enter the amount of steps to take.
            Console.WriteLine("\n Enter the number of steps: ");
            int steps = int.Parse(Console.ReadLine());

            stepNum = new String[steps];  // Declaring the array length to 
                                          // the number of steps entered.

            // Capturing more recipe information.
            for(int i = 0; i < steps; i++) 
            {
                int numbering = 1;
                Console.WriteLine("Step " + numbering + ": ");

                    Console.WriteLine("Description: ");
                    stepNum[i] = Console.ReadLine();

                numbering++;
            }

            Console.WriteLine("\nYay! Your recipe has been captured.");

        }
       
        public void DisplayRecipe()
        {
            Console.WriteLine("------------------------------------");
            Console.WriteLine("     RECIPE: " + recipeName);
            Console.WriteLine("------------------------------------");

            Console.WriteLine("\nIngredients:");
            int numbering = 1;
            for (int i = 0; i < ingredients.Length; i++) {        
                  Console.WriteLine("\n" + numbering + quantities[i] + " " + measurement[i] + " of " + ingredients[i]);
                  numbering++;         
            }

            Console.WriteLine("\nSteps:");
            for(int i = 0;i < stepNum.Length;i++)
            {
                Console.WriteLine( i + 1 + " - " + stepNum[i]); // displays each step as well as its dscription.
            }

        }

    }
}
