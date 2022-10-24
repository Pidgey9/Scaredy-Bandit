using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayGround : MonoBehaviour
{
    public Transform[] raygrounds;
    public float raylenght;
    public LayerMask layerMask;
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        foreach ( Transform t in raygrounds)
        {
            Gizmos.DrawRay(t.position, Vector3.down * raylenght);
        }
    }
    public Vector3 AverageHeight()
    {
        int hitCount = 0;
        Vector3 combinedPos = Vector3.zero;
        RaycastHit hit;
        Vector3 averagePos = Vector3.zero;
        foreach (Transform t in raygrounds)
        {
            if (Physics.Raycast(t.position, Vector3.down, out hit, raylenght, layerMask))
            {
                hitCount++;
                combinedPos += hit.point;
            }
        }
        if (hitCount > 0)
        {
            averagePos = combinedPos / hitCount;
        }
        return averagePos;
    }
}
