using System.Collections;
using TMPro;
using UnityEngine;

public class PeopleMovement : MonoBehaviour
{
    // Assign these points in the Unity Inspector by dragging GameObjects into the fields
    public GameObject pointA;
    public GameObject pointB;
    public Sprite boomSprite;
    public Sprite grave;

    public TextMeshProUGUI points;
    public float speed = 2.0f;
    public bool canMove;
    public bool canKill;
    private Vector3 targetPosition;

    void Start()
    {
        canMove = true;
        canKill = true;
        // moving towards point A
        targetPosition = pointA.transform.position;        
        GameObject[] pointsCounters = GameObject.FindGameObjectsWithTag("Points");
        points = pointsCounters[0].GetComponent<TextMeshProUGUI>();
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
        if (other.CompareTag("Player") && canKill == true)
        {
            canMove = false;
            canKill = false;

            Destroy(other.gameObject);
            
            int oldPoints = int.Parse(points.text);

            if (isPatron())
            {
                oldPoints -= 25;

                if (oldPoints < 0)
                {
                    // lose
                }

                points.SetText(oldPoints.ToString());
            } else
            {
                oldPoints += 5;
                points.SetText(oldPoints.ToString());
            }

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

    bool isPatron()
    {
        if (this.gameObject.tag == "Patron")
        {
            return true;
        } else
        {
            return false;
        }
    }
}