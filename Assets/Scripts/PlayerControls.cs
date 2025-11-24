using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public float speed = 10f;
    private float accumulatedTime = 0;
    private float frameDuration = 0.1f;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;
    private Vector2 lastDirection = Vector2.up;
    private bool hasMoved = false;
    void Start()
    {
       rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float deltaTime = Time.fixedDeltaTime;

        HandleMovement(deltaTime);
    }

    private void HandleMovement(float deltaTime)
    {
        Vector2 movement = new Vector2(
            Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical")
        ).normalized;
        rb.MovePosition(rb.position + movement * speed * deltaTime);
        lastDirection = movement;
        hasMoved = true;

    }
}
