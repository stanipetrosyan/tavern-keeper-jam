using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Cards{
    public class IngredientCard: MonoBehaviour{
    
        [SerializeField] private Image image;
        [SerializeField] private TMP_Text costText;
        [SerializeField] private Button buyButton;

        public void SetSprite(Sprite sprite) {
            image.sprite = sprite;
        }
    
        public void SetCost(String cost) {
            costText.text = cost;
        }
    
        private void Start() {
            buyButton.onClick.AddListener(() => {
                Debug.Log("Buy");
            });
        }
    }
}