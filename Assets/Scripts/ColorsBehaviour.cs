using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorsBehaviour : MonoBehaviour
{
    [SerializeField] private GameColors orbColor;
    [SerializeField] private EventManager eventManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        eventManager.ChangePlayerBehaviour(orbColor);
        eventManager.ChangeActiveTilemap(orbColor);
    }
}
