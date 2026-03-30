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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            Instantiate(Elephant, Vector3.zero, Quaternion.identity);
        }
    }
}