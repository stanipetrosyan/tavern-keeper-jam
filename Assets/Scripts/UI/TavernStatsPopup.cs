using System.Collections.Generic;
using Cards;
using Manager;
using ScriptableObjects;
using UnityEngine;
using UnityEngine.Serialization;

namespace UI{
    public class TavernStatsPopup : UiPopup {
        
        private Recipe[] _recipes;
        [SerializeField] GameObject recipeCardPrefab;
        [SerializeField] GameObject inventory;
        private GameObject _recipeCard;
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
            _recipes = Managers.Inventory.GetRecipes();
            float x = 30;

            foreach (var item in _recipes) {
                _recipeCard = Instantiate(recipeCardPrefab);
                
                _objects.Add(_recipeCard.gameObject);
                
                _recipeCard.GetComponent<RecipeCard>().SetRecipe(item);


                _recipeCard.transform.SetParent(inventory.transform, false);
                _recipeCard.transform.localScale = new Vector3(1, 1, 1);
                _recipeCard.transform.localPosition = new Vector3(x, 0, 0);

                
                x += 150;
            }
        }
    }
}
