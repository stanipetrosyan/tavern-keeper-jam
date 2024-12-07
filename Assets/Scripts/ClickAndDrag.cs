using UnityEngine;

public class ClickAndDrag : MonoBehaviour{
    private Vector3 mousePosition;
    public GameObject targetObject;
    private Vector3 offset;


    private void Update() {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0)) {
            Collider2D target = Physics2D.OverlapPoint(mousePosition, LayerMask.GetMask("Draggable"));

            if (target) {
                targetObject = target.transform.gameObject;
                offset = targetObject.transform.position - mousePosition;
            }
        }

        if (targetObject) {
            targetObject.transform.position = mousePosition + offset;
        }

        if (Input.GetMouseButtonUp(0) && targetObject) {
            targetObject = null;
        }
    }
}