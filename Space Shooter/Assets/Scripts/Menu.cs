using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    public GameObject pause;
    public GameObject menu;
    public GameObject highscores;

    void Start()
    {
        if(PlayerPrefsX.GetIntArray("HighScoreArray", 0, 10)[0] == 0)
        {
            int[] highScoresInitializationArray = new int[10] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            PlayerPrefsX.SetIntArray("HighScoreArray", highScoresInitializationArray);
        }

        Time.timeScale = 1;
    }

    public void NewGameButton()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitButton()
    {
        Application.Quit();
    }

    public void OptionsButton()
    {
        pause.SetActive(!pause.activeInHierarchy);
        menu.SetActive(!menu.activeInHierarchy);
    }

    public void HighscoresButton()
    {
        pause.SetActive(!pause.activeInHierarchy);
        highscores.SetActive(!highscores.activeInHierarchy);
    }

    public void BackButton()
    {
        pause.SetActive(!pause.activeInHierarchy);
        highscores.SetActive(!highscores.activeInHierarchy);
    }
}
