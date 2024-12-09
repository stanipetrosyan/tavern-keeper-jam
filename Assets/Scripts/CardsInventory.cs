using Cards;
using ScriptableObjects;
using UnityEngine;

public class CardsInventory: MonoBehaviour{
    
    // Actually works like shop menu for testing purpose
    [SerializeField] private Ingredient[] ingredients;
    [SerializeField] GameObject ingredientCardPrefab;
    private GameObject ingredientCard;

    public void Start() {
        float x = -200;
        float y = -200;
        
        foreach (var item in ingredients) {
            
            ingredientCard = Instantiate(ingredientCardPrefab);
            
            ingredientCard.GetComponent<InventoryCard>().SetIngredient(item);
            
            
            ingredientCard.transform.SetParent(transform, false);
            ingredientCard.transform.localScale = new Vector3(1, 1, 1);
            ingredientCard.transform.localPosition = new Vector3(x, y, 0);
            
            
            x += 200;
        }
    }
}