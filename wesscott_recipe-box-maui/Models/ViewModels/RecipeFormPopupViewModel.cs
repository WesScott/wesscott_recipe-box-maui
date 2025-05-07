using System.Collections.ObjectModel;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core.Extensions;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using wesscott_recipe_box_maui.Extensions.CommonUtils;
using wesscott_recipe_box_maui.Models.DataModels;
using wesscott_recipe_box_maui.Views;

namespace wesscott_recipe_box_maui.Models.ViewModels
{
    public partial class RecipeFormPopupViewModel : ObservableObject
    {
        private Recipe? _formRecipe;
        private bool _isExistingRecipe;

        public RecipeFormPopupViewModel() { _isExistingRecipe = false; }
        public RecipeFormPopupViewModel(Recipe recipeToEdit)
        {
            _formRecipe = recipeToEdit;
            PopulateRecipe();
            _isExistingRecipe = true;
        }

        [ObservableProperty]
        string? recipeName;

        [ObservableProperty]
        string? recipeDescription;

        [ObservableProperty]
        string? recipeInstructions;

        [ObservableProperty]
        string? recipeSteps;

        [ObservableProperty]
        ObservableCollection<Ingredient>? recipeIngredients;

        [ObservableProperty]
        bool isEditingIngredient = false;

        [ObservableProperty]
        Ingredient? selectedIngredient;

        [ObservableProperty]
        string? ingredientEditorName;

        [ObservableProperty]
        string? ingredientEditorAmount;

        [ObservableProperty]
        string? ingredientEditorUnit;

        public void PopulateRecipe()
        {
            if (_formRecipe == null)
                return;

            RecipeName = _formRecipe.Name;
            RecipeDescription = _formRecipe.Description;
            RecipeInstructions = _formRecipe.Instructions;
            RecipeSteps = string.Join("\n", _formRecipe.Steps.ToArray());
            RecipeIngredients = _formRecipe.Ingredients;
        }

        [RelayCommand]
        public async Task Cancel()
        {
            await CommonUtils.ClearPopupStack();
        }

        [RelayCommand]
        public void Apply()
        {

        }

        [RelayCommand]
        public void EditIngredient(Ingredient ingredient)
        {
            SelectedIngredient = ingredient;
            IsEditingIngredient = true;
        }

        [RelayCommand]
        public void ApplyIngredientEdits()
        {
            IsEditingIngredient = false;

            if (SelectedIngredient == null)
            {
                _ = Toast.Make($"No selected Ingredient found to edit").Show();
                return;
            }

            // A valid ingredient must have at least an amount and name
            if (string.IsNullOrEmpty(IngredientEditorName))
            {
                _ = Toast.Make($"Please provide a valid name the ingredient").Show();
                return;
            }

            // Create the ingredient object
            Ingredient editedIngredient;
            if (string.IsNullOrEmpty(IngredientEditorUnit) || string.IsNullOrEmpty(IngredientEditorAmount))
            {
                editedIngredient = new Ingredient(IngredientEditorName);
            }
            else
            {
                editedIngredient = new Ingredient(IngredientEditorName, IngredientEditorAmount, IngredientEditorUnit);
            }

            // Delete the old ingredient from the list, and add the new one
            RecipeIngredients?.Remove(SelectedIngredient);
            RecipeIngredients?.Add(editedIngredient);

            SetIngredientEditorToDefault();
        }

        private void SetIngredientEditorToDefault()
        {
            IsEditingIngredient = false;
            SelectedIngredient = null;
            IngredientEditorName = string.Empty;
            IngredientEditorAmount = string.Empty;
            IngredientEditorUnit = string.Empty;
        }

        [RelayCommand]
        public void CancelIngredientEdits()
        {
            SetIngredientEditorToDefault();
        }

        [RelayCommand]
        public void ApplyWholeRecipe()
        {
            // Try to craft the new recipe with all the pieces
            try
            {
                Recipe editedRecipe;
                editedRecipe = new Recipe(RecipeName, RecipeDescription, RecipeIngredients!, RecipeSteps.Split('\n').ToObservableCollection(), RecipeInstructions);
            }
            catch (Exception ex)
            {
                _ = Toast.Make($"Error creating recipe: {ex.Message}").Show();
                return;
            }
        }
    }
}
