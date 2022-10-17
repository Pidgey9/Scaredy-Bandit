using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    CharacterController cc;
    public float speed;
    private void Awake()
    {
        cc = GetComponent<CharacterController>();
    }
    private void Update()
    {
        Quaternion rota = Camera.main.transform.rotation;
        rota.x = 0;
        rota.z = 0;
        transform.rotation = rota;
        Vector3 move = transform.forward * Input.GetAxisRaw("Vertical") 
            + transform.right * Input.GetAxisRaw("Horizontal");
        cc.Move(move * speed * Time.deltaTime);
    }
}
