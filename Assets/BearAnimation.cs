using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearAnimation : MonoBehaviour
{
    Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        if (GetComponent<NavMeshMove>() == true) animator.SetBool("RunForward", true);
        else animator.SetBool("RunForward", false);
    }
}
