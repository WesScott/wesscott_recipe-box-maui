using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wesscott_recipe_box_maui.Models.DataModels
{
    public class Recipe
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public List<string> Steps { get; set; }
        public string? Instructions { get; set; }

        public ImageSource? Image { get; set; }

        public Recipe(string name, string description, List<Ingredient> ingredients, List<string> steps)
        {
            Name = name;
            Description = description;
            Ingredients = ingredients;
            Steps = steps;
        }
        public Recipe(string name, string description, List<Ingredient> ingredients, List<string> steps, string instructions)
        {
            Name = name;
            Description = description;
            Ingredients = ingredients;
            Steps = steps;
            Instructions = instructions;
        }
    }
}
