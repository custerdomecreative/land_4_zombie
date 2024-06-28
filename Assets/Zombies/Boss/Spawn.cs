using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Spawn : MonoBehaviour
{



    public GameObject zombiePrefab;
    public int number;
    public float spawnRadius;
    public bool spawnOnStart = true;








    // Start is called before the first frame update
    void Start()
    {
        if (spawnOnStart)
            SpawnAll();
    }
    void SpawnAll()
    { 
        for(int i =0; i < number; i++)
        {
            Vector3 randomPoint = this.transform.position + Random.insideUnitSphere * spawnRadius;

            NavMeshHit hit;
            if (NavMesh.SamplePosition(randomPoint, out hit, 10f, NavMesh.AllAreas))
            {
                Instantiate(zombiePrefab, hit.position, Quaternion.identity);
            }
            else
                i--;
        }

    }

    
    void OnTriggerEnter(Collider collider)
    {
        if (!spawnOnStart && collider.gameObject.tag == "Player")
            SpawnAll();
    }

}
