using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetBoundary : MonoBehaviour
{
    void OnTriggerEnter(Collider obj)
    {
        // Check if player is what collided with the lava 
        if (obj.tag == "Player")
        {
            // If it was the player we load the loss/death screen and allow them to reset the level or retry 
            // May want to make this less hardcoded in the future
            SceneManager.LoadScene(2); 
        }
        else if (obj.tag == "Agent")
        {
            // Doc 1 ai from our ai count 
            AIDeathTracker.inst.aiCount--;

            PlayerPlaceTracker.inst.playersPlace.Remove(obj.GetComponent<TrackProgress>()); 
            //Destroy(obj.transform.gameObject);
            //Let's just disable for now, lots of runtime exceptions due to active MLAgent for some reason
            obj.transform.gameObject.SetActive(false);
        }
    }
}
