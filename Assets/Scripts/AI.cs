using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    public Transform Destination, SpawnPoint;
    public GameObject Obstacle;
    void Start()
    {
        var NavAgent = GetComponent<NavMeshAgent>();
        NavAgent.SetDestination(Destination.position);
        Instantiate(Obstacle, new Vector3(SpawnPoint.position.x, SpawnPoint.position.y, SpawnPoint.position.z), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
