using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 


public class AIDeathTracker : MonoBehaviour
{
    public static AIDeathTracker inst;
    public int aiCount;
    public string winScene; 
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
        if (aiCount == 0)
        {
            SceneManager.LoadScene(winScene); 
        }
    }
}
