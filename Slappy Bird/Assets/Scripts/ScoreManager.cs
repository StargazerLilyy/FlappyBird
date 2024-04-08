using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public GameObject scoreSFX;
    public TextMeshProUGUI playerScoreText;
    private int curScore;
    // Start is called before the first frame update
    void Start()
    {
        curScore = 0;
        playerScoreText.text = "0";
    }

    public void IncreaseScore()
    {
        curScore = curScore + 1;
        playerScoreText.text = curScore.ToString();

        Instantiate(scoreSFX, transform.position, transform.rotation);
    }

    public void CheckHighScore()
    {
        if (MainManager.Instance != null && MainManager.Instance.highScore < curScore)
        {
            MainManager.Instance.highScore = curScore;
            PlayerPrefs.SetInt("HighScore", curScore);
            PlayerPrefs.Save();
        }
    }

    public int GetCurScore()
    {
        return curScore;
    }
}
