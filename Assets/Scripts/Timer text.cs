using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timertext : MonoBehaviour
{

    public Text text;
    private float StartTime;
    private bool finished;
    // Start is called before the first frame update
    void Start()
    {
        StartTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (finished)
            return;
        else
        {


            float t = Time.time - StartTime;

            string minutes = ((int)t / 60).ToString();
            string seconds = (t % 60).ToString("f2");
            text.text = minutes + ":" + seconds;
        }
    }
}
