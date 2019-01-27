using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderLayerControl : MonoBehaviour
{
    public bool isPlayer = false;
    private SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.sortingOrder = (int)-transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if(isPlayer)
            sr.sortingOrder = (int)-transform.position.y;
    }
}
