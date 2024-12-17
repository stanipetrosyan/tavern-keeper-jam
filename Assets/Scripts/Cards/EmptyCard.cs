using ScriptableObjects;
using UnityEngine;
using UnityEngine.UI;

namespace Cards{
    public class EmptyCard : MonoBehaviour{
        public Ingredient _ingredient {get; private set;}
        [SerializeField] private Image image;

        public void SetIngredient(Ingredient ingredient) {
            _ingredient = ingredient;
            image.sprite = ingredient.image;
        }

        public bool IsEmpty() {
            return _ingredient == null;
        }

        public void Clean() {
            _ingredient = null;
            image.sprite = null;
        }
    
    }
}