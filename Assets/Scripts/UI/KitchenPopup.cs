using System;
using Cards;
using Manager;
using ScriptableObjects;
using UnityEngine;
using UnityEngine.Serialization;

namespace UI{
    public class KitchenPopup : UiPopup{
        public override void Open() {
            gameObject.SetActive(true);
        }

        public override void Close() {
            gameObject.SetActive(false);
        }

        private Ingredient[] ingredients;
        [SerializeField] GameObject inventoryCardPrefab;
        [SerializeField] GameObject inventory;
        private GameObject ingredientCard;
        
        private void GenerateInventory() {
            ingredients = Managers.Inventory.GetIngredients();
            float x = -200;
            float y = -200;

            foreach (var item in ingredients) {
                ingredientCard = Instantiate(inventoryCardPrefab);

                ingredientCard.GetComponent<InventoryCard>().SetIngredient(item);


                ingredientCard.transform.SetParent(inventory.transform, false);
                ingredientCard.transform.localScale = new Vector3(1, 1, 1);
                ingredientCard.transform.localPosition = new Vector3(x, y, 0);


                x += 200;
            }
        }

        private void OnEnable() {
            GenerateInventory();
        }

        private void OnDisable() {
            // Clean all objects created
            throw new NotImplementedException();
        }

        public void AddRecipeToInventory() {
            Managers.Inventory.AddRecipe(Managers.Kitchen.ActualRecipe());
        }
    }
}