using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public CarMovement _Car;
    public float _Speed;

    public Slider _SpeedMeter;

    private void Start()
    {
        _Car = FindObjectOfType<CarMovement>();
    }
    private void Update()
    {
        _Speed = _Car._Speed;
        _SpeedMeter.value = _Speed;
    }
}
