using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureContext : MonoBehaviour
{
    private Vector3 m_lastPosition;
    private Quaternion m_lastRotation;
    private float m_velocity;
    private float m_rotation;

    public float WalkSpeed = 1.0f;
    public float RunSpeedMax
    {
        get
        {
            return WalkSpeed * 2;
        }
    }
    public float RotationSpeed = 100.0f;
    public bool Active { get; set; }
    public float Velocity
    {
        get
        {
            return m_velocity;
        }
    }
    public float Rotation
    {
        get
        {
            return m_rotation;
        }
    }
    public Vector3 Direction;

    protected virtual void Start()
    {
        m_lastPosition = transform.position;
        m_lastRotation = transform.rotation;
    }

    protected virtual void Update()
    {
        m_velocity = ((transform.position - m_lastPosition).magnitude / Time.deltaTime);
        Direction = transform.InverseTransformDirection(transform.position - m_lastPosition) / Time.deltaTime;

        m_rotation = Quaternion.Angle(transform.rotation, m_lastRotation);

        m_lastPosition = transform.position;
        m_lastRotation = transform.rotation;
    }
}
