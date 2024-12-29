using UnityEngine;

namespace ScriptableObjects{
    [CreateAssetMenu(fileName = "Ingredient", menuName = "ScriptableObjects/Ingredient")]
    public class Ingredient: ScriptableObject {
        private string cardName;
        public int cost;
        public Sprite image;
        public int level;
        public IngredientType type;
    }
    
    public enum IngredientType{
        Food, Drink
    }
}