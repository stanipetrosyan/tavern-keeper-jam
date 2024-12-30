using UI;
using UnityEngine;

public class UIController : MonoBehaviour {
    
    [SerializeField] ShopMenuPopup shopMenuPopup;
    [SerializeField] TavernStatsPopup tavernStatsPopup;
    [SerializeField] KitchenPopup kitchenPopup;
    [SerializeField] StaplerPopup staplerPopup;
    [SerializeField] RecipePopup recipePopup;

    void Start() {
        shopMenuPopup.Close();
        tavernStatsPopup.Close();
        kitchenPopup.Close();
        staplerPopup.Close();
        recipePopup.Close();
    }

    public void OnOpenShopMenu() {
        shopMenuPopup.Open();
        kitchenPopup.Close();
        tavernStatsPopup.Close();
        recipePopup.Close();
        staplerPopup.Close();
    }

    public void OnOpenTavernStats() {
        shopMenuPopup.Close();
        kitchenPopup.Close();
        tavernStatsPopup.Open();
        recipePopup.Close();
        staplerPopup.Close();
    }

    public void OnOpenRecipePopup() {
        recipePopup.Open();
        kitchenPopup.Close();
        tavernStatsPopup.Close();
        shopMenuPopup.Close();
        staplerPopup.Close();
    }
}
