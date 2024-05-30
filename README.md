<<<<<<< HEAD
=======
# PART 2

>>>>>>> 098169618cd370c5c2ad4054c09eebb0f09b3922
DESCRIPTION

The recipe app project is a program built with C# that allows users to create and store their own recipes
as well as manipulate the data such as scaling the recipe up or down and reseting to the original values. 
With the new updates, the user can store the amount of calories and which food group the ingredient belongs to.
The program is built for users who love to cook and would like to store their recipes as well as calculate 
the correct quantities when scaling their recipe. 

GETTING STARTED

1. Within the repository, click on the "<> Code" drop down on the far right 
   next to the "Go to file" and "+" buttons.
2. On the Local tab, click on the last option: "Download ZIP".
3. Once the zip file has downloaded, open your local file explorer.
4. Go to your Downloads.
5. Open the "PROG-PART-1-master.zip" folder, should be most recent in Downloads.
6. Open the "PROG-PART-master" folder, this folder is not a zip.
7. Open the PART 1.sln file, would be the 6th option.
8. The project should begin loading.
9. Once fully loaded, on the top in the middle, double click the start button.
10.The program will compile and you may use the program. 


UPDATES

Based on the lecturer feedback:

"Great effort. Well done! 
1. Make sure that the units of measurement are changed back correctly, when resetting the recipe back to its original values
2. Make sure to add a comment to state where the entry point of the program is"

In part 2, I have created a Generic Class called RecipeInformation which allows me perform functions in a much easier way, 
making the code neater and reusible. I made a Reset method which sets the values to the oroginal values. 
There are two lists, one called items and another called initialCopy which holds the values first entered.
When the user wants to reset their recipe, they are prompted to choose which recipe and based on their choice,
I call the method from the delegate class to reset the quanitity, measurement and ingredient name. 
By doing this, i can reuse code, making the code much cleaner. 

I also added a comment in the main Program class to indicate where the entry point is.


FEATURES

1: The recipe app allows the user to create a recipe with attributes such as:
- recipe name
- ingredient name, quantity and measurement (for example, 1 teaspoon of coffee powder)
- provide steps to follow
- Amount of calories
- What food group the ingredient belongs to

2: Scale the recipe:
- User can choose which recipe they'd like to scale.
- The user can decide if the want to scale the quantities of the ingredients up or down.

3: Reset quantities:
- User can choose which recipe they'd like to reset.
- The user can reset the quantities back to the original values entered when creating 
  the recipe.

4: Display the recipe:
- User can choose which recipe they'd like to display.
- Displays the recipe to the user in a neat format with the scaling od ingredients and 
  the steps to follow.

5: Clear all data:
- All recipe data is cleared. This empties all fields and allows the user to enter a new
  recipe.

6: Exits the program:
- Stops the program from running.

<<<<<<< HEAD
https://github.com/Dessyx/PROG-PART-1/tree/PROG-PART-2
=======
https://github.com/Dessyx/PROG-PART-1/tree/PROG-PART-2
>>>>>>> 098169618cd370c5c2ad4054c09eebb0f09b3922
