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
    /// Interaction logic for Steps.xaml
    /// </summary>
    
    // --------------------------------------------------
    //                  Steps Class
    public partial class Steps : Window
    {

        private string stepDescriptions {  get; set; }      // Getter and Setter

        private int numSteps;
        private int count;                              // Declaring variables
        private Recipe recipe;
        private int numRecipe;

        Recipe recipes = new Recipe();
        private List<Recipe> recipeLst;

        //-------------------------------------------
        public Steps() { 
            InitializeComponent(); 
            numSteps = 0;
            count = 1;
            recipe = null;
            numRecipe = 0;
        }
       
        // -------------------------------------------------------------------
        // Sets variables to variables being passed through
        public Steps(Recipe rec,int num,List<Recipe>recLst,int numrec): this() 
        {        
            recipeLst = recLst;            
            numSteps = num; 
            recipe = rec;
            numRecipe = numrec;
        }

        // -------------------------------------------------------------------
        // Sets the descriptions for each recipe
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(StepDescriptionTextBox.Text)) {
                MessageBox.Show("the Description must not be empty!!!");
            }
            else
            {
           
                stepDescriptions = StepDescriptionTextBox.Text;
                recipe.setDescription(stepDescriptions);
                count++;
                if (count >numSteps) {
                    recipeLst.Add(recipe);
                    MessageBox.Show("Steps information added successfully");
                    numRecipe--;
                    if (numRecipe !=0) {
                        CreateRecipe createRecipe = new CreateRecipe(new Recipe(),numRecipe,recipeLst);

                    }
                                      
                    this.Close();
                    
                }
            }

        }
    }
} // --------------------------------<<< End Of File >>>--------------------------------------------
