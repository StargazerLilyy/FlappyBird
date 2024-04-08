using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
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
    }
}
