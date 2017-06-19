using UnityEngine;
using System.Collections;

public class CreatureMovement : MonoBehaviour {

    UnityEngine.AI.NavMeshAgent agent;
    Ray ray;

    void Start () 
    {
        agent = GetComponent< UnityEngine.AI.NavMeshAgent >();
    }

    void Update () 
    {
        Debug.DrawLine(ray.origin, ray.GetPoint(200), Color.red);

        if (Input.GetMouseButtonDown(0)) 
        {
            // ScreenPointToRay() takes a location on the screen
            // and returns a ray perpendicular to the viewport
            // starting from that location
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;
            // Note that "11" represents the number of the "ground"
            // layer in my project. It might be different in yours!
            LayerMask mask = 1 << 8;

            // Cast the ray and look for a collision
            if (Physics.Raycast(ray, out hit, 200, mask)) 
            {
                agent.destination = hit.point;
            }
        }
    }
}
