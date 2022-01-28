using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject _MainScreen;
    public GameObject _OptionsScreen;
    public GameObject _CreditsScreen;
    void Start()
    {
        _MainScreen.SetActive(true);
        _OptionsScreen.SetActive(false);
        _CreditsScreen.SetActive(false); 
    }

    public void MainScreen()
    {
        _MainScreen.SetActive(true);
        _OptionsScreen.SetActive(false);
        _CreditsScreen.SetActive(false);
    }
    public void OptionsScreen()
    {
        _MainScreen.SetActive(false);
        _OptionsScreen.SetActive(true);
        _CreditsScreen.SetActive(false);
    }
    public void CreditsScreen()
    {
        _MainScreen.SetActive(false);
        _OptionsScreen.SetActive(false);
        _CreditsScreen.SetActive(true);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
