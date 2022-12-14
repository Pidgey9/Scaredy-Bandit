using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpAnimation : MonoBehaviour
{
    public AnimationCurve jumpCurve;
    float jumpTimer;
    public Animator animator;
    public Transform sprite;
    public float jumpHeight;
    public float jumpDuration;
    bool isJumping;
    bool ground;
    private void Awake()
    {
        jumpTimer = 0;
        isJumping = false;
    }
    private void Update()
    {
        ground = gameObject.GetComponent<PlayerGround>().isGrounded;
        if (Input.GetButton("Fire1") && ground)
        {
            isJumping = true;
        }
        if (isJumping)
        {
            animator.SetBool("Jump", true);
            JumpScript();
        }
        else animator.SetBool("Jump", false);

    }
    void JumpScript()
    {
        if (jumpTimer < jumpDuration)
        {
            jumpTimer += Time.deltaTime;
            float y = jumpCurve.Evaluate(jumpTimer / jumpDuration);
            sprite.position = transform.position + new Vector3(0, y * jumpHeight, 0);
            GetComponent<PlayerMove>().gravityScale = 0;
        }
        else
        {
            jumpTimer = 0;
            isJumping = false;
            GetComponent<PlayerMove>().gravityScale = 200;
        }
    }
}
