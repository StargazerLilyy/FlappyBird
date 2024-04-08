using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Security.Cryptography;

public class PlayerBehavior : MonoBehaviour
{
    public float flapSpeed;
    public GameEnding gameStatus;
    public Collider2D botBorder;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !gameStatus.IsGameOver())
        {
            FlapWings();
        }
    }

    void FlapWings()
    {
        rb.velocity = new Vector2(0, flapSpeed);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        gameStatus.EndGame();
        if (botBorder != collision.collider)
        {
            IgnorePlayerPipeCollision(collision);
        }

    }

    void IgnorePlayerPipeCollision(Collision2D collision)
    {
        Collider2D[] results = new Collider2D[1];
        rb.GetAttachedColliders(results);
        Physics2D.IgnoreCollision(results[0], collision.collider);
    }
}
