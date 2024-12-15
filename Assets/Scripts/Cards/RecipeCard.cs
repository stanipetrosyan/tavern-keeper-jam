using ScriptableObjects;
using UnityEngine;
using UnityEngine.UI;

namespace Cards{
    public class RecipeCard: MonoBehaviour {
        public Recipe recipe {get; private set;}
        [SerializeField] private Image image;

        public void SetRecipe(Recipe recipe) {
            this.recipe = recipe;
            image.sprite = recipe.icon;
        }

        public void Clean() {
            recipe = null;
            image.sprite = null;
        }

    }
}