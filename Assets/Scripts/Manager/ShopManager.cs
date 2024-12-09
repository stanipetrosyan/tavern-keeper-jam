using System.Collections.Generic;
using Port;
using ScriptableObjects;
using UnityEngine;

namespace Manager{
    public class ShopManager: MonoBehaviour, IGameManager {
        private Dictionary<Ingredient, int> shopInventoryCards;
        private InventoryManager inventoryManager;
        private TavernManager tavernManager;
    
        public ManagerStatus Status { get; set; }
    
        public void Startup() {
            shopInventoryCards = new Dictionary<Ingredient, int>();
        }

        bool BuyCard(Ingredient card) {
            var cardCost = shopInventoryCards[card]; //Da rivedere perchè forse non ritorna null
            if (cardCost == null) return false;
            if (!tavernManager.RemoveMoney(cardCost)) return false;
            inventoryManager.AddIngredient(card);
            return true;
        }

    }
}
