using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionControls : MonoBehaviour
{
    public enum Direction { Up, Down, Left, Right };
    public static Direction facing = Direction.Right;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (MovementButtonPressedReleased())
        {
            facing = FindPlayerDirection();
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
}
