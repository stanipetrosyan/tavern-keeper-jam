using System;
using System.Collections;
using John;
using Port;
using UnityEngine;

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
                yield return new WaitForSeconds(10f);

                GameObject customer = Instantiate(customerPrefab, joinPoint);
                customer.transform.SetParent(parent.transform);
                customer.GetComponent<CustomerController>().SetTarget(targetPoint);      
            }
                 
        }

        public void Startup() {
            Status = ManagerStatus.Started;
        }
    }
}