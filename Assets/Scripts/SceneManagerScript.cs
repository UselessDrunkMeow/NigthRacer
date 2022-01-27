using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    public void MainMenu()//loads the main menu
    {
        SceneManager.LoadScene("Main Menu", LoadSceneMode.Additive);
    }
    public void StartGame()//loads the game scene
    {
        SceneManager.LoadScene("Game Scene");
    }
    public void ChangeScene(string scene)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(scene);

    }
}
