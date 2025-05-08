using System.Collections.ObjectModel;
using System.Reflection.Metadata;
using System.Text.Json;
using Mopups.Pages;
using Mopups.Services;
using wesscott_recipe_box_maui.Models.DataModels;

namespace wesscott_recipe_box_maui.Extensions.CommonUtils
{
    public static partial class CommonUtils
    {
        private const string RECIPES_FILE_NAME = "recipes.json";

        public static async Task OpenPopup(PopupPage popupPage)
        {
            await MopupService.Instance.PushAsync(popupPage);
        }

        public static async Task ClearPopupStack()
        {
            await MopupService.Instance.PopAllAsync();
        }

        public static string ConvertRecipesToJsonString(this ObservableCollection<Recipe> recipes)
        {
            return JsonSerializer.Serialize(recipes);
        }

        public async static Task SaveAllRecipesToFile(ObservableCollection<Recipe> recipes)
        {
            string jsonString = recipes.ConvertRecipesToJsonString();
            string filePath = Path.Combine(FileSystem.AppDataDirectory, RECIPES_FILE_NAME);

            await File.WriteAllTextAsync(filePath, jsonString);
        }

        public async static Task<ObservableCollection<Recipe>?> GetRecipesFromFile()
        {
            string filePath = Path.Combine(FileSystem.AppDataDirectory, RECIPES_FILE_NAME);

            if (! File.Exists(filePath))
                return [];

            string jsonString = await File.ReadAllTextAsync(filePath);
            ObservableCollection<Recipe> recipes = JsonSerializer.Deserialize<ObservableCollection<Recipe>>(jsonString) ?? [];
            return recipes;
        }

        public async static Task AppendRecipeToFile(Recipe recipe)
        {
            ObservableCollection<Recipe> recipes = await GetRecipesFromFile() ?? new ObservableCollection<Recipe>();
            recipes.Add(recipe);

            // Remove duplicate recipes
            var distinctRecipes = recipes.GroupBy(r => r.Name).Select(g => g.First()).ToList();

            await SaveAllRecipesToFile(new ObservableCollection<Recipe>(distinctRecipes));
        }

        // Remove recipe from file
        public async static Task RemoveRecipeFromFile(Recipe recipe)
        {
            ObservableCollection<Recipe> recipes = await GetRecipesFromFile() ?? new ObservableCollection<Recipe>();
            recipes.Remove(recipe);

            await SaveAllRecipesToFile(recipes);
        }

    }
}
