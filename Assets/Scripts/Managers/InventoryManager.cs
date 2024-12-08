using System.Collections.Generic;
using UnityEngine;

public class InventoryManager: MonoBehaviour, IGameManager {
    private List<Ingredient> ingredients;
    private List<Recipe> recipes;
    
    public ManagerStatus Status { get; set; }

    public void Startup() {
        ingredients = new List<Ingredient>();
        recipes = new List<Recipe>();
        
        Status = ManagerStatus.Started;
    }
    
    
    // news method to use
    public void AddIngredient(Ingredient ingredient) {
        throw new System.NotImplementedException();
    }

    public Ingredient[] GetIngredients() {
        throw new System.NotImplementedException();
    }

    public void AddRecipe(Recipe recipe) {
        throw new System.NotImplementedException();
    }

    public Recipe[] GetRecipes() {
        throw new System.NotImplementedException();
    }

}
