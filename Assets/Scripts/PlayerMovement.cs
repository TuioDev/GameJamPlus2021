using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D playerRB;
    [SerializeField] private float playerVelocity = 5.0f;
    [SerializeField] private float playerJumpForce = 0.0f;
    [SerializeField] private Transform groundCheckLeft;
    [SerializeField] private SpriteRenderer currentSprite;
    [SerializeField] private float redJumpMultiplier = 1.4f;
    [SerializeField] private float yellowVelMultiplier = 1.5f;
    [SerializeField] private GameObject gameGrid;
    [SerializeField] private int winCondition;

    public GameColors playerColor;
    private GameObject respawnPoint;
    private bool grounded = false;
    private bool groundedY = false;
    private bool groundedR = false;
    private bool jump = false;
    private int savedCapivaras = 0;
    private SoundManager soundManager;
    public Animator playerAnimator;
    private bool coroutineController = false;




    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        playerColor = GameColors.Blank;
        EventManager.singleton.PlayerColorChange += ChangeColor;
        EventManager.singleton.PickUpCapivara += AddScoreNumber;
        playerRB.velocity = new Vector2(playerVelocity, playerRB.velocity.y);
        soundManager = SoundManager.instance;
        soundManager.sourceForTheClips.PlayOneShot(soundManager.Start);
    }

    // Update is called once per frame
    void Update()
    {
        grounded = Physics2D.Linecast(transform.position, groundCheckLeft.position, 1 << LayerMask.NameToLayer("Level"));
        groundedY = Physics2D.Linecast(transform.position, groundCheckLeft.position, 1 << LayerMask.NameToLayer("Red"));
        groundedR = Physics2D.Linecast(transform.position, groundCheckLeft.position, 1 << LayerMask.NameToLayer("Yellow"));
        CanJump();
        CheckVelocity();
        CheckIfWon();
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
        if ((grounded || groundedY || groundedR) && Input.GetKeyDown(KeyCode.Space))
        {
            jump = true;
            int number = Random.Range(0, 10);
            switch (number)
            {
                case 7:
                    soundManager.sourceForTheClips.PlayOneShot(soundManager.AlpacaJump);
                    break;
                case 9:
                    soundManager.sourceForTheClips.PlayOneShot(soundManager.AlpacaSpit);
                    break;
                default:
                    break;
            }
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
                playerAnimator.SetBool("BlankOrb", true);
                playerAnimator.SetBool("RedOrb", false);
                playerAnimator.SetBool("YellowOrb", false);

                break;
            case GameColors.Yellow:
                playerVelocity *= yellowVelMultiplier;
                playerRB.velocity = new Vector2(playerVelocity, playerRB.velocity.y);
                playerJumpForce = 800.0f;
                playerAnimator.SetBool("BlankOrb", false);
                playerAnimator.SetBool("RedOrb", false);
                playerAnimator.SetBool("YellowOrb", true);
                break;
            case GameColors.Red:
                playerVelocity = 5.0f;
                playerRB.velocity = new Vector2(playerVelocity, playerRB.velocity.y);
                playerJumpForce *= redJumpMultiplier;
                playerAnimator.SetBool("BlankOrb", false);
                playerAnimator.SetBool("RedOrb", true);
                playerAnimator.SetBool("YellowOrb", false);
                break;
            default:
                playerColor = GameColors.Blank;
                break;
        }
    }

    void CheckVelocity()
    {
        if (playerRB.velocity.x < 4.90f && coroutineController == false)
        {
            soundManager.sourceForTheClips.PlayOneShot(soundManager.Lose);
            SetVelocityToZero();
            coroutineController = true;
            playerAnimator.SetTrigger("Death");
            StartCoroutine(Pause());

        }
    }

    IEnumerator Pause()
    {
        yield return new WaitForSeconds(1.5f);
        playerAnimator.ResetTrigger("Death");
        MovePlayerToRespawnPoint();
        coroutineController = false;
    }
    public void MovePlayerToRespawnPoint()
    {
        Vector2 respawnPoint = GameObject.Find("Respawn_Point").transform.position;
        this.gameObject.transform.position = respawnPoint;
        SetVelocityToZero();
        ChangeColor(GameColors.Blank);
        EventManager.singleton.ChangeActiveTilemap(playerColor);

    }
    void AddScoreNumber(int score)
    {
        savedCapivaras += score;
    }

    void CheckIfWon()
    {
        if (savedCapivaras >= winCondition)
        {
            SceneManager.LoadScene(4);
        }
    }

    public void SetVelocityToZero()
    {
        playerRB.velocity = new Vector2(0.0f, 0.0f);
    }
}
