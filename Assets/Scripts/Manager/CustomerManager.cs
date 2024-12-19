using System;
using System.Collections;
using John;
using Port;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Manager{
    public class CustomerManager: MonoBehaviour, IGameManager{

        [SerializeField] private GameObject customerPrefab;
        [SerializeField] private Transform joinPoint;
        [SerializeField] private Transform targetPoint;
        [SerializeField] private GameObject parent;
        
        public ManagerStatus Status { get; set; }

        private void Start() {
            StartCoroutine(SpawnCustomer());
        }

        private IEnumerator SpawnCustomer() {
            while (true) {
                var recipes = Managers.Shop.GetSellableRecipes();
                yield return new WaitForSeconds(10f);

                GameObject customer = Instantiate(customerPrefab, joinPoint);
                customer.transform.SetParent(parent.transform);
                customer.GetComponent<CustomerController>().SetTarget(targetPoint);      
                customer.GetComponent<CustomerController>().SetRecipe(recipes[Random.Range(0, recipes.Length)]);      
            }
                 
        }

        public void Startup() {
            Status = ManagerStatus.Started;
        }
    }
}