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
        List<Ingredient>? recipeIngredients;

        [ObservableProperty]
        bool isEditingIngredient = false;

        [ObservableProperty]
        Ingredient? selectedIngredient;

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
        public void Cancel()
        {
            CommonUtils.ClearPopupStack();
        }

        [RelayCommand]
        public void Apply()
        {

        }

        [RelayCommand]
        public void EditIngredient(Ingredient ingredient)
        {
            IsEditingIngredient = true;
        }

        [RelayCommand]
        public void ApplyIngredientEdits()
        {
            IsEditingIngredient = false;
        }

        [RelayCommand]
        public void CancelIngredientEdits()
        {
            IsEditingIngredient = false;
            SelectedIngredient = null;
        }
    }
}
