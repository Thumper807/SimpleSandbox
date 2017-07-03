using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRigMovement : MonoBehaviour {

    private float cameraRotateSpeed = 10.0f;
    [SerializeField] protected GameObject m_target;
    [SerializeField] private float m_MoveSpeed = 1f;                      // How fast the rig will move to keep up with the target's position.
    public float CameraRotationResetSpeed = 0.0f;

    // Use this for initialization
    void Start () 
    {
    }

    // Update is called once per frame
    void Update () 
    {
        if (m_target == null)
        {
            return;
        }

        // CAMERA RIG MOVEMENT

        // Move the rig towards target position.
        transform.position = Vector3.Lerp(transform.position, m_target.transform.position, m_MoveSpeed * Time.deltaTime);

        // If target is moving then reset the view to face target forward.
        if (transform.position - m_target.transform.position != Vector3.zero)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(m_target.transform.forward), CameraRotationResetSpeed);
        }

        // Left mousebutton will rotate camera around character
        if (Input.GetMouseButton(0))
        {
            float rotAngle = cameraRotateSpeed * Input.GetAxis("Mouse X");// * Time.deltaTime;
            transform.RotateAround(m_target.transform.position, Vector3.up, rotAngle);
        }   

        // Middle mousebutton scroll will zoom camera in and out on character
    }

    public void SetTarget(GameObject newTarget)
    {
        if (m_target != null)
        {
            m_target.GetComponent<SaveState>().SaveCameraState(transform.rotation);
        }

        m_target = newTarget;
        transform.rotation = m_target.GetComponent<SaveState>().GetCameraState();
    }
}
