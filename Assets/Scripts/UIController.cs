using UI;
using UnityEngine;

public class UIController : MonoBehaviour {
    
    [SerializeField] ShopMenuPopup shopMenuPopup;
    [SerializeField] TavernStatsPopup tavernStatsPopup;
    [SerializeField] KitchenPopup kitchenPopup;
    [SerializeField] StaplerPopup staplerPopup;

    void Start() {
        shopMenuPopup.Close();
        tavernStatsPopup.Close();
        kitchenPopup.Close();
        staplerPopup.Close();
    }

    public void OnOpenShopMenu() {
        shopMenuPopup.Open();
        kitchenPopup.Close();
        tavernStatsPopup.Close();
    }

    public void OnOpenTavernStats() {
        shopMenuPopup.Close();
        kitchenPopup.Close();
        tavernStatsPopup.Open();
    }

    public void OnOpenKitchenPopup() {
        kitchenPopup.Open();
        tavernStatsPopup.Close();
        shopMenuPopup.Close();
    }
}
