using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class ScoreText : MonoBehaviour
{
    [System.Serializable]
    public class ScoreTextEvent : UnityEvent<ScoreText>
    { }

    public float duration = 0.5f;
    public float height = 0.5f;
    public float offsetAmount = 0.1f;
    public Color startColor;
    public Color endColor;
    public ScoreTextEvent OnCreation;

    protected TextMeshProUGUI m_TextMeshProUGUI;
    protected RectTransform m_RectTransform;
    protected Camera m_MainCamera;


    public void SmallScreenShake()
    {
        m_MainCamera.GetComponent<ScreenEffects>().StartShake();
    }

    public void LargeScreenShake()
    {
        m_MainCamera.GetComponent<ScreenEffects>().StartLargeShake();
    }

    void Start()
    {
        m_RectTransform = GetComponent<RectTransform>();
        m_TextMeshProUGUI = GetComponentInChildren<TextMeshProUGUI>();
        m_MainCamera = Camera.main;
        Offset();
        StartCoroutine("Animation");
        OnCreation.Invoke(this);
    }

    void Offset()
    {
        Vector3 initialPos = m_RectTransform.position;
        Vector3 offset = new Vector3(Random.Range(-offsetAmount, offsetAmount), Random.Range(-offsetAmount, offsetAmount), 0f);
        transform.position = new Vector3(initialPos.x + offset.x, initialPos.y + offset.y, initialPos.z);
    }

    IEnumerator Animation()
    {
        StartCoroutine("MoveTo");
        StartCoroutine("ColorTo");
        yield return new WaitForSeconds(duration);
        Destroy(gameObject);
    }

    IEnumerator MoveTo()
    {
        Vector3 initialPos = m_RectTransform.position;
        Vector3 targetPos = new Vector3(initialPos.x, initialPos.y + height, initialPos.z);
        float t = 0;
        while (t <= 1)
        {
            t += Time.deltaTime;
            m_RectTransform.position = Vector3.Lerp(initialPos, targetPos, t);
            yield return new WaitForFixedUpdate();
        }
        m_RectTransform.position = targetPos;
    }

    IEnumerator ColorTo()
    {
        float t = 0;
        Color currentColor = startColor;
        while (t <= duration)
        {
            t += Time.deltaTime;
            m_TextMeshProUGUI.color = Color.Lerp(currentColor, endColor, t);
            yield return new WaitForFixedUpdate();
        }
        m_TextMeshProUGUI.color = endColor;
    }
}
