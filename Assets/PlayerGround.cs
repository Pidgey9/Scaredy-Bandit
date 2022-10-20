using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGround : MonoBehaviour
{
    public Transform ground;
    public Vector3 boxDetector;
    public bool isGrounded;
    public LayerMask groundLayer;
    private void Update()
    {
        Collider[] box = Physics.OverlapBox(ground.position, boxDetector, Quaternion.identity, groundLayer);
        isGrounded = box.Length > 0;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireCube(ground.position, boxDetector * 2);
    }
}
