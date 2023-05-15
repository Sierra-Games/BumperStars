using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class AILapWinTracker : MonoBehaviour
{
    public string loseScene; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Because I'm lazy we just piggy back off our player place display tracker as it contains all of our ai and details we need 
        foreach (TrackProgress ai in PlayerPlaceTracker.inst.playersPlace)
        {
            if (ai.GetCurrentLap() > 3 && ai.GetLastCheckpointID() > 1 && ai.gameObject.tag != "Player")
            {
                SceneManager.LoadScene(loseScene); 
            }
        }
    }
}
