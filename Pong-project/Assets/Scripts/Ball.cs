using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public float maxInitialAngle = 0.67f;
    public float moveSpeed = 0.02f;
    public float maxStartY = 4f;
    public float speedMultiplier = 1.1f;

    private float startX = 1f;
    private Vector2 dir;

    private void Start()
    {
        GameManager.instance.onReset += ResetBall;
        GameManager.instance.gameUI.onStartGame += ResetBall;
    }

    private void ResetBall()
    {
        ResetBallPosition();
        InitialPush();
        moveSpeed = 0.02f;
    }

    private void InitialPush()
    {
        dir = Random.value < 0.5f ? Vector2.left : Vector2.right;

        dir.y = Random.Range(-maxInitialAngle, maxInitialAngle);
    }

    private void Update()
    {
        transform.Translate(dir * moveSpeed);
    }

    private void ResetBallPosition()
    {
        float posY = Random.Range(-maxStartY, maxStartY);
        Vector2 position = new Vector2(startX, posY);
        transform.position = position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ScoreZone scoreZone = collision.GetComponent<ScoreZone>();
        if (scoreZone != null)
        {
            GameManager.instance.OnScoreZoneReached(scoreZone.id);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Paddle paddle = collision.collider.GetComponent<Paddle>();
        Vector2 reflectionDir = Vector2.Reflect(dir, collision.contacts[0].normal);
        dir = reflectionDir;

        if (paddle)
        {
            moveSpeed *= speedMultiplier;
        }
    }
}