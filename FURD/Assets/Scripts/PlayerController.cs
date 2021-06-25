using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 3f;
    public float jumpForce = 250f;
    private Rigidbody rBody;
    private Animator animator;
    private Vector3 moving;
    private bool jumping = false;
    private bool onGround = true;

    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        moving.x = Input.GetAxisRaw("Horizontal");
        //moving.z = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", moving.x);
        animator.SetFloat("Vertical", speed);
        animator.SetFloat("Speed", speed);

        if (Input.GetButtonDown("Jump") && onGround)
        {
            jumping = true;
        }
        animator.SetBool("Jump", jumping);
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        rBody.MovePosition(transform.position + moving * Time.deltaTime * speed);
        if (jumping && onGround)
        {
            rBody.AddForce(Vector3.up * jumpForce * Time.deltaTime, ForceMode.VelocityChange);
            onGround = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        jumping = false;
        onGround = true;
    }
}
