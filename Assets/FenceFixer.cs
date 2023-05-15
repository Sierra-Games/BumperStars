using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FenceFixer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < this.transform.childCount; i++)
        {
            try
            {
                GameObject fence = this.transform.GetChild(i).gameObject.transform.GetChild(0).gameObject;
                Bounds bounds = fence.GetComponent<MeshCollider>().bounds;
                fence.transform.localScale = new Vector3(1.0f, 0.1f, 1.0f);
            }
            catch { }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
