using John;
using Manager;
using UI;
using UnityEngine;

namespace Jack{
    public class PlayerController : MonoBehaviour {

        [SerializeField] private float moveSpeed = 5f;
        [SerializeField] private Transform movePoint;
        [SerializeField] private LayerMask furnitureLayer;
        [SerializeField] private LayerMask interactLayer;
        [SerializeField] private LayerMask cookLayer;
        [SerializeField] private LayerMask beerLayer;
        [SerializeField] private KitchenPopup kitchenPopup;
        [SerializeField] private KitchenPopup beerPopup;
        [SerializeField] private float radius; 
        
        private Vector2 facingDirection;

    
        void Start() {
            movePoint.parent = null;
        }

        void Stop() {
            moveSpeed = 0f;
        }

        void Move() {
            moveSpeed = 5f;
        }

        void Update() {

            transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);

            if (!(Vector3.Distance(transform.position, movePoint.position) < 0.5f)) return;
            
            if (Mathf.Approximately(Mathf.Abs(Input.GetAxisRaw("Horizontal")), 1f)) {
                facingDirection = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
                Debug.Log($"Facing direction is now ${facingDirection}");
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), radius, furnitureLayer)) {
                    movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
                }
            }

            if (Mathf.Approximately(Mathf.Abs(Input.GetAxisRaw("Vertical")), 1f)) {
                facingDirection = new Vector2(0f, Input.GetAxisRaw("Vertical"));
                Debug.Log($"Facing direction is now ${facingDirection}");
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f), radius, furnitureLayer)) {
                    movePoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
                }
            }

            var hitCustomer = Physics2D.CircleCast(movePoint.position, 0.5f, facingDirection, 0.5f, interactLayer);
            if (hitCustomer.collider != null) {
                if (Input.GetKeyDown(KeyCode.E)) {
                    var customer = hitCustomer.collider.gameObject.GetComponent<CustomerController>();
                    var order = customer.GetOrder();
                    var recipe = Managers.Inventory.GetRecipe(order.name);
                    if (customer.Interact(recipe)) {
                        Managers.Tavern.AddMoney(recipe.cost);
                        Managers.Inventory.RemoveRecipe(recipe);
                    }
                }
            }
            var hitCook = Physics2D.CircleCast(movePoint.position, 0.5f, facingDirection, 0.5f, cookLayer);
            if (hitCook.collider != null) {
                if (Input.GetKeyDown(KeyCode.E)) {
                    Debug.Log("Open Cooker");
                    kitchenPopup.Open();
                }
            }
            var hitBeer = Physics2D.CircleCast(movePoint.position, 0.5f, facingDirection, 0.5f, beerLayer);
            if (hitBeer.collider != null) {
                if (Input.GetKeyDown(KeyCode.E)) { 
                    Debug.Log("Open Beerer"); 
                    beerPopup.Open();
                }
            }
        }
    }
}
