using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class timertext : MonoBehaviour
{

    public Text text;
    public TextMeshProUGUI FinalTime;
    public TextMeshProUGUI oldFinaltime;

    private float StartTime;
    private bool finished;
    

    public TextMeshProUGUI LapTime1;
    public TextMeshProUGUI LapTime2;
    public TextMeshProUGUI LapTime3;

    public string time;

    string minutes;
    string seconds;

    // Start is called before the first frame update
    void Start()
    {
        StartTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        time = FinalTime.text;
        
        if (finished)
            return;
        else
        {

            float t = Time.time - StartTime;

             minutes = ((int)t / 60).ToString();
             seconds = (t % 60).ToString("f2");
            text.text = minutes + ":" + seconds;
        }
    }  

    public void StoreFinalTime()
    {
        FinalTime.text = minutes + ":" + seconds;
        
    }

    public void StoreLap1()
    {
        LapTime1.text = minutes + ":" + seconds;
    }
    public void StoreLap2()
    {
        LapTime2.text = minutes + ":" + seconds;
    }
    public void StoreLap3()
    {
        LapTime3.text = minutes + ":" + seconds;
    }
    public void Mainmenu()
    {
        oldFinaltime.text =  "Last time" + PlayerPrefs.GetString("time");
        SceneManager.LoadScene(0);
    }


}



