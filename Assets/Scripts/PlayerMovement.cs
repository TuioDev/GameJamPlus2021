using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D playerRB;
    [SerializeField] float playerVelocity = 5.0f;
    [SerializeField] float playerJumpForce = 0.0f;

    private Vector2 currentVelocity = Vector2.zero;
    private float smoothTime = .05f;
    private bool canJump = true;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canJump && Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    private void FixedUpdate()
    {
        Vector2 targetVelocity = new Vector2(playerVelocity, playerRB.velocity.y);
        playerRB.velocity = Vector2.SmoothDamp(playerRB.velocity, targetVelocity, ref currentVelocity, smoothTime);


    }

    void Jump()
    {
        playerRB.AddForce(Vector2.up * playerJumpForce);
    }
}
