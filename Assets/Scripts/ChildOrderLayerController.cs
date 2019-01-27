using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildOrderLayerController : MonoBehaviour
{
    private SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.sortingOrder = transform.parent.gameObject.GetComponent<SpriteRenderer>().sortingOrder + 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
