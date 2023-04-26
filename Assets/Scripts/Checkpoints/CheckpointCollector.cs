using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointCollector : MonoBehaviour
{
    public static CheckpointCollector Instance;
    public List<BoxCollider> Checkpoints = new List<BoxCollider>();

    private void Awake()
    {
        Instance = this;
        for (int i = 0; i < this.transform.childCount; ++i)
            Checkpoints.Add(this.transform.GetChild(i).GetComponent<BoxCollider>());
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
