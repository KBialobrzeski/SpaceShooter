using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGamePoints : MonoBehaviour {

    private int[] highScoresArray = new int[10];
    private int score;

    void Start () {

        this.gameObject.GetComponent<Text>().text = Points.points.ToString();

        highScoresArray = PlayerPrefsX.GetIntArray("HighScoreArray");
        score = Points.points;

        if(score > highScoresArray[9])
        {
            for(int i = 0; i < highScoresArray.Length; i++)
            {
                if(score > highScoresArray[i])
                {
                    for(int j = highScoresArray.Length - 1; j > i; j--)
                    {
                        highScoresArray[j] = highScoresArray[j - 1];
                    }
                    highScoresArray[i] = score;
                    break;
                }
            }
        }

        PlayerPrefsX.SetIntArray("HighScoreArray", highScoresArray);

    }
	
}
