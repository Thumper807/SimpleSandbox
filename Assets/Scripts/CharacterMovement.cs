using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour {

    private Animator anim;
    private float fwdSpeed = 10.0f;
    private float bwdSpeed = 10.0f;
    private float rotationSpeed = 500.0f;
    public bool Active;

    // Use this for initialization
    void Start () 
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update () 
    {
        float characterMovement = 0.0f;

        if (Active)
            characterMovement = Move();


        // ANIMATE
        if (Input.GetButtonDown("Jump"))
        {
            anim.SetTrigger("isJumping");
        }
        anim.SetFloat("isRunning", characterMovement);
        //Debug.Log(anim.GetCurrentAnimatorStateInfo(0).);
    }

    private float Move()
    {
        float translation;

        // CHARACTER MOVEMENT
        // Right mousebutton will rotate character
        float rotation = 0.0f;
        if (Input.GetMouseButton(1))
        {
            rotation = rotationSpeed * Input.GetAxis("Mouse X") * Time.deltaTime;
        }

        if (Mathf.Abs(Input.GetAxis("Horizontal1")) > 0.0f)
        {
            rotation = rotationSpeed * Input.GetAxis("Horizontal1") * Time.deltaTime;
        }

        // 'fwd key' or 'Left & Right' mousebutton together will move character forward
        // 'backward key' will move character back slowly
        if (Input.GetKey(KeyCode.W) || (Input.GetMouseButton(0) && Input.GetMouseButton(1)))
        {
            translation = fwdSpeed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            translation = -bwdSpeed * Time.deltaTime;
        }
        else
        {
            translation = 0.0f;
        }

        // 'side keys' will strafe character left and right

        // 'jump key' will cause character to jump

        // TRANSFORM
        transform.Translate(0, 0, translation);
        transform.Rotate(Vector3.up, rotation);

        return translation;
    }
}
