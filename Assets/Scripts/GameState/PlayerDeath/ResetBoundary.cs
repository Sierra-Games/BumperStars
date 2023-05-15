using KartGame.AI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetBoundary : MonoBehaviour
{
    private int lives = 3;
    bool canDecAgent = true;
    bool canDecPlayer = true;
    void OnTriggerEnter(Collider obj)
    {
        // Check if player is what collided with the lava 
        if (obj.tag == "Player")
        {
            
            if (lives == 0)
            {
                // If it was the player we load the loss/death screen and allow them to reset the level or retry 
                // May want to make this less hardcoded in the future

                SceneManager.LoadScene(2);
            }
            else if (canDecPlayer)
            {
                lives -= 1;
                TrackProgress tp = obj.GetComponent<TrackProgress>();
                obj.gameObject.transform.root.position = tp.GetLastCheckpointPosition();
                obj.gameObject.transform.root.rotation = tp.GetLastCheckpointRotation();
                canDecPlayer = false;
                StartCoroutine(ResetPlayer());
            }
        }
        else if (obj.tag == "Agent")
        {
            // Doc 1 ai from our ai count 
            KartAgent ka = obj.GetComponent<KartAgent>();
            

            if (ka.lives == 0)
            {
                AIDeathTracker.inst.aiCount--;

                // Remove the ai from our list of players, this makes our place tracking way more accurate 
                PlayerPlaceTracker.inst.playersPlace.Remove(obj.GetComponent<TrackProgress>());
                //Destroy(obj.transform.gameObject);
                //Let's just disable for now, lots of runtime exceptions due to active MLAgent for some reason
                obj.transform.gameObject.SetActive(false);
            }
            else if (canDecAgent)
            {
                ka.lives -= 1;
                ka.turn = true;
                canDecAgent= false;
                StartCoroutine(ResetAgent());
            }
        }
    }
    private void Update()
    {
        canDecAgent = true;
        canDecPlayer= true;
    }
    IEnumerator ResetAgent()
    {
        yield return new WaitForSeconds(1);
        canDecAgent = true;
    }
    IEnumerator ResetPlayer()
    {
        yield return new WaitForSeconds(1);
        canDecPlayer = true;
    }
}
