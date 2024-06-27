using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace RecipeAPP
{
    /// <summary>
    /// Interaction logic for RecipeDetails.xaml
    /// </summary>
    public partial class RecipeDetails : Window
    {
        public string IngredientName { get; private set; }
        public double Quantity { get; private set; }
        public string Measurement { get; private set; }
        public double Calories { get; private set; }
        public string FoodGroup { get; private set; }

        public int numSteps { get; private set; }

        Recipe recipe;
       /* CreateRecipe createRecipe = new CreateRecipe();*/
        private List<Recipe> recipeLst;
        private int numRecipe;
        private int ingNum;

        public RecipeDetails()
        {
            InitializeComponent();
            recipeLst = null;
            recipe = null;
            numRecipe = 0;
            ingNum = 0;
            addStepsbtn.IsEnabled = false;
        }

        public RecipeDetails(Recipe rec, List<Recipe> recLst,int num,int ingrdnum) : this() 
        {
            recipe = rec;
            recipeLst = recLst;
            numRecipe = num;
            ingNum = ingrdnum;
            
        }

        private void SaveRecipe(object sender, RoutedEventArgs e)
        {
            if (ingNum > 0)
            {
                IngredientName = IngredientNameTextBox.Text;
                string quantityInput = QuantityTextBox.Text;
                Measurement = MeasurementTextBox.Text;
                string caloriesInput = CaloriesTextBox.Text;
                FoodGroup = (FoodGroupComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();


                if (string.IsNullOrWhiteSpace(IngredientName))
                {
                    MessageBox.Show("Field is empty! Please enter an ingredient name.");

                }

                if (string.IsNullOrWhiteSpace(Measurement) ||
                    (Measurement != "teaspoon" && Measurement != "tablespoon" && Measurement != "cup"))
                {
                    MessageBox.Show("Invalid measurement. Please enter 'teaspoon', 'tablespoon', or 'cup'.");

                }

                if (string.IsNullOrWhiteSpace(FoodGroup))
                {
                    MessageBox.Show("Please select a food group.");

                }

                try
                {
                    Quantity = double.Parse(quantityInput);

                    if (Quantity <= 0)
                    {
                        throw new ArgumentOutOfRangeException();
                    }

                    Calories = double.Parse(caloriesInput);

                    if (Calories < 0)
                    {
                        throw new ArgumentOutOfRangeException();
                    }


                }
                catch (FormatException)
                {
                    MessageBox.Show("Invalid input. Please enter a number for the quantity.");
                }
                catch (ArgumentOutOfRangeException)
                {
                    MessageBox.Show("Quantity must be greater than 0.");
                }

                // int count = createRecipe.IngredientAmount;

                /*  for (int i = 0; i < count; i++)
                  {
                          recipes.setIngredient(IngredientName);
                          recipes.setQuantity(Quantity);
                          recipes.setMeasurement(Measurement);
                          recipes.setCalories(Calories);
                          recipes.setFoodGroup(FoodGroup);

                          recipeLst.Add(recipes);
                  }*/
                recipe.setIngredient(IngredientName);
                recipe.setQuantity(Quantity);
                recipe.setMeasurement(Measurement);
                recipe.setCalories(Calories);
                recipe.setFoodGroup(FoodGroup);
                ingNum = ingNum - 1;
                MessageBox.Show("Ingredient Saved");

                if (ingNum == 0)
                {
                   addStepsbtn.IsEnabled=true;
                }
                ClearTextboxes();
            }
           /* recipeLst.Add(recipes);*/
        }

        private void ClearTextboxes()
        {
            IngredientNameTextBox.Clear();
            QuantityTextBox.Clear();
            CaloriesTextBox.Clear();
            MeasurementTextBox.Clear();
            StepNumTextBox.Clear();

        }

        private void AddSteps_Click(object sender, RoutedEventArgs e)
        {

            numSteps = int.Parse(StepNumTextBox.Text);

            Steps steps = new Steps(recipe,numSteps,recipeLst,numRecipe);
            steps.Show();
        }
    }
}
