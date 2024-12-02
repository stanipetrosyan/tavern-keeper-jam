using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour {
    
    [SerializeField] ShopMenuPopup shopMenuPopup;

    void Start() {
        shopMenuPopup.Close();
    }

    public void OnOpenShopMenu() {
        shopMenuPopup.Open();
    }
}
