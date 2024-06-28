﻿using System;
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
    
    // ---------------------------------------------------------
    //                 CreateRecipe Class
    public partial class CreateRecipe : Window
    {
        private int numRecipes;
        private int count;          // Declaring variables
        private Recipe recipe;
        private int ingrednum;

        public string RecipeName { get; private set; }       // Getters and Setters
        public int IngredientAmount { get; private set; }

        private List<Recipe> recipeLst;
        Recipe recipes;

        //-------------------------------------------------------------
        public CreateRecipe()
        {
            InitializeComponent();
            numRecipes = 0;
            count = 1;
            recipe = null;                 // Initializing variables
            recipes = new Recipe();
            recipeLst = null;
            ingrednum = 0;
        }

        // ------------------------------------------------------------
        // Passing through Recipe info
        public CreateRecipe(Recipe recipes, int num, List<Recipe> recLst,bool another) : this()  
        {
            this.numRecipes = num;
            recipe = recipes;
            recipeLst = recLst;
            if (another)
            {
                numRecipelbl.Content = "Create another Recipe  ";
            }
        }

        // ------------------------------------------------------------
        // Adds recipe when button is clicked
        private void AddIngredients_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                RecipeName = RecipeNameTextBox.Text;

                if (string.IsNullOrWhiteSpace(RecipeName))
                {
                    throw new ArgumentException("Recipe name cannot be empty.");
                }

                recipe.setRecipeName(RecipeName);       // Sets recipe name

                IngredientAmount = int.Parse(NumberIngredientsText.Text);
                ingrednum = int.Parse(NumberIngredientsText.Text);

                if (IngredientAmount <= 0)
                {
                    throw new ArgumentOutOfRangeException();
                }

               // recipeLst.Add(recipe);
                count++;
                numRecipelbl.Content = "Create another Recipe  ";
                RecipeNameTextBox.Clear();          // Clears text box for the next entry
                NumberIngredientsText.Clear();
                RecipeDetails recipeDetails = new RecipeDetails(recipe, recipeLst,numRecipes,ingrednum);
                recipeDetails.Show();
                this.Close();
                
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
} //------------------------------------------------<<< End Of File >>>-------------------------------------------------------
