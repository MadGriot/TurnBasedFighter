using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public float speed = 2f;
    private Rigidbody2D rb;


    public GameObject RightDirection;
    public GameObject LeftDirection;
    public GameObject UpDirection;
    public GameObject DownDirection;
    public Animator playerAnimation;
    List<GameObject> Direcitons;
    void Start()
    {
       rb = GetComponent<Rigidbody2D>();
        Direcitons = new List<GameObject>()
        {
            RightDirection, LeftDirection, UpDirection, DownDirection
        };
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

        //Right
        if (movement.x > 0)
        {
            SetDirection(RightDirection);
            playerAnimation.Play("WalkRight");
        }

        //Left
        if (movement.x < 0)
        {
            SetDirection(LeftDirection);
            playerAnimation.Play("WalkLeft");
        }

        //Up
        if (movement.y > 0)
        {
            SetDirection(UpDirection);
            playerAnimation.Play("WalkUp");
        }

        //Down
        if (movement.y < 0)
        {
            SetDirection(DownDirection);
            playerAnimation.Play("WalkDown");
        }

        if (movement.y == 0 && movement.x == 0)
        {
            playerAnimation.Play("PlayerIdle");
        }
    }

    private void SetDirection(GameObject direction)
    {
        direction.SetActive(true);
        foreach (GameObject currentdirection in Direcitons)
        {
            if (currentdirection != direction)
            {
                currentdirection.SetActive(false); 
            }
        }
    }
}
