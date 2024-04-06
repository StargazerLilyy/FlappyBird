using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class PipeManager : MonoBehaviour
{
    public Rigidbody2D pipePrefab;
    private static int numPipes = 3;
    private Rigidbody2D[] pipes = new Rigidbody2D[numPipes];
    private int nextToReset;

    // Start is called before the first frame update
    void Start()
    {
        for (var i = 0; i < 3; i++)
        {
            pipes[i] = Instantiate(pipePrefab, new Vector3(i * 7, 0, 0), Quaternion.identity);
            pipes[i].velocity = new Vector2(-2, 0);
        }
        nextToReset = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if (pipes[nextToReset].position.x < -10.5)
        {
            pipes[nextToReset].MovePosition(new Vector3(10.5f, 0, 0));
            nextToReset = (nextToReset + 1) % numPipes;
        }
    }
}
