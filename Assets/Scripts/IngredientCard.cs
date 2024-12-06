using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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

    public void SetEvent() {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void Start() {
        buyButton.onClick.AddListener(() => {
            Debug.Log("Buy");
        });
    }
}