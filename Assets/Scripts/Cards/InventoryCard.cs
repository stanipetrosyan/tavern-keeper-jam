using ScriptableObjects;
using UnityEngine;
using UnityEngine.UI;

namespace Cards{
    public class InventoryCard : MonoBehaviour{
    
        [SerializeField] private Image image;
        private Ingredient _ingredient;

        public void SetIngredient(Ingredient ingredient) {
            _ingredient = ingredient;
            image.sprite = ingredient.image;
        }
    
    
        void Update() {
            Collider2D targetObject = Physics2D.OverlapBox(transform.position, new Vector2(0, 0), 0f, LayerMask.GetMask("Placeholder"));

            if (targetObject) {
                EmptyCard card = targetObject.GetComponent<EmptyCard>();
                if (card && card.IsEmpty()) {
                    transform.position = targetObject.transform.position;
                    card.SetIngredient(_ingredient);
                    Destroy(gameObject);
                }
                
            }
        }
    }
}