using System;
using UnityEngine;
using UnityEngine.Events;

public class Cleaner : MonoBehaviour
{
    [Serializable]
    public class CleanableEvent : UnityEvent<Cleaner>
    { }

    public KeyCode cleanKey;
    public CleanableEvent OnClean;
    
    protected BoxCollider2D m_BoxCollider2D;
    protected Collider2D m_Target;

    protected bool m_CanClean;
    protected bool m_IsCleaning;
    
    void Awake()
    {
        m_BoxCollider2D = GetComponent<BoxCollider2D>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Dirty"))
        {
            m_CanClean = true;
            m_Target = collision;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Dirty"))
        {
            m_CanClean = false;
        }
    }

    void Update()
    {
        if (!m_IsCleaning)
        {
            if (Input.GetKey(cleanKey) && m_CanClean)
            {
                // DisablePlayerMovement()
                // ChangeSprite()
                m_IsCleaning = true;
            }
        }
        else // Cleaning
        {
            if (Input.GetKey(cleanKey))
            {
                // EnablePlayerMovement()
                // ResetSprite()
                m_IsCleaning = false;
            }

            ReadCleaningInputs();
        }
    }

    private void ReadCleaningInputs()
    {
        Cleanable cleanable = m_Target.GetComponent<Cleanable>();
        cleanable.ReceiveClean();
    }
}
