using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerEndLevel : MonoBehaviour
{
    //[SerializeField] UnityEvent trigger;

    public string sceneName;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Bubble"))
        {
            MenuManager.SwitchScene(sceneName);
        }
    }
}
