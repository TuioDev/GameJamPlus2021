using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D playerRB;
    [SerializeField] private float playerVelocity = 5.0f;
    [SerializeField] private float playerJumpForce = 0.0f;
    [SerializeField] private Transform groundCheckLeft;
    [SerializeField] EventManager eventManager;
    [SerializeField] private Sprite[] playerSprites;
    [SerializeField] private SpriteRenderer currentSprite;
    private GameColors playerColor;

    //private Vector2 currentVelocity = Vector2.zero;
    //private float smoothTime = .05f;
    private bool grounded = false;
    private bool jump = false;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        playerColor = GameColors.Blank;
        eventManager.PlayerColorChange += ChangeColor;
    }

    // Update is called once per frame
    void Update()
    {
        grounded = Physics2D.Linecast(transform.position, groundCheckLeft.position, 1 << LayerMask.NameToLayer("Level"));
        CanJump();

    }

    private void FixedUpdate()
    {
        //Vector2 targetVelocity = new Vector2(playerVelocity, playerRB.velocity.y);
        //playerRB.velocity = Vector2.SmoothDamp(playerRB.velocity, targetVelocity, ref currentVelocity, smoothTime);
        playerRB.velocity = new Vector2(playerVelocity, playerRB.velocity.y);
        if (jump)
        {
            playerRB.AddForce(Vector2.up * playerJumpForce);
            jump = false;
        }

    }

    void CanJump()
    {
        if (grounded && Input.GetKeyDown(KeyCode.Space))
        {
            jump = true;
        }
    }

    void ChangeColor(GameColors orbColor)
    {
        playerColor = orbColor;
        switch (playerColor)
        {
            case GameColors.Blank:
                playerVelocity = 5.0f;
                playerJumpForce = 800.0f;
                currentSprite.sprite = playerSprites[0];
                break;
            case GameColors.Yellow:
                playerVelocity = 7.0f;
                playerJumpForce = 800.0f;
                currentSprite.sprite = playerSprites[1];
                break;
            case GameColors.Red:
                playerVelocity = 5.0f;
                playerJumpForce = 1200.0f;
                currentSprite.sprite = playerSprites[2];
                break;
            default:
                playerColor = GameColors.Blank;
                break;
        }
    }

}
