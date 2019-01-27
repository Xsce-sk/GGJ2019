using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioBounce : MonoBehaviour
{
    public float updateStep = 0.1f;
    public int sampleDataLength = 1024;

    protected Transform m_Transform;
    protected AudioSource m_AudioSource;
    protected int m_GrowFactor;

    protected float m_CurrentUpdateTime = 0f;
    private float m_ClipLoudness;
    private float[] m_ClipSampleData;

    void Start()
    {
        m_Transform = transform;
        m_AudioSource = GetComponent<AudioSource>();
        m_ClipSampleData = new float[sampleDataLength];
        m_GrowFactor = 1;
    }

    void Update()
    {
        GetClipLoudness();
        m_Transform.transform.localScale = new Vector3(1f + m_ClipLoudness, 1f + m_ClipLoudness, m_Transform.transform.localScale.z);
    }

    void GetClipLoudness()
    {
        m_CurrentUpdateTime += Time.deltaTime;
        if (m_CurrentUpdateTime >= updateStep)
        {
            m_CurrentUpdateTime = 0f;
            m_AudioSource.clip.GetData(m_ClipSampleData, m_AudioSource.timeSamples); //I read 1024 samples, which is about 80 ms on a 44khz stereo clip, beginning at the current sample position of the clip.
            m_ClipLoudness = 0f;
            foreach (var sample in m_ClipSampleData)
            {
                m_ClipLoudness += Mathf.Abs(sample);
            }
            m_ClipLoudness /= sampleDataLength; //clipLoudness is what you are looking for
        }
    }
}
