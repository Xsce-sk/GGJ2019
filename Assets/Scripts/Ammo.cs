using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    private Transform spawner;
    private Rigidbody2D rb2d;
    public float speed = 10;
    public GameObject ammoType;
    Vector2 v;
    
    // Start is called before the first frame update
    void Start()
    {
        spawner = GameObject.Find("Spawner").GetComponent<Transform>();
        rb2d = GetComponent<Rigidbody2D>();
        if (spawner.localPosition.x != 0)
            v = rb2d.velocity = new Vector2(speed * spawner.localPosition.x, 0);

        if (spawner.localPosition.y != 0)
            v = rb2d.velocity = new Vector2(0, speed * spawner.localPosition.y);
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
        Vector3 spawnLocation = col.gameObject.transform.position;

        if (v.x > 0)
        {
            spawnLocation += new Vector3(-1.5f, 0, 0);
        }
        else if (v.x < 0)
        {
            spawnLocation += new Vector3(1.5f, 0, 0);
        }
        else if (v.y > 0)
        {
            spawnLocation += new Vector3(0, -1.5f, 0);
        }
        else if (v.y < 0)
        {
            spawnLocation += new Vector3(0, 1.5f, 0);
        }

        Instantiate(ammoType, spawnLocation, Quaternion.identity);

        Destroy(gameObject);
    }
}
