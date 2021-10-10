using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private EventManager eventManager;
    [SerializeField] private GameObject gameGrid;
    private GameObject currentPart;
    //private GameObject previousPart;

    private void Start()
    {
        //previousPart = null;
        //currentPart = GetComponentInChildren<GameObject>();
        //eventManager.ControllingActiveObjects += TilemapController;
    }
}
