using TMPro;
using UnityEngine;
using Image = UnityEngine.UI.Image;

public class ShopMenuPopup : MonoBehaviour {
    [SerializeField] private Ingredient[] ingredients;
    [SerializeField] GameObject ingredientCardPrefab;
    private GameObject ingredientCard;

    public void Start() {
        float x = 100;
        float y = 100;
        
        foreach (var item in ingredients) {
            ingredientCard = Instantiate(ingredientCardPrefab, transform, true);
            ingredientCard.GetComponent<IngredientCard>().SetSprite(item.image);
            ingredientCard.GetComponent<IngredientCard>().SetCost(item.cost.ToString());
            ingredientCard.transform.position = new Vector3(x, y, 0);
            ingredientCard.transform.localPosition = new Vector3(0, 0, 0);
            ingredientCard.transform.localScale = new Vector3(1, 1, 0);
            
            x += 200;
        }
    }

    public void Open() {
        gameObject.SetActive(true);
    }

    public void Close() {
        gameObject.SetActive(false);
    }
}
