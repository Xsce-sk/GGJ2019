using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    private bool haveRawFood = false;
    private bool haveCookedFood = false;
    private bool haveBurntFood = false;
    private float startCookTime = 0;
    public float timeToCook = 30;
    private bool foodReady = false;
    private bool foodBurnt = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(startCookTime != 0)
        {
            if ((startCookTime + timeToCook + 10f) > Time.time && Time.time> (startCookTime + timeToCook))
                foodReady = true;
            else if (startCookTime + timeToCook + 10f < Time.time)
                foodBurnt = true;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Food" && !haveRawFood)
        {
            haveRawFood = true;
            Debug.Log("have raw food");
            Destroy(col.gameObject);
        }

        if(col.gameObject.name == "Stove" && haveRawFood && startCookTime == 0)
        {
            haveRawFood = false;
            Debug.Log("started cooking");
            startCookTime = Time.time;
        }

        if(foodBurnt && startCookTime != 0 && col.gameObject.name == "Stove")
        {
            Debug.Log("Have burnt food");
            haveBurntFood = true;
        }
        else if (foodReady && startCookTime != 0 && col.gameObject.name == "Stove")
        {
            Debug.Log("have cooked food");
            haveCookedFood = true;
        }

        if(haveCookedFood || haveBurntFood)
        {
            //can put on table
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {

    }
}
