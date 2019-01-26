using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    private Transform spawner;
    private Rigidbody2D rb2d;
    public float speed = 10;
    
    // Start is called before the first frame update
    void Start()
    {
        spawner = GameObject.Find("Spawner").GetComponent<Transform>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (spawner.localPosition.x != 0)
            rb2d.velocity = new Vector2(speed * spawner.localPosition.x, 0);

        if (spawner.localPosition.y != 0)
            rb2d.velocity = new Vector2(0, speed * spawner.localPosition.y);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Destroy(gameObject);
    }
}
