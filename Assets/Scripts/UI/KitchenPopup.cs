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
                _ingredientCard = Instantiate(inventoryCardPrefab, inventory.transform, false);
                
                _objects.Add(_ingredientCard.gameObject);
                
                _ingredientCard.GetComponent<InventoryCard>().SetIngredient(item);


                _ingredientCard.transform.localScale = new Vector3(1, 1, 1);
                _ingredientCard.transform.localPosition = new Vector3(x, 0, 0);

                
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