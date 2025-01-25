using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] GameObject m_Bubble;
    [SerializeField] float m_DistanceFromTarget;
    [SerializeField] LayerMask m_BackgroundLayer;
    [SerializeField] float distanceFromBubble = 2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var direction = m_Bubble.transform.position - transform.position;
        transform.rotation = Quaternion.LookRotation(Vector3.forward, direction);
        if (direction.x < 0)
        {
            transform.Rotate(0, 180, 0);
        }
        else
        {
            transform.Rotate(0, 0, 0);
        }
        transform.Rotate(0,0,90);
        transform.position = GetMousePositionIG(Input.mousePosition);
        
        // Set Distance from bubble
        transform.position = (transform.position - m_Bubble.transform.position).normalized * distanceFromBubble + m_Bubble.transform.position;
    }

    Vector3 GetMousePositionIG(Vector2 mousePositionOnScreen)
    {
        Vector3 startPos = new(mousePositionOnScreen.x, mousePositionOnScreen.y, Camera.main.nearClipPlane);

        //Get ray from mouse postion
        Ray rayCast = Camera.main.ScreenPointToRay(startPos);

        //Raycast and check if any object is hit
        Physics.Raycast(rayCast, out RaycastHit hit, Camera.main.farClipPlane, m_BackgroundLayer);
        Debug.DrawLine(Camera.main.transform.position, hit.point, Color.red);
        return new Vector3(hit.point.x, hit.point.y, -1);
    }
}
