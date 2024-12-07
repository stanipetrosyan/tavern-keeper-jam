using UnityEngine;

public class Tavern : MonoBehaviour {

    public Inventory inventory;

    void start() {
        inventory = new Inventory();
    }

}
