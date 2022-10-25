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
        move = new Vector3(h,0,v).normalized;
        // animators
        animator.SetFloat("Forward", 1);
        animator.SetFloat("Blend", 1);
        if (h != 0 || v != 0) animator.SetBool("Move", true);
        else animator.SetBool("Move", false);
        // bandit rotation
        BanditRotation(v, h);
        // crouch
    }
    private void FixedUpdate()
    {
        rb.velocity = move * speed * Time.fixedDeltaTime 
            + Vector3.down * gravity * Time.fixedDeltaTime;
    }
    void BanditRotation(float v, float h)
    {
        bandit = GameObject.Find("Bandit").transform;
        if (h == 1) bandit.transform.rotation = Quaternion.Euler(0, 90, 0);
        if (h == -1) bandit.transform.rotation = Quaternion.Euler(0, -90, 0);
        if (v == 1) bandit.transform.rotation = Quaternion.Euler(0, 0, 0);
        if (v == -1) bandit.transform.rotation = Quaternion.Euler(0, 180, 0);
        if (v == 1 && h == 1) bandit.transform.rotation = Quaternion.Euler(0, 45, 0);
        if (v == 1 && h == -1) bandit.transform.rotation = Quaternion.Euler(0, -45, 0);
        if (v == -1 && h == 1) bandit.transform.rotation = Quaternion.Euler(0, 135, 0);
        if (v == -1 && h == -1) bandit.transform.rotation = Quaternion.Euler(0, -135, 0);
    }
}
