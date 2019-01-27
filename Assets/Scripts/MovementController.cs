using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public float moveSpeed = 10f;
    public Animator animator;
    private Rigidbody2D rb2d;
    private float xVelocity = 0f;
    private float yVelocity = 0f;
    private Cleaner m_Cleaner;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        m_Cleaner = GetComponent<Cleaner>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!m_Cleaner.isCleaning)
        {
            if (Input.GetKey(KeyCode.A))
            {
                animator.SetFloat("hSpeed", 1);
                xVelocity = -moveSpeed;
            }

            if (Input.GetKey(KeyCode.D))
            {
                animator.SetFloat("hSpeed", 1);
                xVelocity = moveSpeed;
            }

            if (Input.GetKey(KeyCode.W))
            {
                yVelocity = moveSpeed;
                animator.SetFloat("vSpeed", 1);
            }

            if (Input.GetKey(KeyCode.S))
            {
                yVelocity = -moveSpeed;
                animator.SetFloat("vSpeed", -1);
            }

            if (Input.GetKeyUp(KeyCode.A))
            {
                xVelocity = 0;
                animator.SetFloat("hSpeed", 0);
            }

            if (Input.GetKeyUp(KeyCode.D))
            {
                xVelocity = 0;
                animator.SetFloat("hSpeed", 0);
            }

            if (Input.GetKeyUp(KeyCode.W))
            {
                yVelocity = 0;
                animator.SetFloat("vSpeed", 0);
            }

            if (Input.GetKeyUp(KeyCode.S))
            {
                yVelocity = 0;
                animator.SetFloat("vSpeed", 0);
            }

            rb2d.velocity = new Vector2(xVelocity, yVelocity);
        }
    }
}
