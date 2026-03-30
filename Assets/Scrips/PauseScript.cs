using TMPro;
using UnityEngine;

public class PauseScript : MonoBehaviour
{

    public GameObject buttonText;
    public bool paused = false;
    public void TriggerPause()
    {
        if (paused == false)
        {
            paused = true;
            Time.timeScale = 0f; 
            buttonText.GetComponent<TextMeshProUGUI>().text = "UnPause";            
        } else if (paused == true)
        {
            paused = false;
            Time.timeScale = 1f; 
            buttonText.GetComponent<TextMeshProUGUI>().text = "Pause";
        }
    }
}
