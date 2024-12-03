using System.Collections.Generic;
using UnityEngine;

public class ShopMenuPopup : MonoBehaviour {
    [SerializeField] private Ingredient[] ingredients;
    

    public void Start() {
        
    }
    
    public void Open() {
        gameObject.SetActive(true);
    }

    public void Close() {
        gameObject.SetActive(false);
    }
}
