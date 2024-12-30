using System.Collections;
using System.Collections.Generic;
using Cards;
using Manager;
using ScriptableObjects;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class RecipeStapler : MonoBehaviour
{
    [SerializeField] private EmptyCard ingredientCard;
    [SerializeField] private RecipeCard resultCard;


    public void SetRecipe(Ingredient firstIngredient, Recipe result) {
        ingredientCard.SetIngredient(firstIngredient);
        resultCard.SetRecipe(result);
    }

    
}
