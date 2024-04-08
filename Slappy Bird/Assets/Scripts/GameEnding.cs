using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameEnding : MonoBehaviour
{
    public bool gameOver = false;

    public Button restartButton;
    public Button menuButton;

    public ChangeScene sceneManager;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
        restartButton.gameObject.SetActive(false);
        menuButton.gameObject.SetActive(false);
    }

    public void EndGame()
    {
        gameOver = true;
        player.transform.Rotate(Vector3.forward * -90);
        restartButton.gameObject.SetActive(true);
        menuButton.gameObject.SetActive(true);
    }

    public bool IsGameOver()
    {
        return gameOver;
    }

    public void ResetGame()
    {
        sceneManager.MoveToScene(1);
        restartButton.gameObject.SetActive(false);
        menuButton.gameObject.SetActive(false);
    }

    public void ReturnToMenu()
    {
        sceneManager.MoveToScene(0);
        restartButton.gameObject.SetActive(false);
        menuButton.gameObject.SetActive(false);
    }
}
