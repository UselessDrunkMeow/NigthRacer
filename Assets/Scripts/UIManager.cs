using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance;
    public static UIManager Instance { get { return _instance; } }

    public CarMovement _Car;
    public float _Speed;

    public int _StartTime;
    public TextMeshProUGUI _GoText;

    public Slider _SpeedMeter;
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
        StartCoroutine(StartTimer());
        _Car = FindObjectOfType<CarMovement>();
    }
    private void Update()
    {
        _Speed = _Car._Speed;
        _SpeedMeter.value = _Speed;
    }

    public IEnumerator StartTimer()
    {
        _StartTime = 3;
        _GoText.text = _StartTime.ToString();
        yield return new WaitForSeconds(1f);
        _StartTime = 2;
        _GoText.text = _StartTime.ToString();
        yield return new WaitForSeconds(1f);
        _StartTime = 1;
        _GoText.text = _StartTime.ToString();
        yield return new WaitForSeconds(1f);
        _StartTime = 0;
        _GoText.text = "GO!";
        yield return new WaitForSeconds(1f);
        _GoText.text = "";
    }
}
