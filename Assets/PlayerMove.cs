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
    public float gravityScale;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        animator = GameObject.Find("Bandit").GetComponent<Animator>();
    }
    private void Update()
    {
        // Mostly animators
        if (rb.velocity.x == 0 && rb.velocity.z == 0) animator.SetBool("Move", false);
        else animator.SetBool("Move", true);
        animator.SetFloat("Forward", f);
        animator.SetFloat("Right", r);
        animator.SetFloat("Blend", 1);
        Fall();
        // Sprint and crouch animators
        if (Input.GetKey(KeyCode.LeftShift))
        {
            animator.SetFloat("Blend", 0.5f);
        }
        if (Input.GetKey(KeyCode.R))
        {
            animator.SetFloat("Blend", 0);
        }

        // Jump
        /*if (Input.GetButtonDown("Fire1"))
        {
            jump.y = jumpForce;
            animator.SetTrigger("Jump");
        }
        else jump.y = rb.velocity.y;*/
    }
    private void FixedUpdate()
    {
        // Forward and strafe movement for player
        f = Input.GetAxis("Vertical");
        r = Input.GetAxisRaw("Horizontal");
        rota = Camera.main.transform.rotation;
        rota.x = 0;
        rota.z = 0;
        // remove camera sickness while strafing
        if (f != 0) if ( r == 0 ) transform.rotation = rota;
        rb.angularVelocity = Vector3.zero;

        // every move for rigidbody
        rb.velocity = (transform.forward * f + transform.right * r).normalized
            * speed * Time.fixedDeltaTime
            + jump * Time.fixedDeltaTime 
            + gravityScale * Vector3.down * Time.fixedDeltaTime;

    }
    void Fall()
    {
        if (rb.velocity.y < -4) animator.SetBool("Fall", true);
        else animator.SetBool("Fall", false);
    }
}
