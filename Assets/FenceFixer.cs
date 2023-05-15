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
                if (fence.layer != 14) //lol
                {
                    fence.transform.localScale = new Vector3(1.0f, 0.1f, 1.0f);
                    fence.AddComponent(System.Type.GetType("Explosive"));
                    fence.tag = "Fence";

                    Explosive e = fence.GetComponent<Explosive>();
                    e.SetExplosionForce(1000);
                    e.SetTriggerForce(0.5f);
                    e.SetExplosionRadius(5.0f);
                    e.setUpwardsModifier(1000f);
                    e.setBounceForce(100f);
                }

            }
            catch { }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
