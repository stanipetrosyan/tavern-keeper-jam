using UnityEngine;

public class KitchenPopup : UiPopup{
    [SerializeField] private KitchenController kitchenController;
    
    public override void Open() {
        gameObject.SetActive(true);
    }

    public override void Close() {
        gameObject.SetActive(false);
    }
}