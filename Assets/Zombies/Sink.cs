using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sink : MonoBehaviour
{
    float destoryHeight;
    public float sinkRate = 10;

    // Start is called before the first frame update
    void Start()
    {
        if (this.gameObject.tag == "Ragdoll")
            Invoke("StartSink", 5);
        
        
    }

    public void StartSink()
    {
        destoryHeight = Terrain.activeTerrain.SampleHeight(this.transform.position) - 5;
        Collider[] colList = this.transform.GetComponentsInChildren<Collider>();
        foreach (Collider c in colList)
        {
            Destroy(c);
        }

        InvokeRepeating("SinkIntoGround", sinkRate, 0.1f);
    }
    void SinkIntoGround()
    {
        this.transform.Translate(0, -0.001f, 0);
        if(this.transform.position.y < destoryHeight)
        {
            Destroy(this.gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
