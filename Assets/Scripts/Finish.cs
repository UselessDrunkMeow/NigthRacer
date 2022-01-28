using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Finish : MonoBehaviour
{
    public timertext timer;
    public GameObject raceEnd;
    public int laps = 0;
    public TextMeshProUGUI Currentlap;


    private void Start()
    {
        laps = 1;
    }
    private void OnTriggerEnter(Collider other)
    {
        laps++;
        if (laps > 3)
        {
            raceEnd.SetActive(true);
            timer.StoreFinalTime();
            
        }
        if(laps == 2)
        {
            timer.StoreLap1();
        }
        if (laps == 3)
        {
            timer.StoreLap2();

        }

    }
    public void Update()
    {

        if (laps < 4)
        {
            Currentlap.text = laps + "/3";
        }
        else
            Currentlap.text = "";
    }
}
