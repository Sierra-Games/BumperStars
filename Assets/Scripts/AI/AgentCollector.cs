using KartGame.AI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentCollector : MonoBehaviour
{
    public List<GameObject> Agents = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(CheckpointCollector.Instance.Checkpoints.Count);
        for (int i = 0; i < this.transform.childCount; ++i)
        {
            GameObject Agent = this.transform.GetChild(i).gameObject;
            Agent.GetComponent<KartAgent>().Colliders = CheckpointCollector.Instance.Checkpoints.ToArray();
        }
    }

    // Update is called once per frame
    void Update()
    {

        
    }
}
