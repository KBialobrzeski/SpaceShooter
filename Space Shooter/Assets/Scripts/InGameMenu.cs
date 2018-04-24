using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InGameMenu : MonoBehaviour
{

    public GameObject pause;
    public GameObject optionsInGame;
    public GameObject optionsGameOver;
    public GameObject gameOver;
    public GameObject highscoresInGame;
    public GameObject highscoresGameOver;
    private static float time;

    void Start()
    {
        time = 1;
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Escape))
        {

            if (Time.timeScale != 0)
            {
                time = Time.timeScale;
            }
            PauseGame();
        }

    }

    void PauseGame()
    {
        
        pause.SetActive(!pause.activeInHierarchy);

        if (Time.timeScale != 0)
        {
            Time.timeScale = 0;
            Cursor.visible = true;
        }
        else {
            Time.timeScale = time;
            Cursor.visible = false;
        }
    }

    public void PlayAgainButton()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitButton()
    {
        SceneManager.LoadScene(0);
    }

    public void ReturnButton()
    {
        PauseGame();
    }

    public void OptionsInPauseButton()
    {
        pause.SetActive(!pause.activeInHierarchy);
        optionsInGame.SetActive(!optionsInGame.activeInHierarchy);
    }

    public void OptionsInGameOverButton()
    {
        gameOver.SetActive(!gameOver.activeInHierarchy);
        optionsGameOver.SetActive(!optionsGameOver.activeInHierarchy);
    }

    public void ApplyButtonInGame()
    {
        pause.SetActive(!pause.activeInHierarchy);
        optionsInGame.SetActive(!optionsInGame.activeInHierarchy);
    }

    public void ApplyButtonGameOver()
    {
        gameOver.SetActive(!gameOver.activeInHierarchy);
        optionsGameOver.SetActive(!optionsGameOver.activeInHierarchy);
    }

    public void HighscoresInGame()
    {
        pause.SetActive(!pause.activeInHierarchy);
        highscoresInGame.SetActive(!highscoresInGame.activeInHierarchy);
    }

    public void HighscoresGameOver()
    {
        gameOver.SetActive(!gameOver.activeInHierarchy);
        highscoresGameOver.SetActive(!highscoresGameOver.activeInHierarchy);
    }



}
