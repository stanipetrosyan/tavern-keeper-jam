using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InventoryManager))]
public class Managers : MonoBehaviour{
    public static InventoryManager Inventory {get; set;}
    private List<IGameManager> startSequence;
    
    void Awake() {
        Inventory = GetComponent<InventoryManager>();

        startSequence = new List<IGameManager>
        {
            Inventory,
        };

        StartCoroutine(StartupManagers());
    }

    private IEnumerator StartupManagers() {
        foreach(IGameManager manager in startSequence) {
            manager.Startup();
        }   

        yield return null;

        int numModules = startSequence.Count;
        int numReady = 0;

        while(numReady < numModules) {
            int lastReady = numReady;
            numReady = 0;

            foreach(IGameManager manager in startSequence) {
                if (manager.Status == ManagerStatus.Started) {
                    numReady++;
                }
            }

            if (numReady > lastReady) {
                Debug.Log($"Progress: {numReady}/{numModules}");
            }

            yield return null;   
        }

        Debug.Log("All manager started up");
    }
}