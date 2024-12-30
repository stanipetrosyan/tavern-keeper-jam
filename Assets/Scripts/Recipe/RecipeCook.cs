using System.Collections;
using System.Collections.Generic;
using Cards;
using Manager;
using ScriptableObjects;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RecipeCook : MonoBehaviour
{
    [SerializeField] private EmptyCard firstIngredientCard;
    [SerializeField] private EmptyCard secondIngredientCard;
    [SerializeField] private RecipeCard resultCard;


    public void SetRecipe(Ingredient firstIngredient, Ingredient secondIngredient, Recipe result) {
        firstIngredientCard.SetIngredient(firstIngredient);
        secondIngredientCard.SetIngredient(secondIngredient);
        resultCard.SetRecipe(result);
    }

    
}
