using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerMobile : MonoBehaviour
{
    public float speed = 3f;
    public float jumpForce = 250f;
    public Joystick joystick;
    public AudioClip jumpSound;

    private AudioSource audioSource;
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
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        moving.x = joystick.Horizontal;
        //jump = joystick.Vertical > 0.3f;
        //moving.z = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", moving.x);
        animator.SetFloat("Vertical", speed);
        animator.SetFloat("Speed", speed);

        if (joystick.Vertical > 0.6 && onGround)
        {
            jumping = true;
            audioSource.PlayOneShot(jumpSound);
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
        if (collision.gameObject.CompareTag("Ground"))
        {
            jumping = false;
            onGround = true;
        }

    }
}
