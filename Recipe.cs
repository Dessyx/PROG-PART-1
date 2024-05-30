﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PART_1
{
    internal class Recipe
    {
        // Initializing Lists inside the method.
        private RecipeInformation<string> recipeNameLst;  
        private RecipeInformation<string> ingredientsLst;
        private RecipeInformation<double> quantitiesLst;
        private RecipeInformation<string> measurementLst;
        private RecipeInformation<string> stepDescriptionsLst;

        public Recipe()
        {
            recipeNameLst = new RecipeInformation<string>();  
            ingredientsLst = new RecipeInformation<string>();
            quantitiesLst = new RecipeInformation<double>();
            measurementLst = new RecipeInformation<string>();
            stepDescriptionsLst = new RecipeInformation<string>();
        }

        public void setRecipeName(string name) {
            recipeNameLst.add(name);
        }

        public string getRecipeName()
        {
            return recipeNameLst.returnValue(0);
        }
        public void setIngredient(string name)
        {
            ingredientsLst.add(name);
        }
       public void setQuantity(double quantity)
        {
            quantitiesLst.add(quantity);
        }
        public void setMeasurement(string measurement)
        {
            measurementLst.add(measurement);
        }
        public void setDescription(string description)
        {
            stepDescriptionsLst.add(description);
        }


        public void printRecipeValues()
        {
            Console.WriteLine("------------------------------------");
            Console.ForegroundColor = ConsoleColor.Magenta; // < -- Code taken from TutorialsPoint
            Console.WriteLine("           RECIPE: " + getRecipeName());
            Console.ResetColor(); // < -- Code taken from TutorialsPoint
            Console.WriteLine("------------------------------------");

            for (int i = 0; i < ingredientsLst.getSize(); i++)
            {   // Displays all ingredients as well as their quantities and measurememts.     
                Console.WriteLine("*  " + quantitiesLst.returnValue(i) + " " + measurementLst.returnValue(i) + " of " + ingredientsLst.returnValue(i));

            }

            int numbering = 1; // Numbering for displaying the steps
            Console.WriteLine("\nSteps:");
            for (int j = 0; j < stepDescriptionsLst.getSize(); j++)
            {
                Console.WriteLine(numbering + " - " + stepDescriptionsLst.returnValue(j)); // displays each step as well as its dscription.
                numbering++;
            }
        }


        public double TeaspoonToTablespoon(double quantity, int i)     // Methods that scale the quantities
        {
            return quantitiesLst.returnValue(i) / 3;
        }

        public double TablespoonToCup(double quantity, int i)
        {
            Console.WriteLine("16 ");
            return quantitiesLst.returnValue(i) / 16;
        }

        public void scaling()
        {
            
                Console.WriteLine("Lets scale the recipe! The more the merrier.");
                Console.WriteLine("\nEnter scaling factor (0.5, 2 or 3)");

                double factor = double.Parse(Console.ReadLine());

                for (int i = 0; i < quantitiesLst.getSize(); i++)
                {

                quantitiesLst.Update(i, quantitiesLst.returnValue(i) * factor);   // Multiplying the original values by the factor  
                                                                                  // and assigning the values to quantities.

                // Update units of measurement based on measurement
                switch (measurementLst.returnValue(i))
                {
                    case "teaspoon":
                        if (quantitiesLst.returnValue(i) >= 3)    // If the measurement is teaspoon + the quantity is greater than 3 
                        {                                         // which then means it is 1 tablespoon or more then the necessary conversion
                            quantitiesLst.Update(i, TeaspoonToTablespoon(quantitiesLst.returnValue(i), i));   // is performed.
                            measurementLst.Update(i, "tablespoon");
                        }
                        else if (quantitiesLst.returnValue(i) <= 3)
                        {
                            measurementLst.Update(i, measurementLst.returnCopyValue(i));
                        }
                        break;

                    case "tablespoon":                           // If the measurement is teaspoon + the quantity is greater than 16
                        if (quantitiesLst.returnValue(i) >= 16)      // which then means it is 1 cup or more then the necessary conversion
                        {                                            // is performed.
                            quantitiesLst.Update(i, TablespoonToCup(quantitiesLst.returnValue(i), i));
                            measurementLst.Update(i, "cup");
                        }
                        else if (quantitiesLst.returnValue(i) <= 3)
                        {
                            measurementLst.Update(i, measurementLst.returnCopyValue(i));
                        }
                        break;

                    case "cup":                                      // If the measurement is cup, the measurement stays the same
                        measurementLst.Update(i, "cup");
                        break;
                }


            }

            for (int i = 0; i < quantitiesLst.getSize(); i++)
            {
                Console.WriteLine();
                Console.WriteLine("*  " + quantitiesLst.returnValue(i) + " " + measurementLst.returnValue(i) + " of " + ingredientsLst.returnValue(i));
            }

            Console.WriteLine("\nAll done!");
        }


        public void clearData()
        {
            recipeNameLst = null;
            ingredientsLst = null;
            quantitiesLst = null;       // Set all Lists to null (empty)
            measurementLst = null;
            stepDescriptionsLst = null;
  
        }


    }
}
