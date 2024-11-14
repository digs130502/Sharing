using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D player;
    [SerializeField] float groundSpeed;
    float xInput;
    public bool isFacingRight = true;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        MoveWithInput();
    }

    void GetInput()
    {
        xInput = Input.GetAxis("Horizontal");
    }

    void MoveWithInput()
    {
        if (Math.Abs(xInput) > 0)
        {
            player.velocity = new Vector2(xInput * groundSpeed, player.velocity.y);

            float direction = Mathf.Sign(xInput);

            //Check if the direction has changed
            if ((direction > 0 && !isFacingRight) || (direction < 0 && isFacingRight))
            {
                FlipPlayer();
            }
            transform.localScale = new Vector3(direction, 1, 1);
        }
    }

    void FlipPlayer()
    {
        isFacingRight = !isFacingRight; // Toggle direction
    }
}
