using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildOrderLayerController : MonoBehaviour
{
    private SpriteRenderer sr;
    bool setOrder = true;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(setOrder)
        {
            sr.sortingOrder = transform.parent.gameObject.GetComponent<SpriteRenderer>().sortingOrder + 1;
            setOrder = false;
        }
    }
}
