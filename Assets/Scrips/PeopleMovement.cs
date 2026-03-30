using System.Collections;
using UnityEngine;

public class PeopleMovement : MonoBehaviour
{
    // Assign these points in the Unity Inspector by dragging GameObjects into the fields
    public GameObject pointA;
    public GameObject pointB;
    public Sprite boomSprite;
    public Sprite grave;
    public float speed = 2.0f;
    public bool canMove;
    private Vector3 targetPosition;

    void Start()
    {
        canMove = true;
        // moving towards point A
        targetPosition = pointA.transform.position;        
    }

    void Update()
    {
        movePatron();
    }

    void movePatron()
    {
        if (canMove)
        {
        // Move the object towards the current target position
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);            
        }

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

    private void OnTriggerEnter2D(Collider2D other) // For 3D
    {
        // Check the tag of the other collider that entered the trigger zone
        if (other.CompareTag("Player"))
        {
            canMove = false;

            Destroy(other.gameObject);

            this.gameObject.GetComponent<SpriteRenderer>().sprite = boomSprite;

            StartCoroutine(fadeAwayAndDie());
        }
    }

    IEnumerator fadeAwayAndDie()
    {
         // Wait for 3 seconds of game time
        yield return new WaitForSeconds(2f);

        this.gameObject.GetComponent<SpriteRenderer>().sprite = grave;

        yield return new WaitForSeconds(2f);

        Destroy(this.gameObject);
    }
}