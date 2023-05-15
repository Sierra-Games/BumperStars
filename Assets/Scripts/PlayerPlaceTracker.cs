using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlaceTracker : MonoBehaviour
{
    public List<TrackProgress> playersPlace;
    public static PlayerPlaceTracker inst;

    private void Awake()
    {
        inst = this; 
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // we first sort the players based off checkpoints and then the amount of laps they're on 
        playersPlace.Sort((x, y) => x.GetLastCheckpointID().CompareTo(y.GetLastCheckpointID()));
        playersPlace.Sort((x, y) => x.GetCurrentLap().CompareTo(y.GetCurrentLap()));

        // We adjust the number of places based off how many ai are left 
        int place = AIDeathTracker.inst.aiCount; 

        // For every player/ai left alive we assign them their place (while place for ai doesn't matter much we still have
        // to iterate through the loop to give our player a place) 
        foreach (TrackProgress player in playersPlace)
        {
            player.place = place;
            // Prevents place ever being 0 for the player 
            if (place > 1)
            {
                place--;
            }
               
        }
    }
}
