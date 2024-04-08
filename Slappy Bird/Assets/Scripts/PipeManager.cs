using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEditor;
using UnityEngine;

public class PipeManager : MonoBehaviour
{
    public float pipeVelocity;
    public Rigidbody2D pipePrefab;
    public GameEnding gameEnding;
    public ScoreManager scoreManager;
    private System.Random rnd;
    private static int numPipes = 3;
    private Rigidbody2D[] pipes = new Rigidbody2D[numPipes];
    private int nextToReset;
    private int nextToScore;

    // Start is called before the first frame update
    void Start()
    {
        rnd = new System.Random();

        for (var i = 0; i < 3; i++)
        {
            pipes[i] = Instantiate(pipePrefab, new Vector3((i * 7) + 4, 0, 0), Quaternion.identity);
            pipes[i].velocity = new Vector2(-1 * pipeVelocity, 0);
        }
        nextToReset = 0;
        nextToScore = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if (gameEnding.IsGameOver())
        {
            for (var i = 0; i < 3; i++)
            {
                pipes[i].velocity = new Vector2(0 * pipeVelocity, 0);
            }
        }
        else if (pipes[nextToScore].position.x < -6)
        {
            PlayerScored();
        }
        else if (pipes[nextToReset].position.x < -10.5)
        {
            ResetPipe();

        }
    }

    private void ResetPipe()
    {
        float YPos = ((float)rnd.Next(-300, 300)) / 100;
        pipes[nextToReset].MovePosition(new Vector2(10.5f, YPos));
        nextToReset = (nextToReset + 1) % numPipes;
    }

    private void PlayerScored()
    {
        scoreManager.IncreaseScore();
        nextToScore = (nextToScore + 1) % numPipes;
    }
}
