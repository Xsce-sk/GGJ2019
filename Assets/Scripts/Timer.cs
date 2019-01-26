using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    private TextMeshProUGUI time;

    public float countdown = 300f;

    // Start is called before the first frame update
    void Start()
    {
        time = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;

        int minutes = (int) (countdown % 3600 / 60);
        int seconds = (int) (countdown % 3600 % 60);

        if (seconds > 9)
            time.text = minutes + ":" + seconds;
        else
            time.text = minutes + ":" + "0" + seconds;
    }
}
