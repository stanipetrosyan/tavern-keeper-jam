using System.Collections.Generic;
using Cards;
using Manager;
using ScriptableObjects;
using UnityEngine;

namespace UI{
    public class KitchenPopup : UiPopup{
        private Ingredient[] _ingredients;
        [SerializeField] GameObject inventoryCardPrefab;
        [SerializeField] GameObject inventory;
        private GameObject _ingredientCard;
        private List<GameObject> _objects;
        
        public override void Open() {
            gameObject.SetActive(true);
        }

        public override void Close() {
            gameObject.SetActive(false);
        }
        
        private void OnEnable() {
            _objects = new List<GameObject>();
            GenerateInventory();
        }

        private void OnDisable() {
            foreach (var item in _objects) {
                Destroy(item);
            }
            
            _objects.Clear();
        }

        
        private void GenerateInventory() {
            _ingredients = Managers.Inventory.GetIngredients();
            float x = -200;
            float y = -200;

            foreach (var item in _ingredients) {
                _ingredientCard = Instantiate(inventoryCardPrefab);
                
                _objects.Add(_ingredientCard.gameObject);
                
                _ingredientCard.GetComponent<InventoryCard>().SetIngredient(item);


                _ingredientCard.transform.SetParent(inventory.transform, false);
                _ingredientCard.transform.localScale = new Vector3(1, 1, 1);
                _ingredientCard.transform.localPosition = new Vector3(x, y, 0);

                
                x += 200;
            }
        }
        public void AddRecipeToInventory() {
            Managers.Inventory.AddRecipe(Managers.Kitchen.ActualRecipe());
        }
    }
}