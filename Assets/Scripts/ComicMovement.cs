using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComicMovement : MonoBehaviour
{
    protected Transform m_Transform;
    protected Camera m_Camera;
    protected Vector3 m_NextPos;
    protected float m_NextSize;
    protected float m_CurrentDuration;

    void Start()
    {
        m_Transform = transform;
        m_Camera = GetComponent<Camera>();

        m_Transform.position = new Vector3(-47.31f, 5.35f, -10f);
        m_Camera.orthographicSize = 2.8f;

        StartCoroutine("AnimationSequence");
    }

    IEnumerator AnimationSequence()
    {
        m_NextPos = new Vector3(-37.94f, 5.35f, -10f);
        m_NextSize = 2.8f;
        m_CurrentDuration = 3f;
        print("starting animation");

        StartCoroutine("MoveTo");

        yield return new WaitForSeconds(5f);
    }

    IEnumerator MoveTo()
    {
        float t = 0f;
        Vector3 startPos = m_Transform.position;
        float startSize = m_Camera.orthographicSize;
        while (t < m_CurrentDuration)
        {
            m_Transform.position = Vector3.Lerp(startPos, m_NextPos, t / m_CurrentDuration);
            m_Camera.orthographicSize = Mathf.Lerp(startSize, m_NextSize, t / m_CurrentDuration);
            t += Time.deltaTime;
            
            yield return null;
        }
    }
}
