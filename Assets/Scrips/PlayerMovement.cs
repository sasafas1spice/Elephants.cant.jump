using UnityEngine;
using UnityEngine.InputSystem;

public class MoveBetweenPoints : MonoBehaviour
{
    // Assign these points in the Unity Inspector by dragging GameObjects into the fields
    public GameObject pointA;
    public GameObject pointB;
    public float speed = 2.0f;

    private Vector3 targetPosition;

    void Start()
    {
    
        targetPosition = pointB.transform.position;
    }

    void Update()
    {
        // Move the object towards the current target position
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        // Check if the object has reached the target position
        if (transform.position == targetPosition)
        {
            // Switch the target to the other point to move back and forth indefinitely
            if (targetPosition == pointB.transform.position)
            {
                targetPosition = pointA.transform.position;
            }
            else
            {
                targetPosition = pointB.transform.position;
            }
        }

        if (Keyboard.current.aKey.isPressed) {
            targetPosition = pointA.transform.position;
             } 
            else if (Keyboard.current.dKey.isPressed) {
            targetPosition = pointB.transform.position;
             }
            else if (Keyboard.current.spaceKey.isPressed) {
            targetPosition = pointB.transform.position;
         }
    }
}
