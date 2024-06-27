using System;
using System.Collections;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RecipeAPP
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    // -----------------------------------------------------------
    //                    MainWindow Class
    public partial class MainWindow : Window
    {
        
        private int numRecipes {  get; set; }
        public string IngredientName { get; private set; }          // Getters and setters
        public double Calories { get; private set; }
        public string FoodGroup { get; private set; }

        private string ingname;
        private int cal;            // Declaring variables
        private string foodGrp;

        private List<Recipe> recipeLst;  
        private Recipe recipes;

        //-------------------------------------------------------------
        public MainWindow()
        {
            InitializeComponent();  // Entry point
            recipeLst = new List<Recipe>();
            recipes = new Recipe();
        }

        //--------------------------------------------------------------
        // Adds Creates a recipe when button is clicked
        private void AddRecipe_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(RecipeNumTextBox.Text, out int recipeCount))
            {
                /*for (int i = 0; i < recipeCount; i++)
                {
                    CreateRecipe recipeDetails = new CreateRecipe();
                    if (recipeDetails.ShowDialog() == true)
                    {
                        recipeLst.Add(recipes);
                    }
                }*/

                /*MessageBox.Show($"You have added {recipes.Count} recipes.");*/
                /*int.Parse(RecipeNumTextBox.Text,*/
                int num = int.Parse(RecipeNumTextBox.Text);
                CreateRecipe recipeDetails = new CreateRecipe(recipes, num,recipeLst); 

                /*                MessageBox.Show($"You have added {recipes.Count} recipes.");*/
                recipeDetails.Show();
            }
            else
            {
                MessageBox.Show("Please enter a valid number.");
            }
        }

        //----------------------------------------------------------------
        // Filters the recipes by the input/criteria the user has given
        private void Filter_Click(object sender, RoutedEventArgs e)
        {
           /* ingname = IngredientFilterTextBox.Text;
            string caloriesInput = MaxCaloriesFilterTextBox.Text;
            FoodGroup = (FoodGroupComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();

            IEnumerable<Recipe> filteredRecipes = recipes;

            if (!string.IsNullOrEmpty(IngredientFilterTextBox.Text))
            {
                filteredRecipes = filteredRecipes.Where(r => IngredientName.Contains(IngredientFilterTextBox.Text, StringComparison.OrdinalIgnoreCase));
            }

            if (FoodGroupFilterComboBox.SelectedItem is ComboBoxItem selectedFoodGroup && selectedFoodGroup.Content != null)
            {
                filteredRecipes = filteredRecipes.Where(r => r.FoodGroup == selectedFoodGroup.Content.ToString());
            }

            if (int.TryParse(MaxCaloriesFilterTextBox.Text, out int maxCalories))
            {
                filteredRecipes = filteredRecipes.Where(r => int.TryParse(r.Calories, out int calories) && calories <= maxCalories);
            }*/
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
           
        }

        //------------------------------------------------------------------
        // Displays the reccipes in alphabetical order when button is cllicked
        private void ShowRecipes_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0;i < recipeLst.Count; i++)
            {
                recipeDisplaytxt.Text+= $"{i + 1}. {recipeLst[i].getRecipeName()}\n";   // Displays the recipes in the text box
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    } //----------------------------------------------------------------------------------------------------------------------
      //                                  End of MainWindow Class

    //          REFERENCES
    // sweetlife, 2022. What are the different food groups? A simple explanation.. [Online] 
    //Available at: https://sweetlife.org.za/what-are-the-different-food-groups-a-simple-explanation/
    //[Accessed 30 May 2024].

} //------------------------------------------------<<< End Of File >>> ------------------------------------------------------
