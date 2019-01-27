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
    protected GameObject m_Player;

    public void StopPlayerCleaning()
    {
        m_Player.GetComponent<Cleaner>().StopCleaning();
    }

    void Start()
    {
        m_Player = GameObject.FindGameObjectWithTag("Player");
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

            GameObject child = gameObject.transform.GetChild(i).gameObject;

            if (child.CompareTag("Dirt"))
            {
                if (m_Alpha == 0)
                {
                    Destroy(child);
                }
                child.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, m_Alpha);
            }
            else if (child.CompareTag("DirtObject"))
            {
                if (m_Alpha == 0)
                {
                    Destroy(child);
                }
            }
            else
            {
                if (m_Alpha == 0)
                {
                    child.SetActive(true);
                }
            }
        }
    }
}