using UnityEngine;

public class PeopleMovement : MonoBehaviour
{
    // Assign these points in the Unity Inspector by dragging GameObjects into the fields
    public GameObject pointA;
    public GameObject pointB;
    public float speed = 2.0f;

    private Vector3 targetPosition;

    void Start()
    {
        // moving towards point A
        targetPosition = pointA.transform.position;
    }

    void Update()
    {
        // Move the object towards the current target position
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        // Check if the object has reached the target position
        if (transform.position == targetPosition)
        {
            if (targetPosition == pointA.transform.position) {
                targetPosition = pointB.transform.position;
            } else if (targetPosition == pointB.transform.position) {
                Destroy(this.gameObject);
            }
        }
    }
}