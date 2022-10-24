using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Move2D : MonoBehaviour
{
    Rigidbody rb;
    Vector3 move;
    public float speed;
    public Animator animator;
    public float gravity;
    Transform bandit;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        //move
        float v = Input.GetAxisRaw("Vertical");
        float h = Input.GetAxisRaw("Horizontal");
        move = new Vector3(h,0,v);
        // animators
        animator.SetFloat("Blend", 1);
        animator.SetFloat("Forward", 1);
        if (h != 0 || v != 0) animator.SetBool("Move", true);
        else animator.SetBool("Move", false);
        // bandit rotation
        bandit = GameObject.Find("Bandit").transform;
        if (h == 1) bandit.transform.rotation.ToEulerAngles(0, 90, 0);
    }
    private void FixedUpdate()
    {
        rb.velocity = move * speed * Time.fixedDeltaTime 
            + Vector3.down * gravity * Time.fixedDeltaTime;
    }
}
