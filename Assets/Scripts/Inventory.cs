using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : ScriptableObject
{
    private List<Card> cards;

    Card GetCard(string name) {
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
}
