using UnityEngine;
using UnityEngine.UI;

public class InventoryCard : MonoBehaviour{
    
    [SerializeField] private Image image;

    public void SetSprite(Sprite sprite) {
        image.sprite = sprite;
    }
    
    
    void Update() {
        Collider2D targetObject = Physics2D.OverlapBox(transform.position, new Vector2(0, 0), 0f, LayerMask.GetMask("Placeholder"));

        if (targetObject) {
            Debug.Log(targetObject.name);
            transform.position = targetObject.transform.position;
        }
    }
}