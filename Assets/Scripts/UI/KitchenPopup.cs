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
        private readonly List<GameObject> _objects = new();
        
        public override void Open() {
            gameObject.SetActive(true);
        }

        public override void Close() {
            gameObject.SetActive(false);
        }
        
        private void OnEnable() {
            GenerateInventory();
        }

        private void OnDisable() {
            CleanInventory();
        }

        private void CleanInventory() {
            foreach (var item in _objects) {
                Destroy(item);
            }

            _objects.Clear();
        }


        private void GenerateInventory() {
            _ingredients = Managers.Inventory.GetIngredients();
            float x = 30;

            foreach (var item in _ingredients) {
                var ingredientCard = Instantiate(inventoryCardPrefab, inventory.transform, false);
                _objects.Add(ingredientCard.gameObject);
                
                ingredientCard.GetComponent<InventoryCard>().SetIngredient(item);
                ingredientCard.transform.localScale = new Vector3(1, 1, 1);
                ingredientCard.transform.localPosition = new Vector3(x, 0, 0);
                
                x += 150;
            }
        }

       
        public void Generate() {
            Managers.Kitchen.AddRecipeToInventory();
        }

        public void RevertInventory() {
            CleanInventory();
            GenerateInventory();
            Clean();
        }

        private void Clean() {
            Managers.Kitchen.Clean();
        }
    }
}