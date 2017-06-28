using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveState : MonoBehaviour {

    private Quaternion m_cameraRigRotationOffset;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SaveCameraState(Quaternion rotation)
    {
        m_cameraRigRotationOffset = rotation;
    }

    public Quaternion GetCameraState()
    {
        return m_cameraRigRotationOffset;
    }
}
