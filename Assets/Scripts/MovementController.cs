using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public float moveSpeed = 10f;
    private Rigidbody2D rb2d;
    private float xVelocity = 0f;
    private float yVelocity = 0f;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            xVelocity = -moveSpeed;            
        }

        if (Input.GetKey(KeyCode.D))
        {
            xVelocity = moveSpeed;
        }

        if (Input.GetKey(KeyCode.W))
        {
            yVelocity = moveSpeed;
        }

        if (Input.GetKey(KeyCode.S))
        {
            yVelocity = -moveSpeed;
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            xVelocity = 0;
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            xVelocity = 0;
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            yVelocity = 0;
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            yVelocity = 0;
        }

        rb2d.velocity = new Vector2(xVelocity, yVelocity);
    }
}
