using System.Collections;
using System.Collections.Generic;
using Port;
using UnityEngine;

namespace Manager{
    [RequireComponent(typeof(InventoryManager), typeof(KitchenManager), typeof(TavernManager))]
    public class Managers : MonoBehaviour{
        public static InventoryManager Inventory { get; set; }
        public static KitchenManager Kitchen { get; set; }
        public static TavernManager Tavern { get; set; }
        public static ShopManager Shop { get; set; }
        
        public static CustomerManager Customer { get; set; }
        private List<IGameManager> startSequence;

        void Awake() {
            Tavern = GetComponent<TavernManager>();
            Inventory = GetComponent<InventoryManager>();
            Kitchen = GetComponent<KitchenManager>();
            Shop = GetComponent<ShopManager>();
            Customer = GetComponent<CustomerManager>();

            startSequence = new List<IGameManager> {
                Tavern,
                Inventory,
                Kitchen,
                Shop,
                Customer
            };

            StartCoroutine(StartupManagers());
        }

        private IEnumerator StartupManagers() {
            foreach (IGameManager manager in startSequence) {
                manager.Startup();
            }

            yield return null;

            int numModules = startSequence.Count;
            int numReady = 0;

            while (numReady < numModules) {
                int lastReady = numReady;
                numReady = 0;

                foreach (IGameManager manager in startSequence) {
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
}