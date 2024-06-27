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
    /// Interaction logic for CreateRecipe.xaml
    /// </summary>
    public partial class CreateRecipe : Window
    {
        public string RecipeName { get; private set; }
        public int IngredientAmount { get; private set; }

        Recipe recipes;
        public CreateRecipe()
        {
            InitializeComponent();
            recipes = new Recipe();
        }

        private void AddIngredients_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                RecipeName = RecipeNameTextBox.Text;

                if (string.IsNullOrWhiteSpace(RecipeName))
                {
                    throw new ArgumentException("Recipe name cannot be empty.");
                }

                recipes.setRecipeName(RecipeName);

                IngredientAmount = int.Parse(NumberIngredientsText.Text);

                if (IngredientAmount <= 0)
                {
                    throw new ArgumentOutOfRangeException();
                }

                RecipeDetails recipeDetails = new RecipeDetails();
                recipeDetails.Show();


                Close();
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid input. Please enter a number for the ingredient amount.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Ingredient amount must be greater than 0.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
