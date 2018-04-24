using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRigMovement : MonoBehaviour {

    private float cameraRotateSpeed = 3.0f;
    [SerializeField] protected GameObject m_target;
    [SerializeField] private float m_MoveSpeed = 1f;                      // How fast the rig will move to keep up with the target's position.
    public float CameraRotationResetSpeed = 0.0f;
    private float m_cameraOffset;
    public float Smooth = 0.2f;
    private Camera m_camera;

    // Use this for initialization
    void Start () 
    {
        m_camera = GetComponentInChildren<Camera>();
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
            //m_target.transform.rotation = transform.rotation;
        }

        // Both mousebuttons will align character with camera view (all re-centered)
        if (Input.GetMouseButton(0) && Input.GetMouseButton(1))
        {
            transform.localRotation = Quaternion.identity;

            if (transform.parent != m_target.transform)
            {
                transform.parent = m_target.transform; // reconnect the camera to the character so it will follow character.
            }
        }

        // Left mousebutton will rotate camera around character
        else if (Input.GetMouseButton(0))
        {
            transform.parent = null; //disconnect the camera from the character to allow it to rotate independently.

            float rotAngle = cameraRotateSpeed * Input.GetAxis("Mouse X");// * Time.deltaTime;
            transform.Rotate(Vector3.up, rotAngle, Space.Self);

        }
        else
        {
            if (transform.parent != m_target.transform)
            {
                transform.parent = m_target.transform; // reconnect the camera to the character so it will follow character.
            }
        }

        // Middle mousebutton scroll will zoom camera in and out on character
        float cameraZoom = Input.GetAxis("Mouse ScrollWheel");
        m_camera.transform.Translate(new Vector3(0, 0, cameraZoom));
        
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
