using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tavern : MonoBehaviour {

    public Inventory inventory;

    void start() {
        inventory = ScriptableObject.CreateInstance<Inventory>();
    }

}
