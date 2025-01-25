using UnityEngine;

public class Axe : MonoBehaviour
{
    [SerializeField] private float m_PendulumAngle;
    [SerializeField] private float m_AnimationSpeed;
    [SerializeField] private AnimationCurve m_CurveAnimation;

    private float _startAngle;
    private float _currentTime;

    private void Start()
    {
        _startAngle = transform.eulerAngles.z;
    }

    private void Update()
    {
        float angle = m_PendulumAngle * (m_CurveAnimation.Evaluate(Time.time * m_AnimationSpeed) - 0.5f);
        transform.localRotation = Quaternion.Euler(0, 0, angle);
    }
}
