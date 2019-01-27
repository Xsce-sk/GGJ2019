using System;
using UnityEngine;
using UnityEngine.Events;

public class Cleaner : MonoBehaviour
{
    [Serializable]
    public class CleanableEvent : UnityEvent<Cleaner>
    { }

    enum Direction { Up, Down, Left, Right };

    public KeyCode cleanKey = KeyCode.Mouse1;
    public bool isCleaning;
    public CleanableEvent OnClean;
    
    protected BoxCollider2D m_BoxCollider2D;
    protected Collider2D m_Target;
    [SerializeField] Direction m_Direction;

    protected bool m_CanClean;

    public void StopCleaning()
    {
        isCleaning = false;
    }

    void Awake()
    {
        m_BoxCollider2D = GetComponent<BoxCollider2D>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Dirty"))
        {
            m_CanClean = true;
            m_Target = collision;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Dirty"))
        {
            m_CanClean = false;
        }
    }

    void Update()
    {
        if (MovementButtonPressedReleased())
        {
            m_Direction = FindPlayerDirection();
        }

        if (!isCleaning)
        {
            if (Input.GetKey(cleanKey))
            {
                CheckClean();

                if (m_CanClean)
                {
                    isCleaning = true;
                    GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                }
            }
        }
        else // Cleaning
        {
            ReadCleaningInputs();
        }

        
        if (Input.GetKeyUp(cleanKey))
        {
            isCleaning = false;
        }
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

    void CheckClean()
    {
        Vector2 direction = GetDirection();
        float distance = 1.5f;
        Vector3 pos = new Vector3(transform.position.x, transform.position.y - 1.5f, transform.position.z);
        RaycastHit2D cleanCheck = Physics2D.Raycast(pos, direction, distance);
        Debug.DrawRay(pos, direction.normalized * distance, Color.green, 1.0f);
        if (cleanCheck.collider != null)
        {
            print(cleanCheck.collider.tag);
            if (cleanCheck.collider.CompareTag("Dirty"))
            {
                m_CanClean = true;
                m_Target = cleanCheck.collider;
            }
            else
                m_CanClean = false;
        }
        else
            m_CanClean = false;
    }

    Direction FindPlayerDirection()
    {
        Direction dir = m_Direction;
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

    Vector2 GetDirection()
    {
        if (m_Direction == Direction.Left)
            return new Vector2(-1f, 0f);
        else if (m_Direction == Direction.Right)
            return new Vector2(1f, 0f);
        else if (m_Direction == Direction.Down)
            return new Vector2(0f, -1f);
        else
            return new Vector2(0f, 1f);
    }

    void ReadCleaningInputs()
    {
        if (Input.GetKeyDown(KeyCode.W))
            CleanObject();
        if (Input.GetKeyDown(KeyCode.A))
            CleanObject();
        if (Input.GetKeyDown(KeyCode.S))
            CleanObject();
        if (Input.GetKeyDown(KeyCode.D))
            CleanObject();
    }

    void CleanObject()
    {
        Cleanable cleanable = m_Target.GetComponent<Cleanable>();
        cleanable.ReceiveClean();
    }
}
