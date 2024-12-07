using System.Collections.Generic;
using UnityEngine;

public class InventoryManager: MonoBehaviour, IGameManager {
    private List<Card> cards;
    
    public Card GetCard(string name) {
        foreach (var card in cards) {
            if (card.name == name) {
                return card;
            }
        }

        return null;
    }

    void AddCard(Card card) {
        cards.Add(card);
    }

    public ManagerStatus Status { get; set; }

    public void Startup() {
        cards = new List<Card>();
        
        Status = ManagerStatus.Started;
    }
}
