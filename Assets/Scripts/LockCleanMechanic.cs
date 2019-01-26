using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class LockCleanMechanic : MonoBehaviour
{
    [SerializeField] BoxCollider2D objBoxCollider2D;

    void Start()
    {
        objBoxCollider2D = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}
