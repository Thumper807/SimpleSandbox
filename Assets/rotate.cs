using UnityEngine;
using System.Collections;

public class rotate : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        float xInput = Input.GetAxis("Mouse X");
        float rotation = xInput * 500 * Time.deltaTime;

        transform.Rotate(Vector3.up, rotation);
	}
}
