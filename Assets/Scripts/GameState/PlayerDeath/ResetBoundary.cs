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
            Debug.Log("here");
            // If it was the player we load the loss/death screen and allow them to reset the level or retry 
            // For now we just reload the level
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
        }
        else if (obj.tag == "Agent")
        {
            Destroy(obj.transform.gameObject);
        }
    }
}
