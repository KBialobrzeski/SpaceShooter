using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HighScoresText : MonoBehaviour
{

    public Text highScoresText;
    int[] highScoresArray = new int[10];

    void Start()
    {

        highScoresArray = PlayerPrefsX.GetIntArray("HighScoreArray");

        if (highScoresArray[0] == 0)
        {
            highScoresText.text = "No Scores!";
        }
        else
        {
            highScoresText.text = "";
            for (int i = 0; i< highScoresArray.Length; i++)
            {
                highScoresText.text += (i + 1) + ". " + highScoresArray[i] + " p." + System.Environment.NewLine;
            }
        }

    }

}
