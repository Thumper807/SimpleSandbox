using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

    private float cameraRotateSpeed = 10.0f;
    [SerializeField] protected Transform m_target;
    [SerializeField] private float m_MoveSpeed = 1f;                      // How fast the rig will move to keep up with the target's position.
    private Vector3 m_cameraRigRotationOffset = new Vector3();

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
        transform.position = Vector3.Lerp(transform.position, m_target.position, m_MoveSpeed * Time.deltaTime);

        // Left mousebutton will rotate camera around character
        if (Input.GetMouseButton(0))
        {
            float x = Input.GetAxis("Mouse X") * cameraRotateSpeed * Time.deltaTime;
            m_cameraRigRotationOffset.x += x;
//            float rotAngle = cameraRotateSpeed * Input.GetAxis("Mouse X") * Time.deltaTime;
//            transform.RotateAround(m_target.position, Vector3.up, rotAngle);
        }   

        Vector3 camRigLookDir = m_target.forward + m_cameraRigRotationOffset;
        transform.rotation = Quaternion.LookRotation(camRigLookDir);

        // Middle mousebutton scroll will zoom camera in and out on character
    }

    public void SetTarget(Transform newTarget)
    {
        m_target = newTarget;
        m_cameraRigRotationOffset = new Vector3(); //reset camerarig rotation.
        transform.rotation = Quaternion.LookRotation(m_target.forward);
    }
}
