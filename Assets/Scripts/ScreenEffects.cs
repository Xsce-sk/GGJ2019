using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenEffects : MonoBehaviour
{
    [Header("Screen Shake Settings")]
    public float duration = 0.25f;
    public float delay = 0.05f;
    public float shakeAmount = 0.3f;

    protected Transform m_Transform;

    public void StartShake()
    {
        StartCoroutine("Shake");
    }

    void Start()
    {
        m_Transform = transform;
    }

    public IEnumerator Shake()
    {
        print("Shaking Screen");
        float t = duration;
        Vector3 startPos = m_Transform.position;
        Vector3 newPos = Vector3.zero;
        float xOffset = 0f;
        float yOffset = 0f;
        while (t >= 0)

        {
            xOffset = Random.Range(-shakeAmount, shakeAmount);
            yOffset = Random.Range(-shakeAmount, shakeAmount);
            newPos = new Vector3(startPos.x + xOffset, startPos.y + yOffset, startPos.z);
            m_Transform.position = newPos;

            yield return new WaitForSeconds(delay);
            t -= Time.deltaTime;
        }

        m_Transform.position = startPos;
    }
}
