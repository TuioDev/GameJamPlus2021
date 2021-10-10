using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorsBehaviour : MonoBehaviour
{
    [SerializeField] private GameColors orbColor;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        EventManager.singleton.ChangePlayerBehaviour(orbColor);
        EventManager.singleton.ChangeActiveTilemap(orbColor);
    }
}
