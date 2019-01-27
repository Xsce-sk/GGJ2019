using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupAndThrow : MonoBehaviour
{
    public enum Direction { Up, Down, Left, Right };

    public Stack<int> inventory = new Stack<int>();
    public List<GameObject> ammo = new List<GameObject>();
    public Transform spawner;
    public Direction facing;
    private Rigidbody2D rb2d;
    public float speed = 5f;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        spawner = GameObject.Find("Spawner").GetComponent<Transform>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (MovementButtonPressedReleased())
        {
            facing = FindPlayerDirection();
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && inventory.Count > 0)
        {
            Instantiate(ammo[inventory.Pop()], spawner.position, Quaternion.identity);
            StartCoroutine("TempDisableMovement");
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.name.Contains("Trash") && !col.gameObject.name.Contains("Ammo"))
        {
            inventory.Push(0);
            Destroy(col.gameObject);
        }
        else if(col.gameObject.name.Contains("Clothes") && !col.gameObject.name.Contains("Ammo"))
        {
            inventory.Push(1);
            Destroy(col.gameObject);
        }
    }

    Direction FindPlayerDirection()
    {
        Direction dir = facing;
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        if (verticalInput < 0)
            dir = Direction.Down;
        else if (verticalInput > 0)
            dir = Direction.Up;

        if (horizontalInput < 0)
            dir = Direction.Left;
        else if (horizontalInput > 0)
            dir = Direction.Right;

        return dir;
    }

    bool MovementButtonPressedReleased()
    {
        return (Input.GetKeyDown(KeyCode.W) ||
            Input.GetKeyDown(KeyCode.A) ||
            Input.GetKeyDown(KeyCode.S) ||
            Input.GetKeyDown(KeyCode.D) ||
            Input.GetKeyUp(KeyCode.W) ||
            Input.GetKeyUp(KeyCode.A) ||
            Input.GetKeyUp(KeyCode.S) ||
            Input.GetKeyUp(KeyCode.D));
    }

    IEnumerator TempDisableMovement()
    {
        //disable
        GetComponent<MovementController>().enabled = false;
        animator.SetFloat("hSpeed", 0);
        animator.SetFloat("vSpeed", 0);
        rb2d.velocity = new Vector2(0, 0);

        if (facing == Direction.Up)
        {
            rb2d.AddForce(new Vector3(0, -1, 0) * speed);
            Debug.Log("Hello");
        }
        else if (facing == Direction.Down)
        {
            rb2d.AddForce(new Vector3(0, 1, 0) * speed);
        }
        else if (facing == Direction.Left)
        {
            rb2d.AddForce(new Vector3(1, 0, 0) * speed);
        }
        else if (facing == Direction.Right)
        {
            rb2d.AddForce(new Vector3(-1, 0, 0) * speed);
        }

        yield return new WaitForSeconds(0.25f);
        rb2d.velocity = new Vector2(0, 0);
        
        GetComponent<MovementController>().enabled = true;
        
    }
}
