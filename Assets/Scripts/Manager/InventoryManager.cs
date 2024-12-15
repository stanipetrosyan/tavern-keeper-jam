using System.Collections.Generic;
using System.Linq;
using Port;
using ScriptableObjects;
using UnityEngine;

namespace Manager{
    public class InventoryManager: MonoBehaviour, IGameManager {
        private List<Ingredient> ingredients;
        private List<Recipe> recipes;
    
        public ManagerStatus Status { get; set; }

        public void Startup() {
            ingredients = new List<Ingredient>();
            recipes = new List<Recipe>();
        
            Status = ManagerStatus.Started;
        }
    
        public void AddIngredient(Ingredient ingredient) {
            ingredients.Add(ingredient);
        }

        public void RemoveIngredient(Ingredient ingredient) {
            ingredients.Remove(ingredient);
        }

        public Ingredient[] GetIngredients() {
            return ingredients.ToArray();
        }

        public Ingredient GetIngredient(string name) {
            return ingredients.FirstOrDefault(ingredient => ingredient.name == name);
        }

        public void AddRecipe(Recipe recipe) {
            recipes.Add(recipe);
        }

        public Recipe[] GetRecipes() {
            return recipes.ToArray();
        }

        public Recipe GetRecipe(string name) {
            return recipes.FirstOrDefault(recipe => recipe.name == name);
        }

    }
}
