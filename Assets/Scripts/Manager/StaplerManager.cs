using Cards;
using Port;
using ScriptableObjects;
using UnityEngine;

namespace Manager{
    public class StaplerManager: MonoBehaviour, IGameManager{
        
        [SerializeField] private EmptyCard first;
        [SerializeField] private RecipeCard recipe;
        private Recipe actualRecipe { get; set; }


        private void Update() {
            Recipe generatedRecipe = GenerateRecipe();
            if (generatedRecipe) {
                actualRecipe = generatedRecipe;
                recipe.SetRecipe(generatedRecipe);
            }
        }

        private Recipe GenerateRecipe() {
            var recipes = Managers.Shop.GetSellableRecipes();
            
            Recipe newRecipe = null;
            
            if (!first._ingredient) return null;
            
            foreach (var item in recipes) {
                if (item.Valid(first._ingredient, null)) {
                    newRecipe = item;
                }
            }
        
            return newRecipe;
        }

        public void Clean() {
            first.Clean();
            recipe.Clean();
        }

        public void AddRecipeToInventory() {
            Managers.Inventory.RemoveIngredient(first._ingredient);
            Managers.Inventory.AddRecipe(actualRecipe);
            Clean();
        }

        public Recipe ActualRecipe() {
            return actualRecipe;
        }
        
        public ManagerStatus Status { get; set; }
        public void Startup() {
            Status = ManagerStatus.Started;
        }
    }
}