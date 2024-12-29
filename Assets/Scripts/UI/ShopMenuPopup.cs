using System;
using System.Collections.Generic;
using System.Linq;
using Cards;
using Manager;
using ScriptableObjects;
using UnityEngine;

namespace UI{
    public class ShopMenuPopup : UiPopup {
        [SerializeField] private GameObject ingredientCardPrefab;
        private readonly List<GameObject> objects = new();
        
        
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
            foreach (var item in objects) {
                Destroy(item);
            }

            objects.Clear();
        }


        private void GenerateIngredientsShop() {
            float xFood = -700;
            float xDrink = -700;
            const float yFood = 200;
            const float yDrink = -200;
            
            var ingredients = Managers.Shop.GetSellableIngredients();
        
            foreach (var item in ingredients) {
                var ingredientCard = Instantiate(ingredientCardPrefab, transform, false);
                objects.Add(ingredientCard.gameObject);
                
                ingredientCard.GetComponent<IngredientCard>().SetIngredient(item);
                ingredientCard.transform.localScale = new Vector3(1, 1, 1);
                switch (item.type) {
                    case IngredientType.Food:
                        ingredientCard.transform.localPosition = new Vector3(xFood, yFood, 0);
                        xFood += 200;
                        break;
                    case IngredientType.Drink:
                        ingredientCard.transform.localPosition = new Vector3(xDrink, yDrink, 0);
                        xDrink += 200;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

            }
        }

       
    }
}
