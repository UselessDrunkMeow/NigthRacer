using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    public static GameManager Instance { get { return _instance; } }

    [Header("Lap Info")]
    public CarMovement _Car;


    public int _CurrentLap;    
    public float _RaceTime;
    public float _Lap1Time;
    public float _Lap2Time; 
    public float _Lap3Time;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }
    private void Start()
    {
        _Car = FindObjectOfType<CarMovement>();
        StartCoroutine(StartTimer());
        _Car._rb.isKinematic = true;
    }

    private void Update()
    {
        LapTimer();
    }

    public void NextLap()
    {
        _CurrentLap =+ 1;
    }

    public IEnumerator StartTimer()
    {
        print("aa");
        yield return new WaitForSeconds(3f);
        _Car._rb.isKinematic = false;
        print("aa");

    }

    public void LapTimer()
    {
        _RaceTime = + Time.deltaTime;
        switch (_CurrentLap)
        {
            case 1:
                _Lap1Time =+ Time.deltaTime;
                break;
            case 2:
                _Lap2Time = +Time.deltaTime;
                break;
            case 3:
                _Lap3Time = +Time.deltaTime;
                break;
        }
    }

}
