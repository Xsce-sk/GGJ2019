using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vacuum : MonoBehaviour
{
    private bool haveVacuum = false;
    public int vacuumPoints = 20;
    public SpriteRenderer vacuumIcon;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.name == "VacuumCleaner")
        {
            haveVacuum = true;
            vacuumIcon.enabled = true;
            Destroy(col.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.name.Contains("Dirt") && haveVacuum)
        {
            Score.scoreTracker += vacuumPoints;
            Destroy(col.gameObject);
        }
    }

}
