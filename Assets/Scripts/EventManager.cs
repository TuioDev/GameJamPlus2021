using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
   
public class EventManager : MonoBehaviour
{
    [SerializeField] private EventManager eventManager;
    public event Action<GameColors> PlayerColorChange;
    public event Action<GameColors> ControllingActiveObjects;

    //Call the event
    public void ChangePlayerBehaviour(GameColors gc)
    {
        PlayerColorChange(gc);
    }

    public void ChangeActiveTilemap(GameColors gc)
    {
        ControllingActiveObjects(gc);
    }
}
