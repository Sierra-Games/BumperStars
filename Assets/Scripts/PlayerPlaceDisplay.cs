using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerPlaceDisplay : MonoBehaviour
{
    public TextMeshProUGUI display;
    public TrackProgress player; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        display.text = $"Place: {player.place} / {AIDeathTracker.inst.aiCount}"; 
    }
}
