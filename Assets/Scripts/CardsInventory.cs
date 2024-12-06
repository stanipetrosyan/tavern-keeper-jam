using UnityEngine;

public class CardsInventory: MonoBehaviour{
    
    // Actually works like shop menu for testing purpose
    [SerializeField] private Ingredient[] ingredients;
    [SerializeField] GameObject ingredientCardPrefab;
    private GameObject ingredientCard;

    public void Start() {
        float x = 0;
        float y = 100;
        
        foreach (var item in ingredients) {
            
            ingredientCard = Instantiate(ingredientCardPrefab);
            
            ingredientCard.GetComponent<IngredientCard>().SetSprite(item.image);
            ingredientCard.GetComponent<IngredientCard>().SetCost(item.cost.ToString());
            
            
            ingredientCard.transform.SetParent(transform, false);
            ingredientCard.transform.localScale = new Vector3(1, 1, 1);
            ingredientCard.transform.localPosition = new Vector3(x, y, 0);
            
            
            x += 200;
        }
    }
    
}