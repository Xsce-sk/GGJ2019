using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteController : MonoBehaviour
{
    Transform spriteTransform;
    [SerializeField] private bool DEBUG_TRACE = true;
    [SerializeField] private float horizontal;
    [SerializeField] private float vertical;

    void Start()
    {
        spriteTransform = this.GetComponent<Transform>();
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        // Facing Left or Right
        if (horizontal != 0)
        {
            spriteTransform.localScale = new Vector3(horizontal, 1.0f, 1.0f);
            if (DEBUG_TRACE)
                print("Facing left or right");
        }
        // Facing Up or Down
        else if (vertical != 0)
        {
            if (vertical == 1)
            {
                // Switch to sprite facing up

                if(DEBUG_TRACE)
                    print("Facing Up");
            }
            else if (vertical == -1)
            {
                // Switch to sprite facing down

                if (DEBUG_TRACE)
                    print("Facing Down");
            }
        }

    }
}
