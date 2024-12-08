using UI;
using UnityEngine;
using UnityEngine.Serialization;

public class KitchenPopup : UiPopup{
    [FormerlySerializedAs("kitchenController")] [SerializeField] private KitchenManager kitchenManager;
    
    public override void Open() {
        gameObject.SetActive(true);
    }

    public override void Close() {
        gameObject.SetActive(false);
    }
}