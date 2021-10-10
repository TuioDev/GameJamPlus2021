using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapColorBehaviour : MonoBehaviour
{
    [SerializeField] private GameColors tilemapColor;
    //[SerializeField] private EventManager eventManager;

    private void Start()
    {
        //eventManager = EventManager.singleton; // = GameObject.FindObjectOfType<EventManager>(); //("EventManager").GetComponent<EventManager>();
        EventManager.singleton.ControllingActiveObjects += TilemapController;
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
            if(player.playerColor != GameColors.Blank && player.playerColor != tilemapColor)
            {
                player.MovePlayerToRespawnPoint();
            }
        }
    }
}