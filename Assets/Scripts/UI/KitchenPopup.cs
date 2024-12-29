using System;
using System.Collections;
using System.Collections.Generic;
using Cards;
using Manager;
using ScriptableObjects;
using UnityEngine;
using UnityEngine.Serialization;

namespace UI{
    public class KitchenPopup : UiPopup{
        private Ingredient[] _ingredients;
        [SerializeField] GameObject inventoryCardPrefab;
        [SerializeField] GameObject inventory;
        private readonly List<GameObject> _objects = new();
        [SerializeField] private ProgressBarUI progressBar;
        [SerializeField] private GameObject generateButton;
        [SerializeField] private GameObject exitButton;
        
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
            float x = -220;
            float y = 70;

            foreach (var item in _ingredients) {
                var ingredientCard = Instantiate(inventoryCardPrefab, inventory.transform, false);
                _objects.Add(ingredientCard.gameObject);
                
                ingredientCard.GetComponent<InventoryCard>().SetIngredient(item);
                ingredientCard.transform.localScale = new Vector3(1, 1, 1);
                ingredientCard.transform.localPosition = new Vector3(x, y, 0);
                
                x += 200;
            }
        }

       
        public void Generate() {
            generateButton.SetActive(false);
            var recipeTime = Managers.Kitchen.ActualRecipe().timeToCook;
            StartCoroutine(Delay(recipeTime, () => {
                Managers.Kitchen.AddRecipeToInventory();
                generateButton.SetActive(true);
                exitButton.SetActive(true);
                progressBar.Hide();
            }));
            
        }

        private IEnumerator Delay(int time, Action task) {
            exitButton.SetActive(false);
            progressBar.StartProgression(time);
            yield return new WaitForSeconds(time);
            task();
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