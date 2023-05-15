using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackProgress : MonoBehaviour
{
    

    [SerializeField]
    private Vector3 lastCheckpointPosition;
    [SerializeField]
    private Quaternion lastCheckpointRotation;
    [SerializeField]
    private int lastCheckpointID;
    [SerializeField]
    private int currentLap;
    [SerializeField]
    public int place;



    // Start is called before the first frame update
    void Start()
    {
        currentLap = 1;
        lastCheckpointID = -1; // No Checkpoint can have an id less than 0

        lastCheckpointPosition = transform.position; // Just start it at racer start position
        lastCheckpointRotation = transform.rotation;
    }


    public void PassCheckpoint(string checkpointName)
    {
        CheckpointCollector.Checkpoint cp = new CheckpointCollector.Checkpoint();
        if(CheckpointCollector.Instance.checkpointInfo.TryGetValue(checkpointName, out cp))
        {
            if (cp.id != lastCheckpointID)
            {
                //only if we are not passing the start gate for the first time
                if (lastCheckpointID != -1)
                {
                    lastCheckpointID = cp.id;
                    lastCheckpointPosition = cp.transform.position;
                    lastCheckpointRotation = cp.transform.rotation;

                    if (cp.id == 0)
                    {
                        currentLap += 1;
                    }
                }
                else
                {
                    //start
                    if (cp.id == 0)
                        lastCheckpointID = 0;
                }
            }
        }
        else
        {
            Debug.Log(string.Format("Invalid: {0}", checkpointName));
        }
    }

    public Vector3 GetLastCheckpointPosition()
    {
        return lastCheckpointPosition;
    }

    public Quaternion GetLastCheckpointRotation()
    {
        return lastCheckpointRotation;
    }

    public int GetLastCheckpointID()
    {
        return lastCheckpointID;
    }

    public int GetCurrentLap()
    {
        return currentLap;
    }
}
