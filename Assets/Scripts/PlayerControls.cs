using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public int speed = 2;
    private float accumulatedTime = 0;
    private float frameDuration = 0.1f;
    private SpriteRenderer spriteRenderer;
    private Vector2 lastDirection = Vector2.up;
    private bool hasMoved = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float deltaTime = Time.deltaTime;
        HandleMovement(deltaTime);
    }

    private void HandleMovement(float deltaTime)
    {
        Vector2 movement = Vector2.zero;

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            movement.y += 1;
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            movement.y -= 1;
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            movement.x -= 1;
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            movement.x += 1;

        if (movement.sqrMagnitude > 0)
        {
            movement.Normalize();
            transform.position += new Vector3(movement.x, movement.y, 0) * speed * deltaTime;
            lastDirection = movement;
            hasMoved = true;
        }

    }
}
