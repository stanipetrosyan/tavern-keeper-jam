using System.ComponentModel;
using UnityEngine;

namespace Jack{
    public class PlayerController : MonoBehaviour {

        [SerializeField] private float moveSpeed = 3f;
        [SerializeField] private Transform movePoint;
        [SerializeField] private LayerMask decorationLayer;
        [SerializeField] private LayerMask countersLayer;
        [SerializeField] private float radius; 

    
        void Start() {
            movePoint.parent = null;
        }

        void Update() {

            transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);

            if (!(Vector3.Distance(transform.position, movePoint.position) < 0.5f)) return;
            
            if (Mathf.Approximately(Mathf.Abs(Input.GetAxisRaw("Horizontal")), 1f)) {
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), radius, decorationLayer)) {
                    movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
                }
            }

            if (Mathf.Approximately(Mathf.Abs(Input.GetAxisRaw("Vertical")), 1f)) {
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f), radius, decorationLayer)) {
                    movePoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
                }
            }

            var hit = Physics2D.CircleCast(movePoint.position, 0.3f, Vector2.up, 0.3f, countersLayer);
            if (hit.collider != null) {
                Debug.Log(hit.collider.gameObject.name);
            }
        }
    }
}
