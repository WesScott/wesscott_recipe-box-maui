using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace wesscott_recipe_box_maui.Models.DataModels
{
    public class Recipe
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("description")]
        public string? Description { get; set; }
        [JsonPropertyName("ingredients")]
        public ObservableCollection<Ingredient> Ingredients { get; set; }
        [JsonPropertyName("steps")]
        public ObservableCollection<string> Steps { get; set; }
        [JsonPropertyName("instructions")]
        public string? Instructions { get; set; }

        [JsonConstructor]
        public Recipe(string name, string? description, ObservableCollection<Ingredient> ingredients, ObservableCollection<string> steps, string? instructions)
        {
            Name = name;
            Description = description;
            Ingredients = ingredients;
            Steps = steps;
            Instructions = instructions;
        }

        public Recipe(string name, string? description, ObservableCollection<Ingredient> ingredients, ObservableCollection<string> steps)
            : this(name, description, ingredients, steps, null)
        {
        }

    }
}
