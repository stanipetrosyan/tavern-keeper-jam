using System;
using System.Linq;
using Port;
using ScriptableObjects;
using UnityEngine;

namespace Manager{
    public class ShopManager : MonoBehaviour, IGameManager {
        [SerializeField] private Ingredient[] ingredients;
        [SerializeField] private Recipe[] recipes;
        public ManagerStatus Status { get; set; }

        public void Startup() {
            Status = ManagerStatus.Started;
        }

        public Ingredient[] GetSellableIngredients() {
            int tavernLevel = Managers.Tavern.GetTavernLevel();
            Array.Sort(ingredients, Comparison);
            return ingredients.Where(i => i.level <= tavernLevel).ToArray();
            
        }

        private int Comparison(Ingredient x, Ingredient y) {
            return x.level.CompareTo(y.level);
        }

        public Recipe[] GetSellableRecipes() {
            int tavernLevel = Managers.Tavern.GetTavernLevel();
            return recipes.Where(i => i.level <= tavernLevel).ToArray();
        }

        public bool BuyCard(Ingredient card) {
            if (!Managers.Tavern.RemoveMoney(card.cost)) return false;
            
            Managers.Inventory.AddIngredient(card);
            return true;
        }
    }
}