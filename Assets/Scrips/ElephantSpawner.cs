using UnityEngine;

public class ElephantSpawner : MonoBehaviour

{
public GameObject Elephant;
    void Start()
    {
       Instantiate(Elephant, transform.position, transform.rotation); 
    }

    
    void Update()
    {
        GameObject[] Players = GameObject.FindGameObjectsWithTag("Player");
        int PlayersCount = Players.Length;
        if (PlayersCount == 0)
        {
            Instantiate(Elephant, transform.position, transform.rotation); 
        }
    }
}