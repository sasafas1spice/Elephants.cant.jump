using UnityEngine;

public class MoveBetweenPoints : MonoBehaviour
{
    // Assign these points in the Unity Inspector by dragging GameObjects into the fields
    public Transform pointA;
    public Transform pointB;
    public float speed = 2.0f;

    private Vector3 targetPosition;

    void Start()
    {
        // Start by moving towards point B
        targetPosition = pointB.position;
    }

    void Update()
    {
        // Move the object towards the current target position
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        // Check if the object has reached the target position
        if (transform.position == targetPosition)
        {
            // Switch the target to the other point to move back and forth indefinitely
            if (targetPosition == pointB.position)
            {
                targetPosition = pointA.position;
            }
            else
            {
                targetPosition = pointB.position;
            }
        }
    }
}