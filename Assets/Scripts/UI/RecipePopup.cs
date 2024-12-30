using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Cards;
using Manager;
using ScriptableObjects;
using UnityEngine;
using UnityEngine.Serialization;

namespace UI{
    public class RecipePopup : UiPopup{

        [SerializeField] private GameObject cookRecipePrefab;
        [SerializeField] private GameObject staplerRecipePrefab;
        private Recipe[] recipes;
        private readonly List<GameObject> objects = new();
        public override void Open() {
            gameObject.SetActive(true);
        }

        public override void Close() {
            gameObject.SetActive(false);
        }

        public void OnEnable() {
            GenerateRecepiesShop();
        }

        public void OnDisable() {
            CleanRecipes();
        }
        
        private void GenerateRecepiesShop() {
            const float xFood = -400;
            const float xDrink = 400;
            float yFood = 360;
            float yDrink = 360;
            const float xScale = 100;
            const float yScale = 75;
            recipes = Managers.Shop.GetSellableRecipes();

            foreach (var foodRecipe in recipes.Where(recipe => recipe.recipeType == RecipeType.Food)) {
                var recipe = Instantiate(cookRecipePrefab, transform, false);
                recipe.GetComponent<RecipeCook>().SetRecipe(foodRecipe.first, foodRecipe.second, foodRecipe);
                recipe.transform.localScale = new Vector3(xScale, yScale, 1);
                recipe.transform.localPosition = new Vector3(xFood, yFood, 0);
                yFood -= 250;
                objects.Add(recipe.gameObject);
            }

            foreach (var drinkRecipe in recipes.Where(recipe => recipe.recipeType == RecipeType.Drink)) {
                var recipe = Instantiate(staplerRecipePrefab, transform, false);
                objects.Add(recipe.gameObject);
                recipe.GetComponent<RecipeStapler>().SetRecipe(drinkRecipe.first, drinkRecipe);
                recipe.transform.localScale = new Vector3(xScale, yScale, 1);
                recipe.transform.localPosition = new Vector3(xDrink, yDrink, 0);
                yDrink -= 250;
            }
        }

        private void CleanRecipes() {
            foreach (var item in objects) {
                Destroy(item);
            }
            objects.Clear();
        }
    }
}