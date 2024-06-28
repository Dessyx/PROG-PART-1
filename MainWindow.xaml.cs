using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using static System.Net.Mime.MediaTypeNames;

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
        public ObservableCollection<Itemn> Items { get; set; }

        private List<Recipe> recipeLst;  
        private Recipe recipes;

        //-------------------------------------------------------------
        public MainWindow()
        {
            InitializeComponent();  // Entry point
            recipeLst = new List<Recipe>();
            recipes = new Recipe();
            /*//***//*LoadData();*/
            DataContext = this;
            
        }

        private void LoadData(int index)
        {


            var sortedRecipeList = recipeLst.OrderBy(recipe => recipe.getRecipeName()).ToList();

            Items = new ObservableCollection<Itemn>();

            foreach (var step in sortedRecipeList[index - 1].getStepsDescription())
            {
                Items.Add(new Itemn { StepsDescriptions = step, IsChecked = false });
            }

           

            DisplayStepsbx.ItemsSource = Items;
        }

        //--------------------------------------------------------------
        // Adds Creates a recipe when button is clicked
        private void AddRecipe_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(RecipeNumTextBox.Text, out int recipeCount))
            {
                
                int num = int.Parse(RecipeNumTextBox.Text);
                CreateRecipe recipeDetails = new CreateRecipe(recipes, num,recipeLst,false); 

                /*                MessageBox.Show($"You have added {recipes.Count} recipes.");*/
                recipeDetails.Show();
            }
            else
            {
                MessageBox.Show("Please enter a valid number.");
            }
        }

        //----------------------------------------------------------------
        private void Filter_Click(object sender, RoutedEventArgs e)
        {
           
            List<Recipe> filteredrec = Filtercipes();

            displayLstbx.Items.Clear(); // Clear any existing items
            foreach (var recipe in filteredrec)
            {
                displayLstbx.Items.Add(recipe.getRecipeName());
            }


        }

        //-----------------------------------------------------------------
        // Filters the recipes by the input/criteria the user has given
        public List<Recipe> Filtercipes()
        {

            ingname = IngredientFilterTextBox.Text;
            string caloriesInput = MaxCaloriesFilterTextBox.Text;
            string foodGroup = (FoodGroupFilterComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();

            string maxstr = MaxCaloriesFilterTextBox.Text;
            int maxCalories = -1;
            if (!string.IsNullOrEmpty(maxstr))
            {
                maxCalories = int.Parse(maxstr);
            }



            var filteredRecipes = recipeLst.Where(r =>
            {
                bool matches = true;

                if (!string.IsNullOrEmpty(ingname))
                {
                    matches &= r.getIngredient().Contains(ingname, StringComparer.OrdinalIgnoreCase);
                }

                if (!string.IsNullOrEmpty(foodGroup))
                {
                    matches &= string.Equals(r.getFoodGroup(), foodGroup, StringComparison.OrdinalIgnoreCase);
                }

                if (maxCalories != -1)
                {
                    matches &= r.getCalories() <= maxCalories;
                }

                return matches;
            }).ToList();

            return filteredRecipes;
        }

 

        //------------------------------------------------------------------
        // Displays the reccipes in alphabetical order when button is cllicked
        private void ShowRecipes_Click(object sender, RoutedEventArgs e)
        {
            var sortedRecipeList = recipeLst.OrderBy(recipe => recipe.getRecipeName()).ToList();

            for (int i = 0;i < recipeLst.Count; i++)
            {
                recipeDisplaytxt.Text+= $"{i + 1}. {sortedRecipeList[i].getRecipeName()}\n";   // Displays the recipes in the text box
            }
        }

        // ----------------------------------------------------------------------
        // Displays recipe information when button is clicked
        private void DisplayRecipe_Click(object sender, RoutedEventArgs e)
        {
            var sortedRecipeList = recipeLst.OrderBy(recipe => recipe.getRecipeName()).ToList();
            int option = int.Parse(InputDislayTxt.Text);
            DisplayRecipeTextBox.Text = sortedRecipeList[option-1].printRecipeValues();
        }

        //-----------------------------------------------------------------------
        // Exits the application
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int option = int.Parse(InputDislayTxt.Text);
            LoadData(option);
        }
    } //----------------------------------------------------------------------------------------------------------------------
      //                                  End of MainWindow Class

    //          REFERENCES
    // sweetlife, 2022. What are the different food groups? A simple explanation.. [Online] 
    //Available at: https://sweetlife.org.za/what-are-the-different-food-groups-a-simple-explanation/
    //[Accessed 30 May 2024].

} //------------------------------------------------<<< End Of File >>> ------------------------------------------------------
