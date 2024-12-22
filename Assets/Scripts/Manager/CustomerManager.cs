using System.Collections;
using John;
using Port;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Manager{
    public class CustomerManager: MonoBehaviour, IGameManager{

        [SerializeField] private GameObject customerPrefab;
        [SerializeField] private GameObject sheriffPrefab;
        [SerializeField] private Transform joinPoint;
        [SerializeField] private GameObject parent;
        
        public ManagerStatus Status { get; set; }

        private void Start() {
            StartCoroutine(SpawnCustomer());
        }

        private IEnumerator SpawnCustomer() {
            while (true) {
                var recipes = Managers.Shop.GetSellableRecipes();
                var chairs = Managers.Tavern.GetChairs();
                var chair = chairs[Random.Range(0, chairs.Length)];
                
                yield return new WaitForSeconds(10f);


                if (Managers.Tavern.ChairIsFree(chair)) {
                    GameObject customer = Instantiate(customerPrefab, joinPoint);
                    customer.transform.SetParent(parent.transform);
                
                    customer.GetComponent<CustomerController>().SetTarget(chair);      
                    customer.GetComponent<CustomerController>().SetRecipe(recipes[Random.Range(0, recipes.Length)]);
                    Managers.Tavern.OccupyChair(chair);
                }
            }
                 
        }

        public void Startup() {
            Status = ManagerStatus.Started;
        }
    }
}