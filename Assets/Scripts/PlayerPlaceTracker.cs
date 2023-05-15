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
        playersPlace.Sort((x, y) => x.GetLastCheckpointID().CompareTo(y.GetLastCheckpointID()));
        playersPlace.Sort((x, y) => x.GetCurrentLap().CompareTo(y.GetCurrentLap()));

        int place = AIDeathTracker.inst.aiCount; 
        foreach (TrackProgress player in playersPlace)
        {
            player.place = place;
            if (place > 1)
            {
                place--;
            }
               
        }
    }
}
