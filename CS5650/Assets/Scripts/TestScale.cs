using UnityEngine;
using UnityEngine.EventSystems;

public class TestScale : MonoBehaviour {

    private Vector2 startPosition;
    private float scalingFactor = .01f;
    private bool isClick = false;
    Ray ray;

    void Update(){
        // Check for mpuse clicks
        if (Input.GetMouseButton(0)){ 
            RaycastHit mouseHit; 
            ray = Camera.main.ScreenPointToRay(Input.mousePosition); 
            if (Physics.Raycast(ray, out mouseHit, Mathf.Infinity)) {
                Interact(mouseHit);
            }
        }
        else {
            if (isClick == true){
                isClick = false;
            }
        }

        if (isClick){
            // https://gist.github.com/SimonDarksideJ/477f5674285b63cba8e752c43950ed7c
            Vector3 origin = transform.position; // Take current position of this draggable object as Plane's Origin
            Vector3 orthog = -Camera.main.transform.forward; // Take current negative camera's forward as Plane's Normal
            float t = Vector3.Dot(origin - ray.origin, orthog) / Vector3.Dot(ray.direction, orthog); // plane vs. line intersection in algebric form. It find t as distance from the camera of the new point in the ray's direction.
            Vector3 P = ray.origin + ray.direction * t; // Find the new point.
            transform.position = P;
        }
    }

    // Increment numClicks
    private void Interact(RaycastHit hit){
        if (hit.collider.name == this.name){
            isClick = true;
        }
    }
}