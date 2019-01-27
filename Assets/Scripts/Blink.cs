using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Blink : MonoBehaviour
{
    public GameObject x;
    public float counter = 1f;
    private float count = 0;

    // Start is called before the first frame update
    void Start()
    {
        count = Time.time + counter;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= count)
        {
            if (x.activeSelf)
            {
                x.SetActive(false);
            }
            else if(!x.activeSelf)
                x.SetActive(true);

            count = Time.time + counter;
        }
    }
}
