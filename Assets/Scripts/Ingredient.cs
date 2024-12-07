using UnityEngine;

[CreateAssetMenu(fileName = "Ingredient", menuName = "ScriptableObjects/Ingredient")]
public class Ingredient: Card {
    public int cost;
    public Sprite image;
}