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

    void Start()
    {
        if (spawnOnStart)
        {
            Debug.Log("Spawning all zombies at start.");
            SpawnAll();
        }
    }

    void SpawnAll()
    {
        for (int i = 0; i < number; i++)
        {
            Vector3 randomPoint = this.transform.position + Random.insideUnitSphere * spawnRadius;

            NavMeshHit hit;
            if (NavMesh.SamplePosition(randomPoint, out hit, 10f, NavMesh.AllAreas))
            {
                Instantiate(zombiePrefab, hit.position, Quaternion.identity);
            }
            else
            {
                i--;
            }
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (!spawnOnStart && collider.gameObject.tag == "Player")
        {
            Debug.Log("Player entered spawn trigger, spawning all zombies.");
            SpawnAll();
        }
    }
}
