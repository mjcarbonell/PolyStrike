using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float walkSpeed = 5;
    public float runSpeed = 10;
    public KeyCode runKey = KeyCode.LeftShift;
    public Animator anim;
    private Rigidbody rb;
     void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        float speed = Input.GetKey(runKey) ? runSpeed : walkSpeed;

        float inputX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float inputZ = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        rb.transform.Translate(inputX, 0, inputZ);
        
        anim.SetFloat("Speed", new Vector2(inputX, inputZ).magnitude);
    }
}
