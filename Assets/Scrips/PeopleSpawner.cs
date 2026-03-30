using UnityEngine;
using System.Collections;

public class PeopleSpawner : MonoBehaviour

{
public GameObject Patron;
public GameObject NonPatron;
private GameObject Person;
private float nextActionTime;
private float minDelay = 2f;
private float maxDelay = 4f;

    void Update()
    {
        GameObject[] nonPatrons = GameObject.FindGameObjectsWithTag("NonPatron");
        int nonPatronsCount = nonPatrons.Length;

        GameObject[] Patrons = GameObject.FindGameObjectsWithTag("Patron");
        int PatronsCount = Patrons.Length;

        int totalPeopleCount = nonPatronsCount + PatronsCount; 

        int randomInt = Random.Range(0, 10);

        if ( randomInt <7) {
            Person = NonPatron;
        } else {
            Person = Patron;
        }

        if (totalPeopleCount <15) {
        if (Time.time >= nextActionTime)
        {
            Instantiate(Person, transform.position, transform.rotation);
            SetNextActionTime();
        }
       }
    }

    void Start()
    {
        SetNextActionTime();
    } 

      private void SetNextActionTime()
    {
        float randomDelay = Random.Range(minDelay, maxDelay);
        nextActionTime = Time.time + randomDelay;
    }
}

