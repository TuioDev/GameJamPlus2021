using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbBehaviour : MonoBehaviour
{
    [SerializeField] private GameColors orbColor;
    [SerializeField] EventManager eventManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        eventManager.ChangePlayerBehaviour(orbColor);
    }
}
