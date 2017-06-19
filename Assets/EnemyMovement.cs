using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

    public Transform player;
    UnityEngine.AI.NavMeshAgent agent;
    UnityEngine.AI.NavMeshObstacle navMeshObstacle;

    void Start () 
    {
        agent = GetComponent< UnityEngine.AI.NavMeshAgent >();
        navMeshObstacle = GetComponent<UnityEngine.AI.NavMeshObstacle>();
    }

    void Update () 
    {
        if ((player.position - transform.position).sqrMagnitude < Mathf.Pow(agent.stoppingDistance, 2))
        {
            // If the agent is in attack range, become an obstacle and
            // disable the NavMeshAgent component
            navMeshObstacle.enabled = true;
            agent.enabled = false;
        }
        else
        {
            // If we are not in range, become an agent again
            navMeshObstacle.enabled = false;
            agent.enabled = true;

            agent.destination = player.position;
        }        
    }	
}
