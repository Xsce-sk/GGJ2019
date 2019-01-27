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
    public GameObject ScoreTextPrefab;
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

        GameObject instantiatedScore = Instantiate(ScoreTextPrefab) as GameObject;
        ScoreText scoreScript = instantiatedScore.GetComponent<ScoreText>();

        if (m_CurrentDirtiness <= 0)
        {
            OnFullyCleaned.Invoke(this);
            scoreScript.SetScore(worth);
        }
        else
        {
            OnClean.Invoke(this);
            scoreScript.SetScore(100);
        }
    }
}