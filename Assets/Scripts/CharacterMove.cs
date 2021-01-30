using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Rigidbody2D))]
public class CharacterMove : MonoBehaviour
{
    [SerializeField]
    float xSpeed = 12;
    [SerializeField]
    float ySpeed = 12;
    [SerializeField]
    float xAirDivider = 2;
    [SerializeField]
    float yAirDivider = 20;

    bool isGrounded = false;

    public AudioClip landSound;
    public AudioClip jumpSound;

    Rigidbody2D rgbd;
    AudioSource audio;

    void Start()
    {
        rgbd = GetComponent<Rigidbody2D>();
        audio = GetComponent<AudioSource>();
        ContactToNotify bottomTrigger = transform.GetChild(0).Find("BottomTrigger").GetComponent<ContactToNotify>();
        bottomTrigger.collisionEnter.AddListener(TouchGround);
        bottomTrigger.collisionExit.AddListener(LeaveGround);
    }

    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");

        if (isGrounded)
        {
            rgbd.velocity = transform.right * xSpeed * h;
            if (Input.GetButtonDown("Vertical"))
            {
                rgbd.AddForce(transform.up * ySpeed * 20);
            }
        }
        else
        {
            rgbd.AddForce(transform.right * h * xSpeed / xAirDivider);

            if (Input.GetButton("Jump") && rgbd.velocity.y > (0.2 * ySpeed))
            {
                rgbd.AddForce(transform.up * ySpeed / yAirDivider);
            }

            rgbd.velocity = new Vector2(Mathf.Clamp(rgbd.velocity.x, -xSpeed, xSpeed), rgbd.velocity.y);
        }

        if (rgbd.velocity.x > 0)
        {
            transform.GetChild(0).rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
        }
        if (rgbd.velocity.x < 0)
        {
            transform.GetChild(0).rotation = Quaternion.Euler(0.0f, 180.0f, 0.0f);
        }
    }

    public void TouchGround(GameObject go)
    {
        audio.PlayOneShot(landSound);
        isGrounded = true;
    }

    public void LeaveGround(GameObject go)
    {
        audio.PlayOneShot(jumpSound);
        isGrounded = false;
    }
}

