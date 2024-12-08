using UnityEngine;
using UnityEngine.UI;

public class EmptyCard : MonoBehaviour{
    public Ingredient _ingredient {get; private set;}
    [SerializeField] private Image image;

    public void SetIngredient(Ingredient ingredient) {
        _ingredient = ingredient;
        image.sprite = ingredient.image;
    }
    
}