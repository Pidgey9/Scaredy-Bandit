using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Rigidbody rb;
    Quaternion rota;
    public float speed;
    float f;
    float r;
    Animator animator;
    Vector3 jump;
    public float jumpForce;
    AnimationCurve curve;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        animator = GameObject.Find("Bandit").GetComponent<Animator>();
    }
    private void Update()
    {
        if (rb.velocity == Vector3.zero) animator.SetBool("Move", false);
        else animator.SetBool("Move", true);
        animator.SetFloat("Forward", f);
        animator.SetFloat("Right", r);

        // Jump
        if (Input.GetButton("Fire1"))
        {
            jump.y = jumpForce;
            animator.SetTrigger("Jump");
        }
        else jump.y = rb.velocity.y;
    }
    private void FixedUpdate()
    {
        // Forward and strafe movement for player
        f = Input.GetAxis("Vertical");
        r = Input.GetAxisRaw("Horizontal");
        rota = Camera.main.transform.rotation;
        rota.x = 0;
        rota.z = 0;
        if (f != 0) if ( r == 0 ) transform.rotation = rota;
        rb.angularVelocity = Vector3.zero;


        rb.velocity = (transform.forward * f + transform.right * r).normalized
            * speed * Time.fixedDeltaTime
            + jump * Time.fixedDeltaTime;

    }
}
