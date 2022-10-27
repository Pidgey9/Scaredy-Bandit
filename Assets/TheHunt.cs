using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class TheHunt : MonoBehaviour
{
    public float speed;
    private void Update()
    {
        Vector3 diff = (GameObject.Find("Player").transform.position - transform.position).normalized;
        transform.position += diff * speed * Time.deltaTime;
        Quaternion orientation = Quaternion.LookRotation(diff);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, orientation, 360);
    }
}
