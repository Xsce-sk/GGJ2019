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
    protected LoadScene m_LoadScene;

    void Start()
    {
        m_Transform = transform;
        m_Camera = GetComponent<Camera>();
        m_LoadScene = GetComponent<LoadScene>();

        m_Transform.position = new Vector3(-47.31f, 5.35f, -10f);
        m_Camera.orthographicSize = 2.8f;

        StartCoroutine("AnimationSequence");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) ||
            Input.GetKeyDown(KeyCode.A) ||
            Input.GetKeyDown(KeyCode.S) ||
            Input.GetKeyDown(KeyCode.D) ||
            Input.GetKeyDown(KeyCode.LeftBracket) ||
            Input.GetKeyDown(KeyCode.RightBracket))
        {
            m_LoadScene.LoadSceneIndex(2); // 2
        }
    }

    IEnumerator AnimationSequence()
    {
        m_NextPos = new Vector3(-37.94f, 5.35f, -10f);
        m_NextSize = 2.8f;
        m_CurrentDuration = 3f;
        StartCoroutine("MoveTo");
        yield return new WaitForSeconds(m_CurrentDuration);
        yield return new WaitForSeconds(1f);

        m_NextPos = new Vector3(-37.94f, -4.44f, -10f);
        m_NextSize = 2.8f;
        m_CurrentDuration = 2f;
        StartCoroutine("MoveTo");
        yield return new WaitForSeconds(m_CurrentDuration);
        yield return new WaitForSeconds(1f);

        m_NextPos = new Vector3(-25.1f, -2.77f, -10f);
        m_NextSize = 5f;
        m_CurrentDuration = 1f;
        StartCoroutine("MoveTo");
        yield return new WaitForSeconds(m_CurrentDuration);

        m_NextPos = new Vector3(3.2f, -2.77f, -10f);
        m_NextSize = 5f;
        m_CurrentDuration = 8f;
        StartCoroutine("MoveTo");
        yield return new WaitForSeconds(m_CurrentDuration);

        m_NextPos = new Vector3(17.3f, 0, -10f);
        m_NextSize = 8f;
        m_CurrentDuration = 3f;
        StartCoroutine("MoveTo");
        yield return new WaitForSeconds(m_CurrentDuration);
        yield return new WaitForSeconds(3f);

        m_NextPos = new Vector3(36.4f, 0, -10f);
        m_NextSize = 8f;
        m_CurrentDuration = 0.5f;
        StartCoroutine("MoveTo");
        yield return new WaitForSeconds(m_CurrentDuration);
        yield return new WaitForSeconds(2f);

        m_NextPos = new Vector3(64.4f, 0, -10f);
        m_NextSize = 8f;
        m_CurrentDuration = 5f;
        StartCoroutine("MoveTo");
        yield return new WaitForSeconds(m_CurrentDuration);
        yield return new WaitForSeconds(4f);

        m_NextPos = new Vector3(83.2f, 0.7f, -10f);
        m_NextSize = 8f;
        m_CurrentDuration = 1f;
        StartCoroutine("MoveTo");
        yield return new WaitForSeconds(m_CurrentDuration);
        yield return new WaitForSeconds(4f);

        m_NextPos = new Vector3(83.2f, -12.4f, -10f);
        m_NextSize = 6f;
        m_CurrentDuration = 1f;
        StartCoroutine("MoveTo");
        yield return new WaitForSeconds(m_CurrentDuration);
        yield return new WaitForSeconds(1f);

        m_NextPos = new Vector3(63.5f, -13.9f, -10f);
        m_NextSize = 6f;
        m_CurrentDuration = 1f;
        StartCoroutine("MoveTo");
        yield return new WaitForSeconds(m_CurrentDuration);
        yield return new WaitForSeconds(4f);

        m_NextPos = new Vector3(63.5f, -25.5f, -10f);
        m_NextSize = 6f;
        m_CurrentDuration = 1f;
        StartCoroutine("MoveTo");
        yield return new WaitForSeconds(m_CurrentDuration);

        m_NextPos = new Vector3(71.1f, -25.5f, -10f);
        m_NextSize = 6f;
        m_CurrentDuration = 3f;
        StartCoroutine("MoveTo");
        yield return new WaitForSeconds(m_CurrentDuration);
        yield return new WaitForSeconds(1f);

        m_NextPos = new Vector3(89.2f, -23.5f, -10f);
        m_NextSize = 6f;
        m_CurrentDuration = 1f;
        StartCoroutine("MoveTo");
        yield return new WaitForSeconds(m_CurrentDuration);
        yield return new WaitForSeconds(4f);

        m_NextPos = new Vector3(105.5f, -23.5f, -10f);
        m_NextSize = 6f;
        m_CurrentDuration = 1f;
        StartCoroutine("MoveTo");
        yield return new WaitForSeconds(m_CurrentDuration);

        m_LoadScene.LoadSceneIndex(2); // 2
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
