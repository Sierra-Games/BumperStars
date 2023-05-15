using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointCollector : MonoBehaviour
{
    public struct Checkpoint
    {
        public Checkpoint(int _id, Transform _transform)
        {
            id = _id;
            transform = _transform;
        }

        public int id;
        public Transform transform;
    }

    public static CheckpointCollector Instance;
    public List<BoxCollider> Checkpoints = new List<BoxCollider>();
    public Dictionary<string, Checkpoint> checkpointInfo = new Dictionary<string, Checkpoint>();

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        CollectCheckpoints();
        BuildCheckpointMap();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void CollectCheckpoints()
    {
        for (int i = 0; i < this.transform.childCount; ++i)
        {
            Checkpoints.Add(this.transform.GetChild(i).GetComponent<BoxCollider>());
        }
    }
    private void BuildCheckpointMap()
    {
        for (int i = 0; i < Checkpoints.Count; ++i)
        {
            string name = Checkpoints[i].name;

            Transform transform = Checkpoints[i].transform;
            Checkpoint checkpoint = new Checkpoint(i, transform);

            checkpointInfo.Add(name, checkpoint);
        }
        
    }
}
