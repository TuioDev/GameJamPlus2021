using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapivaraBehaviour : MonoBehaviour
{
    private int value = 1;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        EventManager.singleton.UpdateScore(value);
        this.gameObject.SetActive(false);
    }
}
