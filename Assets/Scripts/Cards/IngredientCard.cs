using System;
using Manager;
using ScriptableObjects;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Cards{
    public class IngredientCard : MonoBehaviour{
        [SerializeField] private Image image;
        [SerializeField] private TMP_Text costText;
        [SerializeField] private Button buyButton;

        private Ingredient _ingredient;

        public void SetIngredient(Ingredient ingredient) {
            _ingredient = ingredient;
            SetSprite(ingredient.image);
            SetCost(ingredient.cost.ToString());
        }

        private void SetSprite(Sprite sprite) {
            image.sprite = sprite;
        }

        private void SetCost(string cost) {
            costText.text = cost;
        }

        private void Start() {
            buyButton.onClick.AddListener(() => { Managers.Shop.BuyCard(_ingredient); });
        }
    }
}