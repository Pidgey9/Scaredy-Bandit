using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stairs : MonoBehaviour
{
    Rigidbody rb;
    Vector3 averagePos;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        averagePos = GameObject.Find("RayDetector").GetComponent<RayGround>().AverageHeight();
        Vector3 newPos = new Vector3(rb.position.x, averagePos.y, rb.position.z);
        rb.MovePosition(newPos);
    }
}
