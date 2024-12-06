using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour {
    
    [SerializeField] ShopMenuPopup shopMenuPopup;
    [SerializeField] TavernStatsPopup tavernStatsPopup;
    [SerializeField] KitchenPopup kitchenPopup;

    void Start() {
        shopMenuPopup.Close();
        tavernStatsPopup.Close();
    }

    public void OnOpenShopMenu() {
        shopMenuPopup.Open();
        tavernStatsPopup.Close();
    }

    public void OnOpenTavernStats() {
        shopMenuPopup.Close();
        tavernStatsPopup.Open();
    }

    public void OnOpenKitchenPopup() {
        shopMenuPopup.Open();
    }
}
