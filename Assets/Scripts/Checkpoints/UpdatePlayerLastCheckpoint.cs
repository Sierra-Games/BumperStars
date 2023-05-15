using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdatePlayerLastCheckpoint : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject obj = other.gameObject;
        if (obj.tag == "Player" || obj.tag == "Agent")
        {
            TrackProgress tp;
            if (obj.tag == "Agent")
            {
                if (obj.transform.TryGetComponent<TrackProgress>(out tp))
                {

                    tp.PassCheckpoint(this.name);
                }
            }
            else
            {
                if (obj.transform.root.TryGetComponent<TrackProgress>(out tp))
                {

                    tp.PassCheckpoint(this.name);
                }
            } 
        }
    }
}
