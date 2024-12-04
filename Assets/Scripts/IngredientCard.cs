using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class IngredientCard: MonoBehaviour{
    
    [SerializeField] private Image image;
    [SerializeField] private TMP_Text costText;

    public void SetSprite(Sprite sprite) {
        image.sprite = sprite;
    }
    
    public void SetCost(String cost) {
        costText.text = cost;
    }

}