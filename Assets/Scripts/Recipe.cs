using UnityEngine;

public class Recipe : ScriptableObject{
    public Ingredient[] necessaryIngredients;
    public Sprite icon;
    public string recipeName;


    public Recipe Create(Ingredient[] ingredients) {
        if (necessaryIngredients.Length != ingredients.Length) return null;
        
        
        return CreateInstance<Recipe>();
    }
}