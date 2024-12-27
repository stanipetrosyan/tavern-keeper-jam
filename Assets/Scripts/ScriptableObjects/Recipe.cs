using System;
using JetBrains.Annotations;
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
        public RecipeType recipeType;
        public bool Valid(Ingredient first, [CanBeNull] Ingredient second) {
            switch (this.recipeType) {
                case RecipeType.Food:
                    return (this.first == first && this.second == second) || (this.first == second && this.second == first);
                case RecipeType.Drink:
                    return (this.first == first);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }

    public enum RecipeType{
        Food, Drink
    }
}