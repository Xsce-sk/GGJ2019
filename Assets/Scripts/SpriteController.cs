using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteController : MonoBehaviour
{
    Transform spriteTransform;
    Transform spawnerTransform;

    public BoxCollider2D playerCollider;
    public GameObject spawner;
    [SerializeField] private bool DEBUG_TRACE = true;
    [SerializeField] private float horizontal;
    [SerializeField] private float vertical;

    void Start()
    {
        spriteTransform = this.GetComponent<Transform>();
        spawnerTransform = spawner.GetComponent<Transform>();

    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        // Facing Left or Right
        if (horizontal != 0)
        {
            spriteTransform.localScale = new Vector3(horizontal, spriteTransform.localScale.y, spriteTransform.localScale.z);
            
            //playerCollider.offset = new Vector2(2.0f, -0.333333f);
            spawnerTransform.localPosition = new Vector3(1.0f, 0.0f, 0.0f);

            if (DEBUG_TRACE)
                print("Facing Right");
        }/*
            else
            {
                playerCollider.offset = new Vector2(-2.0f, -0.333333f);
                spawnerTransform.localPosition = new Vector3(1.0f, -0.33f, 0.0f);

                if (DEBUG_TRACE)
                    print("Facing Left");
            }*/
        // Facing Up or Down
        else if (vertical != 0)
        {
            if (vertical == 1)
            {
                // Switch to sprite facing up
                //playerCollider.offset = new Vector2(0.0f, 1.0f);
                spawnerTransform.localPosition = new Vector3(0.0f, 0.5f, 0.0f);



                if (DEBUG_TRACE)
                    print("Facing Up");
            }
            else if (vertical == -1)
            {
                // Switch to sprite facing down
                //playerCollider.offset = new Vector2(0.0f, -1.666667f);
                spawnerTransform.localPosition = new Vector3(0.0f, -1.0f, 0.0f);



                if (DEBUG_TRACE)
                    print("Facing Down");
            }
        }

    }
}
