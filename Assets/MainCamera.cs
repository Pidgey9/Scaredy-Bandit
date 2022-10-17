using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    private void Update()
    {
        transform.position = GameObject.Find("Player").transform.position + Vector3.forward * (-10);
    }
}
