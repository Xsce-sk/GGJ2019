using System;
using UnityEngine;
using UnityEngine.Events;

public class Cleanable : MonoBehaviour
{
    [Serializable]
    public class CleanEvent : UnityEvent<Cleanable>
    { }

    public int startingDirtiness = 20;
    public int worth = 500;
    public GameObject CleanTextPrefab;
    public GameObject FinishTextPrefab;
    public CleanEvent OnClean;
    public CleanEvent OnFullyCleaned;

    protected int m_CurrentDirtiness;
    protected float m_Alpha;

    void Start()
    {
        m_CurrentDirtiness = startingDirtiness;
    }

    public void ReceiveClean()
    {
        m_CurrentDirtiness -= 1;

        if (m_CurrentDirtiness <= 0)
        {
            OnFullyCleaned.Invoke(this);
            Instantiate(FinishTextPrefab, transform.position, Quaternion.identity);
            Score.scoreTracker += worth;
        }
        else
        {
            OnClean.Invoke(this);
            Instantiate(CleanTextPrefab, transform.position, Quaternion.identity);
            Score.scoreTracker += 100;
        }

        UpdateDirt();
    }

    void UpdateDirt()
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            m_Alpha = (float)m_CurrentDirtiness / startingDirtiness;
            
            GameObject dirt = gameObject.transform.GetChild(i).gameObject;

            print(m_Alpha);
            if (m_Alpha == 0)
            {
                Destroy(dirt);
            }
            dirt.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, m_Alpha);
        }
    }
}