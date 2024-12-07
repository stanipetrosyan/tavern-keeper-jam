using UnityEngine;

[CreateAssetMenu(fileName = "Ingredient", menuName = "ScriptableObjects/Ingredient")]
public class Ingredient: ScriptableObject {
    private string cardName;
    public int cost;
    public Sprite image;
}