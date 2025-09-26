using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UIElements.UxmlAttributeDescription;

public class PetMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float minX = -5f;
    [SerializeField] private float maxX = 5f;
    [SerializeField] private float minMoveTime = 1f;
    [SerializeField] private float maxMoveTime = 3f;
    [SerializeField] private float pauseTime = 1f;
    [SerializeField] private float moveSpeed = 2f; // horizontal speed in units/sec

    private Rigidbody2D rb;
    private float targetX;
    private float moveTimer;
    private float moveDuration;
    private float pauseTimer;
    private int direction; // -1 = left, 1 = right
    private bool isMoving;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
        PickNewTarget();
    }

    void FixedUpdate()
    {
        if (isMoving)
        {
            moveTimer += Time.fixedDeltaTime;

            // Set horizontal velocity only; leave y velocity untouched
            rb.velocity = new Vector2(direction * moveSpeed, rb.velocity.y);

            // Check if reached or passed target x
            if ((direction > 0 && rb.position.x >= targetX) ||
                (direction < 0 && rb.position.x <= targetX) ||
                moveTimer >= moveDuration)
            {
                rb.velocity = new Vector2(0f, rb.velocity.y); // stop horizontal movement
                isMoving = false;
                pauseTimer = pauseTime;
            }
        }
        else
        {
            // Waiting / idle
            pauseTimer -= Time.fixedDeltaTime;
            if (pauseTimer <= 0f)
            {
                PickNewTarget();
            }
        }
    }

    void PickNewTarget()
    {
        float currentX = rb.position.x;
        targetX = UnityEngine.Random.Range(minX, maxX);

        direction = targetX >= currentX ? 1 : -1;

        moveDuration = UnityEngine.Random.Range(minMoveTime, maxMoveTime);
        moveTimer = 0f;
        isMoving = true;
    }
}