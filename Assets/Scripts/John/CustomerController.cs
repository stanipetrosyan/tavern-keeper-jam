using System;
using ScriptableObjects;
using UnityEngine;
using UnityEngine.UI;

namespace John {
    public class CustomerController : MonoBehaviour {
        public float moveSpeed = 5f;
        private Transform _target;
        private Recipe _recipe;
        [SerializeField] private Image recipeTexture;
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

        public void SetRecipe(Recipe recipe) {
            this._recipe = recipe;
            recipeTexture.sprite = recipe.icon;
        }
    }
}
