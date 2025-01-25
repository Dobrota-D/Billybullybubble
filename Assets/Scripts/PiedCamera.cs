using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiedCamera : MonoBehaviour
{
    public Transform BillyBubble;
    
    private void Update()
    {
        transform.position = new Vector3(BillyBubble.position.x, BillyBubble.position.y, transform.position.z);
    }
}
