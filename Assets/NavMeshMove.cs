using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshMove : MonoBehaviour
{
    NavMeshAgent agent;
    Camera test;
    public Transform[] patrol;
    public int index;
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    private void Start()
    {
        index = 0;
        agent.SetDestination(patrol[index].position);
    }
    private void Update()
    {
        if (index < patrol.Length)
        {
            if (agent.remainingDistance < 1f) index++;
        }
        else index = 0;
        if (index < patrol.Length) agent.SetDestination(patrol[index].position);
    }
    void HitRay()
    {
        RaycastHit hit;
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = test.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                agent.SetDestination(hit.point);
            }
        }

    }
}
