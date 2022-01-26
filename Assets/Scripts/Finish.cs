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
        
    }
    public void Update()
    {
        Currentlap.text = laps + "/3";
    }
}
