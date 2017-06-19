using UnityEngine;
using System.Collections;

public class GrannyMovement : MonoBehaviour {

    public Camera cam;
    static Animator anim;
    public float speed = 10.0F;
    public float rotationSpeed = 150.0F;
    public float cameraRotateSpeed = 720.0f;

	// Use this for initialization
	void Start () 
    {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        float translation = Input.GetAxis("Vertical1") * speed * Time.deltaTime;
        Debug.Log("value of input: " + Input.GetAxis("Vertical1"));
        float rotation = Input.GetAxis("Horizontal1") * rotationSpeed * Time.deltaTime;
        transform.Translate(0, 0, translation);
        transform.Rotate(0, rotation, 0);

        if (Input.GetButtonDown("Jump"))
        {
            anim.SetTrigger("isJumping");
        }
        anim.SetBool("isRunning", translation != 0);

        if (Input.GetMouseButton(1) && cam != null)
        {
            //Camera cam = FindObjectOfType<Camera>();
            float x = cameraRotateSpeed * Input.GetAxis("Mouse X") * Time.deltaTime;
            //cam.transform.Rotate((transform.position, Vector3.up, 90 * Time.deltaTime);
            cam.transform.RotateAround(this.transform.position, new Vector3(0.0f, 1.0f, 0.0f), x);
            //Debug.Log(cam.transform.position);
        }
	}
}
