using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : SingletonBase<GameManager>
{
    [SerializeField] private Text scoreText, recordTxt;
    [SerializeField] private int score = 0;
    [SerializeField] private int record = 0;
    private void Start()
    {
        record = PlayerPrefs.GetInt("Record");
        recordTxt.text = "Record: " + record.ToString();
        scoreText.text = "Score: " + score.ToString();
    }
    public void ScoreAdd()
    {
        score += 1;
        scoreText.text = "Score: " + score.ToString();
        if(record < score)
        {
            PlayerPrefs.SetInt("Record", score);
            recordTxt.text = "Record: " + record.ToString();
        }
    }
}
