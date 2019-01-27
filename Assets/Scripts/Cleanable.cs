using System;
using UnityEngine;
using UnityEngine.Events;

public class Cleanable : MonoBehaviour
{
    [Serializable]
    public class CleanEvent : UnityEvent<Cleanable>
    { }

    public int startingDirtiness = 20;
    public CleanEvent OnClean;
    public CleanEvent OnFullyCleaned;

    protected int m_CurrentDirtiness;

    void Start()
    {
        m_CurrentDirtiness = startingDirtiness;
    }

    public void ReceiveClean()
    {
        m_CurrentDirtiness -= 1;
        OnClean.Invoke(this);

        if (m_CurrentDirtiness <= 0)
        {
            OnFullyCleaned.Invoke(this);
        }
    }
}