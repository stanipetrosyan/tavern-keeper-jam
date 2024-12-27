using System.Collections.Generic;
using System.Linq;
using Cards;
using Manager;
using ScriptableObjects;
using UnityEngine;

namespace UI{
    public class ShopMenuPopup : UiPopup {
        [SerializeField] private GameObject ingredientCardPrefab;
        private readonly List<GameObject> _objects = new();
        
        
        public override void Open() {
            gameObject.SetActive(true);
        }

        public override void Close() {
            gameObject.SetActive(false);
        }
        
        public void OnEnable() {
            GenerateIngredientsShop();
        }

        public void OnDisable() {
            CleanInventory();
        }
        
        private void CleanInventory() {
            foreach (var item in _objects) {
                Destroy(item);
            }

            _objects.Clear();
        }


        private void GenerateIngredientsShop() {
            float x = -650;
            float y = 0;
            
            var ingredients = Managers.Shop.GetSellableIngredients();
        
            foreach (var item in ingredients) {
                var ingredientCard = Instantiate(ingredientCardPrefab, transform, false);
                _objects.Add(ingredientCard.gameObject);
                
                ingredientCard.GetComponent<IngredientCard>().SetIngredient(item);
                ingredientCard.transform.localScale = new Vector3(1, 1, 1);
                ingredientCard.transform.localPosition = new Vector3(x, y, 0);
            
                x += 200;
            }
        }

       
    }
}
