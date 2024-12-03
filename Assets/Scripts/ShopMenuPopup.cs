using UnityEngine;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class ShopMenuPopup : MonoBehaviour {
    [SerializeField] private Ingredient[] ingredients;
    

    public void Start() {
        float x = 1;
        float y = 2;
        
        foreach (var item in ingredients) {
            GameObject newObj = new GameObject(item.name);
            Image image = newObj.AddComponent<Image>();
            image.sprite = item.image;
            newObj.GetComponent<RectTransform>().SetParent(transform); //Assign the newly created Image GameObject as a Child of the Parent Panel.
            newObj.GetComponent<RectTransform>().sizeDelta = new Vector2(64, 64);
            newObj.GetComponent<RectTransform>().localScale = new Vector3(0.1f, 0.1f, 0.1f);
            newObj.GetComponent<RectTransform>().position = new Vector2(x, y);
            newObj.SetActive(true); //Activate the GameObject

            x += 2;
        }
    }

    public void Open() {
        gameObject.SetActive(true);
    }

    public void Close() {
        gameObject.SetActive(false);
    }
}
