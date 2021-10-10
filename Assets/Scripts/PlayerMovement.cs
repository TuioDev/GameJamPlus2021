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
    [SerializeField] private float redJumpMultiplier = 1.5f;
    [SerializeField] private float yellowVelMultiplier = 1.5f;
    [SerializeField] private GameObject gameGrid;

    private GameColors playerColor;
    private GameObject respawnPoint;
    private bool grounded = false;
    private bool jump = false;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        playerColor = GameColors.Blank;
        eventManager.PlayerColorChange += ChangeColor;
        playerRB.velocity = new Vector2(playerVelocity, playerRB.velocity.y);
        
    }

    // Update is called once per frame
    void Update()
    {
        grounded = Physics2D.Linecast(transform.position, groundCheckLeft.position, 1 << LayerMask.NameToLayer("Level"));
        CanJump();
        CanUnlive();
    }

    private void FixedUpdate()
    {
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
                playerRB.velocity = new Vector2(playerVelocity, playerRB.velocity.y);
                playerJumpForce = 800.0f;
                currentSprite.sprite = playerSprites[0];
                break;
            case GameColors.Yellow:
                playerVelocity *= yellowVelMultiplier;
                playerRB.velocity = new Vector2(playerVelocity, playerRB.velocity.y);
                playerJumpForce = 800.0f;
                currentSprite.sprite = playerSprites[1];
                break;
            case GameColors.Red:
                playerVelocity = 5.0f;
                playerRB.velocity = new Vector2(playerVelocity, playerRB.velocity.y);
                playerJumpForce *= redJumpMultiplier;
                currentSprite.sprite = playerSprites[2];
                break;
            default:
                playerColor = GameColors.Blank;
                break;
        }
    }

    void CanUnlive()
    {
        if(playerRB.velocity.x < 4.95f)
        {
            MovePlayerToRespawnPoint();
        }
    }

    void MovePlayerToRespawnPoint()
    {
        
        
    }

}
