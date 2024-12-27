using System;
using Manager;
using ScriptableObjects;
using UnityEngine;
using UnityEngine.UI;

namespace John {
    public class CustomerController : MonoBehaviour {
        public float moveSpeed = 5f;
        private Transform _target;
        private Transform _exit;
        private Recipe _recipe;
        private bool served = false;
        [SerializeField] private SpriteRenderer recipeTexture;
        [SerializeField] private GameObject order;


        private void Start() {
            order.SetActive(false);
        }

        void Update() {
            if (_target  && !served) {
                transform.position = Vector3.MoveTowards(transform.position, _target.position, moveSpeed * Time.deltaTime);
            }

            if (transform.position == _target.position && !served) {
                order.SetActive(true);
            }

            if (served) {
                transform.position = Vector3.MoveTowards(transform.position, _exit.position, moveSpeed * Time.deltaTime);
            }

            if (transform.position == _exit.position) {
                Destroy(this.gameObject);
            }

        }

        public void SetExit(Transform target) {
            this._exit = target;
        }
        
        public void SetTarget(Transform target) {
            this._target = target;
        }

        public void SetRecipe(Recipe recipe) {
            this._recipe = recipe;
            recipeTexture.sprite = recipe.icon;
        }

        public Recipe GetOrder() {
            return _recipe;
        }

        public bool Interact(Recipe recipe) {
            if (recipe == _recipe) {
                served = true;
                order.SetActive(false);
                Managers.Tavern.FreeChair(_target);
                return true;
            }
            else {
                return false;
            }
        }
    }
}
