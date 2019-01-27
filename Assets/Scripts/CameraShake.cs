using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public Transform camTransform;
    public Cleaner m_cleaner;
    public float shakiness;
    public float shakeTime;
    // Start is called before the first frame update
    void Start()
    {
        camTransform = GetComponent<Transform>();
        m_cleaner = GameObject.Find("Player_Sprite").GetComponent<Cleaner>();
    }

    // Update is called once per frame
    void Update()
    {
        

        if(m_cleaner.isCleaning && 
          (Input.GetKeyDown(KeyCode.W) ||
          Input.GetKeyDown(KeyCode.A) ||
          Input.GetKeyDown(KeyCode.S) ||
          Input.GetKeyDown(KeyCode.D)))
        {
            StartCoroutine("ShakeCamera");
        }
    }

    IEnumerator ShakeCamera()
    {
        Vector3 startPos = camTransform.localPosition;
        camTransform.localPosition = startPos + Random.insideUnitSphere * shakiness;
        yield return new WaitForSeconds(shakeTime);
        camTransform.localPosition = startPos;
    }
}
