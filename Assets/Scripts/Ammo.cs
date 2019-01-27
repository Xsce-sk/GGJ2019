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
    public Transform playerTransform;
    public float offset = 1;
    public int scorePoints = 10;
    
    // Start is called before the first frame update
    void Start()
    {
        //spawner = GameObject.Find("Spawner").GetComponent<Transform>();
        rb2d = GetComponent<Rigidbody2D>();
        //playerTransform = GameObject.Find("Player_Sprite").GetComponent<Transform>();

        /*if (spawner.localPosition.x != 0)
        {
            if (playerTransform.localScale.x > 0)
                v = rb2d.velocity = new Vector2(speed, 0);

            if (playerTransform.localScale.x < 0)
                v = rb2d.velocity = new Vector2(-speed, 0);
        }
        else if (spawner.localPosition.y != 0)
        {
            if (spawner.localPosition.y > 0)
                v = rb2d.velocity = new Vector2(0, speed);

            if (spawner.localPosition.y < 0)
                v = rb2d.velocity = new Vector2(0, -speed);
        }*/

        if(DirectionControls.facing == DirectionControls.Direction.Right)
        {
            v = rb2d.velocity = new Vector2(speed, 0);
        }
        else if (DirectionControls.facing == DirectionControls.Direction.Left)
        {
            v = rb2d.velocity = new Vector2(-speed, 0);
        }
        else if (DirectionControls.facing == DirectionControls.Direction.Up)
        {
            v = rb2d.velocity = new Vector2(0, speed);
        }
        else if (DirectionControls.facing == DirectionControls.Direction.Down)
        {
            v = rb2d.velocity = new Vector2(0, -speed);
        }


    }

    // Update is called once per frame
    void Update()
    {
        /*if (spawner.localPosition.x != 0)
        {
            if (playerTransform.localScale.x > 0)
                rb2d.velocity = new Vector2(speed, 0);

            if (playerTransform.localScale.x < 0)
                rb2d.velocity = new Vector2(-speed, 0);
        }

        if (spawner.localPosition.y != 0)
        {
            if (spawner.localPosition.y > 0)
                rb2d.velocity = new Vector2(0, speed);

            if (spawner.localPosition.y < 0)
                rb2d.velocity = new Vector2(0, -speed);
        }*/
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name != "Player_Sprite")
        {
            if (!(col.gameObject.name == "Trashcan" && gameObject.name.Contains("Trash") || col.gameObject.name == "Hamper" && gameObject.name.Contains("Clothes")))
            {
                Vector3 spawnLocation = gameObject.transform.position;

                if (v.x > 0)
                {
                    spawnLocation += new Vector3(-offset, 0, 0);
                }
                else if (v.x < 0)
                {
                    spawnLocation += new Vector3(offset, 0, 0);
                }
                else if (v.y > 0)
                {
                    spawnLocation += new Vector3(0, -offset, 0);
                }
                else if (v.y < 0)
                {
                    spawnLocation += new Vector3(0, offset, 0);
                }

                Instantiate(ammoType, spawnLocation, Quaternion.identity);
            }
            else if (col.gameObject.name == "Trashcan" && gameObject.name.Contains("Trash") || col.gameObject.name == "Hamper" && gameObject.name.Contains("Clothes"))
            {
                Score.scoreTracker += scorePoints;
            }

            Destroy(gameObject);
        }

    }
}
