using System.Collections.Generic;
using Cards;
using Manager;
using ScriptableObjects;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace UI{
    public class TavernStatsPopup : UiPopup {
        
        private Recipe[] _recipes;
        private Ingredient[] _ingredients;
        [SerializeField] GameObject recipeCardPrefab;
        [SerializeField] GameObject inventoryCardPrefab;
        [SerializeField] GameObject recipesInventory;
        [SerializeField] GameObject ingredientsInventory;
        private List<GameObject> _objects;
        [SerializeField] private TMP_Text coins;
        [SerializeField] private TMP_Text level;
        
        public override void Open() {
            gameObject.SetActive(true);
        }

        public override void Close() {
            gameObject.SetActive(false);
        }
        
        private void OnEnable() {
            _objects = new List<GameObject>();
            coins.text = Managers.Tavern.GetMoney().ToString();
            level.text = Managers.Tavern.GetTavernLevel().ToString();
            
            
            GenerateRecipesInventory();
            GenerateIngredientsInventory();
        }

        private void OnDisable() {
            foreach (var item in _objects) {
                Destroy(item);
            }
            
            _objects.Clear();
        }

        
        private void GenerateRecipesInventory() {
            _recipes = Managers.Inventory.GetRecipes();
            float x = -450;

            foreach (var item in _recipes) {
                GameObject recipeCard = Instantiate(recipeCardPrefab);
                _objects.Add(recipeCard.gameObject);
                recipeCard.GetComponent<RecipeCard>().SetRecipe(item);
                SetObjectToParent(recipeCard, recipesInventory.transform, new Vector3(x, 0, 0), new Vector3(1, 1, 1));
                x += 200;
            }
        }
        
        private void GenerateIngredientsInventory() {
            _ingredients = Managers.Inventory.GetIngredients();
            float x = -450;

            foreach (var item in _ingredients) {
                GameObject ingredientCard = Instantiate(inventoryCardPrefab);
                _objects.Add(ingredientCard.gameObject);
                ingredientCard.GetComponent<InventoryCard>().SetIngredient(item);
                SetObjectToParent(ingredientCard, ingredientsInventory.transform, new Vector3(x, 0, 0), new Vector3(1, 1, 1));
                x += 200;
            }
        }

        private void SetObjectToParent(GameObject ingredientCard, Transform parent, Vector3 position, Vector3 scale) {
            ingredientCard.transform.SetParent(parent, false);
            ingredientCard.transform.localScale = scale;
            ingredientCard.transform.localPosition = position;
        }
    }
}
