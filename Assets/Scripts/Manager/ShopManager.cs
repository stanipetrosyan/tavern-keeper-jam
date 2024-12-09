using Port;
using ScriptableObjects;
using UnityEngine;

namespace Manager{
    public class ShopManager : MonoBehaviour, IGameManager{
        public ManagerStatus Status { get; set; }

        public void Startup() {
            Status = ManagerStatus.Started;
        }

        public bool BuyCard(Ingredient card) {
            if (!Managers.Tavern.RemoveMoney(card.cost)) return false;
            
            Managers.Inventory.AddIngredient(card);
            return true;
        }
    }
}