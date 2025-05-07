using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Mopups.Services;
using wesscott_recipe_box_maui.Extensions.CommonUtils;
using wesscott_recipe_box_maui.Models.DataModels;
using wesscott_recipe_box_maui.Views;

namespace wesscott_recipe_box_maui.Models.ViewModels
{
    public partial class IngredientFormPopupViewModel : ObservableObject
    {
        private Ingredient? _formIngredient;
        public IngredientFormPopupViewModel() { }
        public IngredientFormPopupViewModel(Ingredient ingredient)
        {
            _formIngredient = ingredient;
            PopulateIngredient();
        }

        [ObservableProperty]
        string? ingredientName;

        [ObservableProperty]
        string? ingredientQuantity;

        [ObservableProperty]
        string? ingredientUnit;

        public void PopulateIngredient()
        {
            if (_formIngredient == null)
                return;

            IngredientName = _formIngredient.Name;
            IngredientQuantity = _formIngredient.Amount;
            IngredientUnit = _formIngredient.Unit;
        }

        [RelayCommand]
        public static async Task Cancel()
        {
            await MopupService.Instance.PopAsync();
        }
    }
}
