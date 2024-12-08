using UnityEngine;

[CreateAssetMenu(fileName = "Recipe", menuName = "ScriptableObjects/Recipe")]
public class Recipe : ScriptableObject{
    public Ingredient first;
    public Ingredient second;
    public Sprite icon;
    public string recipeName;


    public Recipe Create(Ingredient first, Ingredient second) {
        if (this.first != first && this.second != second) return null;
        
        return CreateInstance<Recipe>();
    }
}