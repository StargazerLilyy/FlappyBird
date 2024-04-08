using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    // Start() and Update() methods deleted - we don't need them right now

    public static MainManager Instance;
    public int highScore;

    public TextMeshProUGUI highScoreText;

    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        highScoreText.text = "High Score: " + PlayerPrefs.GetInt("HighScore", MainManager.Instance.highScore).ToString(); ;
    }
}