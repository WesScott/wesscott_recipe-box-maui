using System.Collections.ObjectModel;
using CommunityToolkit.Maui.Alerts;
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
		public async Task GetAllRecipes()
		{
			RecipesLoading = true;
			RecipeSelected = false;

			try
			{
				AllRecipes = await CommonUtils.GetRecipesFromFile() ?? [];
            }
			catch
			{
				_ = Toast.Make($"Error loading recipes").Show();
				AllRecipes = [];
            }
			finally
			{
                RecipesLoading = false;
            }
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
			RecipesLoading = true;

            RecipeFormPopupPage recipeFormPopup = new RecipeFormPopupPage();
            await CommonUtils.OpenPopup(recipeFormPopup);
            AllRecipes = await CommonUtils.GetRecipesFromFile() ?? [];

            RecipesLoading = false;
        }

		[RelayCommand]
		public async Task EditRecipe()
		{
			if (SelectedRecipe == null)
				return;

            RecipesLoading = true;

            RecipeFormPopupPage recipeFormPopup = new RecipeFormPopupPage(SelectedRecipe);

            await CommonUtils.OpenPopup(recipeFormPopup);
			AllRecipes = await CommonUtils.GetRecipesFromFile() ?? [];

			
			RecipesLoading = false;
        }
	}
}
