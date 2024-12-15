using Cards;
using Port;
using ScriptableObjects;
using UnityEngine;

namespace Manager{
    public class KitchenManager : MonoBehaviour, IGameManager{
    
        [SerializeField] private Recipe[] recipes;

        [SerializeField] private EmptyCard first;
        [SerializeField] private EmptyCard second;
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
            Recipe newRecipe = null;
            
            if (!first._ingredient || !second._ingredient) return null;
            
            foreach (var item in recipes) {
                if (item.Valid(first._ingredient, second._ingredient)) {
                    newRecipe = item;
                }
            }
        
            return newRecipe;
        }

        public void Clean() {
            first.Clean();
            second.Clean();
            recipe.Clean();
        }

        public void AddRecipeToInventory() {
            Managers.Inventory.RemoveIngredient(first._ingredient);
            Managers.Inventory.RemoveIngredient(second._ingredient);
            Managers.Inventory.AddRecipe(actualRecipe);
            Clean();
        }
    
        public ManagerStatus Status { get; set; }
        public void Startup() {
            Status = ManagerStatus.Started;
        }
    }
}