using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Detection : MonoBehaviour
{
    public Transform center;
    public float rad;
    public float dist;
    Vector2 circle;
    Vector3 location;
    RaycastHit hit;
    private void Update()
    {
        circle = Random.insideUnitCircle * rad;
        location = new Vector3(circle.x, circle.y, 0);
        try
        {
            if (Physics.Raycast(center.position, center.forward * dist + location, out hit))
            {
                if (hit.collider.CompareTag("Player"))
                {
                    GetComponent<NavMeshMove>().enabled = false;
                    if (gameObject.name == "Bear_4") GetComponent<NavMeshAgent>().enabled = false;
                    GetComponent<TheHunt>().enabled = true;
                }
            }
        }
        catch { }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawRay(center.position, center.forward * dist + location);
    }
}
