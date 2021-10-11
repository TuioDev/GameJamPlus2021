using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapColorBehaviour : MonoBehaviour
{
    [SerializeField] private GameColors tilemapColor;
    private SoundManager soundManager;
    private bool coroutineController = false;

    private void Start()
    {
        EventManager.singleton.ControllingActiveObjects += TilemapController;
        soundManager = SoundManager.instance;
    }


    void TilemapController(GameColors gc)
    {
        if(tilemapColor == gc)
        {
            this.gameObject.GetComponent<TilemapCollider2D>().enabled = false;
        }
        else
        {
            this.gameObject.GetComponent<TilemapCollider2D>().enabled = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerMovement player = collision.collider.GetComponent<PlayerMovement>();
        
        if(player != null)
        {
            if(player.playerColor != GameColors.Blank && player.playerColor != tilemapColor && coroutineController == false)
            {
                soundManager.sourceForTheClips.PlayOneShot(soundManager.Lose);
                player.SetVelocityToZero();
                coroutineController = true;
                player.playerAnimator.SetTrigger("Death");
                StartCoroutine(Pausa(player));
            }
        }
    }
    IEnumerator Pausa(PlayerMovement player)
    {
        yield return new WaitForSeconds(1.5f);
        player.playerAnimator.ResetTrigger("Death");
        player.MovePlayerToRespawnPoint();
        coroutineController = false;
    }
}