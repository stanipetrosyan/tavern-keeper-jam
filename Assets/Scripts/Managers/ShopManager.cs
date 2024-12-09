using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager: MonoBehaviour, IGameManager {
    private Dictionary<Ingredient, int> shopInventoryCards;
    private InventoryManager inventoryManager;
    private TavernManager tavernManager;
    
    public ManagerStatus Status { get; set; }
    
    public void Startup() {
        shopInventoryCards = new Dictionary<Ingredient, int>();
    }

    bool BuyCard(Ingredient card) {
        var cardCost = shopInventoryCards[card];
        if (cardCost == null) return false;
        if (!tavernManager.RemoveMoney(cardCost)) return false
        inventoryManager.AddIngredient(card);
        return true;
    }

}
