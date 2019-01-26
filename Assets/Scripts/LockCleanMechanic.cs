using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class LockCleanMechanic : MonoBehaviour
{
    protected BoxCollider2D m_BoxCollider2D;

    protected bool m_IsCleaning;

    void Start()
    {
        m_BoxCollider2D = GetComponent<BoxCollider2D>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Dirty"))
        {
            // stop player movement
            m_IsCleaning = true;
        }
    }

    


}
