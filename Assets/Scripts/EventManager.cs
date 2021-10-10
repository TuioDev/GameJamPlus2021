using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
   
public class EventManager : MonoBehaviour
{
    public static EventManager singleton { get; private set; }
    [SerializeField] private EventManager eventManager;
    public event Action<GameColors> PlayerColorChange;
    public event Action<GameColors> ControllingActiveObjects;
    public event Action<int> PickUpCapivara;
    private void Awake()
    {
        singleton = this;
    }
    //Call the event
    public void ChangePlayerBehaviour(GameColors gc)
    {
        PlayerColorChange(gc);
    }

    public void ChangeActiveTilemap(GameColors gc)
    {
        ControllingActiveObjects(gc);
    }

    public void UpdateScore(int score)
    {
        PickUpCapivara(score);
    }
}
