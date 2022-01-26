using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    public GameObject raceEnd;
    public int laps = 0;

    private void Start()
    {
        laps = 0;
    }
    private void OnTriggerEnter(Collider other)
    {      
        if(laps > 2)
            raceEnd.SetActive(true);
        laps++;
    }
}
