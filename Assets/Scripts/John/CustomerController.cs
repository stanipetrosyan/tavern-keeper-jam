using System;
using UnityEngine;

namespace John {
    public class CustomerController : MonoBehaviour {
        public float moveSpeed = 5f;
        private Transform _target;
        [SerializeField] private GameObject order;


        private void Start() {
            order.SetActive(false);
        }

        void Update() {
            if (_target) {
                transform.position = Vector3.MoveTowards(transform.position, _target.position, moveSpeed * Time.deltaTime);
            }

            if (transform.position == _target.position) {
                order.SetActive(true);
            }

        }
        
        public void SetTarget(Transform target) {
            this._target = target;
            
        }
    }
}
