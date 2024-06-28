﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeAPP
{
    //-------------------------------------------------------------------------
    //                          Recipe Class
    public class Recipe
    {
        // Initializing Lists.
        public bool IsChecked { get; set; }
        private RecipeInformation<string> recipeNameLst;  // Generic lists
        private RecipeInformation<string> ingredientsLst;
        private RecipeInformation<double> quantitiesLst;
        private RecipeInformation<string> measurementLst;
        private RecipeInformation<string> stepDescriptionsLst;
        private RecipeInformation<double> caloriesLst;
        private RecipeInformation<string> foodGroupLst;

        //---------------------------------------------------
        public Recipe()
        {
            recipeNameLst = new RecipeInformation<string>();
            ingredientsLst = new RecipeInformation<string>();
            quantitiesLst = new RecipeInformation<double>();
            measurementLst = new RecipeInformation<string>();
            stepDescriptionsLst = new RecipeInformation<string>();
            caloriesLst = new RecipeInformation<double>();
            foodGroupLst = new RecipeInformation<string>();
        }


        //-----------------------------------------------------
        //   Getters and setters
        public void setRecipeName(string name)  // Sets recipe names
        {
            recipeNameLst.add(name);
        }

        //-----------------------------------------------------
        public string getRecipeName() // gets recipe names
        {
            return recipeNameLst.returnValue(0);
        }

        //-----------------------------------------------------
        public void setIngredient(string name) // sets ingredient names
        {
            ingredientsLst.add(name);
        }

        //-----------------------------------------------------
        public List<string> getIngredient()
        {
            return ingredientsLst.getItems();
        }

        //-----------------------------------------------------
        public void setQuantity(double quantity) // sets quantities
        {
            quantitiesLst.add(quantity);
        }

        //-----------------------------------------------------
        public void setMeasurement(string measurement)  // sets measurement
        {
            measurementLst.add(measurement);
        }

        //-----------------------------------------------------
        public void setDescription(string description)  //sets description of the steps
        {
            stepDescriptionsLst.add(description);
        }
        public List<string> getStepsDescription()
        {
            return stepDescriptionsLst.getItems();
        }

        //-----------------------------------------------------
        public void setCalories(double calories)  // sets the calories
        {
            if (calories <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(calories), "Calories must be greater than 0");
            }

            caloriesLst.add(calories);
        }

        //-----------------------------------------------------
        public double getCalories()
        {
            return caloriesLst.returnValue(0);
        }

        //-----------------------------------------------------
        public void setFoodGroup(string group)  // sets the food group
        {
            foodGroupLst.add(group);
        }

        //-----------------------------------------------------
        public string getFoodGroup()
        {
            return foodGroupLst.returnValue(0);
        }

        //-----------------------------------------------
        // calculates the total calories
        public double calculateCalories() 
        {
            double totalCalories = 0;
            for (int i = 0; i < caloriesLst.getSize(); i++)
            {
                totalCalories += caloriesLst.returnValue(i);
            }
            return totalCalories;
        }

        //-------------------------------------------------
        // Declaring the delegate
        public delegate string CalorieExplanations(double totalCalories);

        public string getLowCalorie(double totalCalories)
        {
            return "This recipe is considered low in calories.";
        }

        public string getModerateCalorie(double totalCalories)
        {
            return "This recipe is considered moderate calories.";
        }

        public string getHighCalorie(double totalCalories)
        {
            return "This recipe is considered high in calories.";
        }

        //-----------------------------------------------
        // displays the info based on calorie amount
        public CalorieExplanations GetCalorieExplanation(double totalCalories) 
        {
            if (totalCalories < 200)
            {
                return getLowCalorie;
            }
            else if (totalCalories <= 500)
            {
                return getModerateCalorie;
            }
            else
            {
                return getHighCalorie;
            }
        }

        //---------------------------------------------------
        public delegate void CalorieAlertDelegate(double totalCalories);  // delcaring delegate

        //---------------------------------------------------
        // warns the user if the calories excede 300
        public void CheckCalorieAlert()  
        {
            double totalCalories = calculateCalories();
            if (totalCalories > 300)
            {
                CalorieAlertDelegate calorieAlertHandler = new CalorieAlertDelegate(DisplayCalorieAlert);
                calorieAlertHandler(totalCalories);
            }
        }

        //------------------------------------------------
        // displays alerts for calories
        private void DisplayCalorieAlert(double totalCalories)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Alert: Total calories {totalCalories} exceed 300!");
            Console.ResetColor();
            Console.WriteLine("Consider reducing the amount of calories within your recipe.");
            Console.WriteLine("Excessive calorie intake can pose risks such as weight gain, obesity, " +
                              "and increased risk of chronic diseases like diabetes and cardiovascular issues.");
        }

        //------------------------------------------------
        public string printRecipeValues()
        {
            double totalCalories = calculateCalories();
            string display = "";
            CalorieExplanations explanationDelegate = GetCalorieExplanation(totalCalories);

            Console.WriteLine("------------------------------------");
            Console.ForegroundColor = ConsoleColor.Magenta; // < -- Code taken from TutorialsPoint
           display+=  " RECIPE: " + getRecipeName()+"\n";
            Console.ResetColor(); // < -- Code taken from TutorialsPoint
            Console.WriteLine("------------------------------------");

            for (int i = 0; i < ingredientsLst.getSize(); i++)
            {   // Displays all ingredients as well as their quantities and measurememts.     
                display+="*  " + quantitiesLst.returnValue(i) + " " + measurementLst.returnValue(i) + " of " + ingredientsLst.returnValue(i)+"\n";
                display +="Number of calories: " + caloriesLst.returnValue(i)+"\n";
                display+="Food group: " + foodGroupLst.returnValue(i)+"\n";

                Console.WriteLine(explanationDelegate(totalCalories) + "\n");

            }
            Console.WriteLine("Total calories: " + totalCalories);


            int numbering = 1; // Numbering for displaying the steps
            Console.WriteLine("\nSteps:");
            for (int j = 0; j < stepDescriptionsLst.getSize(); j++)
            {
                Console.WriteLine(numbering + " - " + stepDescriptionsLst.returnValue(j)); // displays each step as well as its dscription.
                numbering++;
            }
            return display;
        }
        

        //----------------------------------------------
        public double TeaspoonToTablespoon(double quantity, int i)     // Methods that scale the quantities
        {
            return quantitiesLst.returnValue(i) / 3;
        }

        //----------------------------------------------
        public double TablespoonToCup(double quantity, int i)
        {
            return quantitiesLst.returnValue(i) / 16;
        }

        //----------------------------------------------
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

        //------------------------------------------
        public void reset()  //  resets the ingedient information
        {
            quantitiesLst.Reset();
            measurementLst.Reset();

            Console.WriteLine("Ingredients reset:");
            for (int i = 0; i < quantitiesLst.getSize(); i++)
            {
                Console.WriteLine("*  " + quantitiesLst.returnValue(i) + " " + measurementLst.returnValue(i) + " of " + ingredientsLst.returnValue(i));
            }
        }

        //--------------------------------------------
        public void clearData()  // clears the data 
        {
            recipeNameLst = null;
            ingredientsLst = null;
            quantitiesLst = null;       // Set all Lists to null (empty)
            measurementLst = null;
            stepDescriptionsLst = null;


        }
       //                                END OF RECIPE CLASS
    }  // ---------------------------------------------------------------------------------------


    //--------------------------------------------------------------------------------------------
    //                                     Start of Itemn
    public class Itemn : INotifyPropertyChanged
    {
        private string _stepsDescriptions;    // Declaring variables
        private bool _isChecked;


        //----------------------------------------------
        // Method of getters and setters
        public string StepsDescriptions
        {
            get { return _stepsDescriptions; }
            set
            {
                if (_stepsDescriptions != value)
                {
                    _stepsDescriptions = value;
                    OnPropertyChanged("StepsDescriptions");
                }
            }
        }

        //------------------------------------------------
        public bool IsChecked
        {
            get { return _isChecked; }
            set
            {
                if (_isChecked != value)
                {
                    _isChecked = value;
                    OnPropertyChanged("IsChecked");
                }
            }
        }
 
        //------------------------------------------------
        public event PropertyChangedEventHandler PropertyChanged;


        //------------------------------------------------
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

} //-------------------------<<< End Of File >>>----------------------------------------
