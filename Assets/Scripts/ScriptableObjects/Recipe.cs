using UnityEngine;

namespace ScriptableObjects{
    [CreateAssetMenu(fileName = "Recipe", menuName = "ScriptableObjects/Recipe")]
    public class Recipe : ScriptableObject{
        public Ingredient first;
        public Ingredient second;
        public Sprite icon;
        public string recipeName;
        public int level;
        public int cost;
        public int timeToCook;
        public bool Valid(Ingredient first, Ingredient second) {
            return (this.first == first && this.second == second) || (this.first == second && this.second == first);
        }
    }
}