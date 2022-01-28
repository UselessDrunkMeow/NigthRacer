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

    //text per lap
    public TextMeshProUGUI LapTime1;
    public TextMeshProUGUI LapTime2;

    public string time;

    string minutes;
    string seconds;

    // Start is called before the first frame update
    void Start()
    {
        StartTime =3;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance._GameStart)
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
    }

    public void StoreFinalTime()
    {
        FinalTime.text = minutes + ":" + seconds;
        oldFinaltime.text = "Last time" + PlayerPrefs.GetString("time", "No old time jet.");

    }

    public void StoreLap1()
    {
        LapTime1.text = minutes + ":" + seconds;
    }
    public void StoreLap2()
    {
        LapTime2.text = minutes + ":" + seconds;
    }

    public void Mainmenu()
    {
        PlayerPrefs.SetString("time", FinalTime.text);
        // oldFinaltime.text =  "Last time" + PlayerPrefs.SetString("time", FinalTime.text);
        SceneManager.LoadScene(0);
    }


}



