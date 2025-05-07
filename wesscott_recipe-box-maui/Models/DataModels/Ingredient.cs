using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wesscott_recipe_box_maui.Models.DataModels
{
    public class Ingredient
    {
        public string Name { get; set; }
        public string? Amount { get; set; }
        public string? Unit { get; set; }

        public Ingredient(string name, string amount, string unit)
        {
            Name = name;
            Amount = amount;
            Unit = unit;
        }
        public Ingredient(string name, string amount)
        {
            Name = name;
            Amount = amount;
        }
        public Ingredient(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            if(string.IsNullOrEmpty(Amount))
            {
                return $"• {Name}";
            }

            return $"• {Amount} {Unit} of {Name}";
        }
    }
}
