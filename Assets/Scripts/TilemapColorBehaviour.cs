using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapColorBehaviour : MonoBehaviour
{
    [SerializeField] private GameColors tilemapColor;
    [SerializeField] private EventManager eventManager;

    private void Start()
    {
        eventManager.ControllingActiveObjects += TilemapController;
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
}