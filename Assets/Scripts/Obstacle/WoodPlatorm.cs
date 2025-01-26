using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodPlatorm : MonoBehaviour
{

    [SerializeField] private float m_AnimationSpeed;
    [SerializeField] private Vector3 finalPosition;
    [SerializeField] private AnimationCurve m_CurveAnimation;

    private Vector3 _startPos;
    // Start is called before the first frame update
    void Start()
    {
        _startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = Vector3.Lerp(_startPos, finalPosition, (m_CurveAnimation.Evaluate(Time.time * m_AnimationSpeed)));
        transform.position = position;
    }
}
