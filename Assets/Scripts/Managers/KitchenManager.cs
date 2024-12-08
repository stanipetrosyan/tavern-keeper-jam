using Unity.VisualScripting;
using UnityEngine;

public class KitchenManager : MonoBehaviour, IGameManager{
    
    [SerializeField] private Recipe[] recipes;

    [SerializeField] private EmptyCard first;
    [SerializeField] private EmptyCard second;
    [SerializeField] private RecipeCard recipe;


    private void Update() {
        Recipe recipe = GenerateRecipe();
        if (recipe != null) {
            this.recipe.SetRecipe(recipe);
        }
    }

    private Recipe GenerateRecipe() {
        Recipe newRecipe = null;

        
        
        // Devono essere di tipo empty card 
        if (first._ingredient != null && second._ingredient != null) {
            foreach (var item in recipes) {
                if (item.Valid(first._ingredient, second._ingredient)) {
                    newRecipe = item;
                    Debug.Log("Creating recipe");
                }
            }
        }
        
        
        return newRecipe;
    }
    
    
    public ManagerStatus Status { get; set; }
    public void Startup() {
        Status = ManagerStatus.Started;
    }
    

  
}