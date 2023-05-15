using System.Collections;
using System.Collections.Generic;
using System.Management.Instrumentation;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector3 LastCheckpoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.tag == "ResetBoundary")
        {

            this.transform.position = LastCheckpoint;

        }
    }
}
