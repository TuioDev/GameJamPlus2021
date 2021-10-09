using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
   
public class EventManager : MonoBehaviour
{
    public event Action<GameColors> PlayerColorChange;

    //Call the event
    public void ChangePlayerBehaviour(GameColors gc)
    {
        PlayerColorChange(gc);
    }


}
