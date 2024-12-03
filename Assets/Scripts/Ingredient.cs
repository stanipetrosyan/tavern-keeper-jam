using UnityEngine;

[CreateAssetMenu(fileName = "Ingredient", menuName = "ScriptableObjects/Ingredient")]
public class Ingredient: ScriptableObject {
    public string ingredientName;
    public int cost;
    public Sprite image;
}