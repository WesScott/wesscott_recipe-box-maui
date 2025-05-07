using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using wesscott_recipe_box_maui.Extensions.CommonUtils;
using wesscott_recipe_box_maui.Models.DataModels;
using wesscott_recipe_box_maui.Views;

namespace wesscott_recipe_box_maui.Models.ViewModels
{
	public partial class MainPageViewModel : ObservableObject
	{
		[ObservableProperty]
		bool recipesLoading = true;

		[ObservableProperty]
		Recipe? selectedRecipe;

		[ObservableProperty]
		bool recipeSelected = false;

		[ObservableProperty]
		ObservableCollection<Recipe> allRecipes = new();

		[RelayCommand]
		public void GetAllRecipes()
		{
			RecipesLoading = true;
			RecipeSelected = false;

			Ingredient testIng1 = new Ingredient("TestIngredient 1");
            ObservableCollection<Ingredient> testIngList = new ObservableCollection<Ingredient>();
			testIngList.Add(testIng1);

			Recipe testRecipe = new Recipe("TestRecipe", "This is a test recipe", testIngList, new ObservableCollection<string>(), "Mix And Cook");

			AllRecipes.Add(testRecipe);

            Ingredient testIng2 = new Ingredient("Cumin", "1", "tsp");
            Ingredient testIng3 = new Ingredient("1 Onion");
            ObservableCollection<Ingredient> testIngList2 = new ObservableCollection<Ingredient>();
            testIngList2.Add(testIng2);
            testIngList2.Add(testIng3);

            ObservableCollection<string> recipeSteps = new ObservableCollection<string>();
            string step1 = "1) Mix Well";
            string step2 = "2) Cook it";
            recipeSteps.Add(step1);
            recipeSteps.Add(step2);

            Recipe testRecipe2 = new Recipe("Test Recipe 2", "This is a second test recipe", testIngList2, recipeSteps, "Mix And Cook as well");

            AllRecipes.Add(testRecipe2);

            RecipesLoading = false;
        }

		[RelayCommand]
		public void ChooseRecipe(Recipe chosenRecipe)
		{
			if (chosenRecipe == null)
			{
				RecipeSelected = false;
				return;
			}

			SelectedRecipe = chosenRecipe;
			RecipeSelected = true;
		}

		[RelayCommand]
		public async Task AddRecipe()
		{
            RecipeFormPopupPage recipeFormPopup = new RecipeFormPopupPage();
            await CommonUtils.OpenPopup(recipeFormPopup);
        }

		[RelayCommand]
		public async Task EditRecipe()
		{
			if (SelectedRecipe == null)
				return;

            RecipeFormPopupPage recipeFormPopup = new RecipeFormPopupPage(SelectedRecipe);
            await CommonUtils.OpenPopup(recipeFormPopup);
        }
	}
}
