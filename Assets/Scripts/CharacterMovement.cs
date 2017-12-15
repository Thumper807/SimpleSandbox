using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour {

    private Animator anim;
    public float WalkingSpeed = 1.75f;
    public float fwdRunningSpeed = 5.0f;
    public float MaxFwdSpeed = 5.0f;
    public float RunningSpeedMultipler = 1.0f;
    public float WalkingSpeedMultipler = 0.5f;
    public float bwdSpeed = 5.0f;
    public float rotationSpeed = 500.0f;
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
    }

    private float Move()
    {
        float yTranslation;
        float xTranslation;

        // CHARACTER MOVEMENT
        // Right mousebutton will rotate character
        float rotation = 0.0f;
        if (Input.GetMouseButton(1))
        {
            rotation = rotationSpeed * Input.GetAxis("Mouse X") * Time.deltaTime;
        }

        if (Mathf.Abs(Input.GetAxis("Horizontal")) > 0.0f)
        {
            rotation = rotationSpeed * Input.GetAxis("Horizontal") * Time.deltaTime;
        }

        // 'fwd key' or 'Left & Right' mousebutton together will move character forward
        // 'backward key' will move character back slowly
        float yInput = Input.GetAxis("Vertical");
        float runInput = Input.GetAxis("RunModifier");

        yInput = yInput * (runInput + 1);

        yInput = Mathf.Clamp(yInput, -1.0f, 2.0f);
        yTranslation = yInput * WalkingSpeed * Time.deltaTime;

        //if (Input.GetKey(KeyCode.W) || (Input.GetMouseButton(0) && Input.GetMouseButton(1)))
        //{
        //    float fwdSpeed = WalkingSpeed;
        //    if (Input.GetKey(KeyCode.LeftShift))
        //    {
        //        fwdSpeed = fwdRunningSpeed;
        //    }

        //    translation = yInput * MaxFwdSpeed * Time.deltaTime;
        //}
        //else if (Input.GetKey(KeyCode.S))
        //{
        //    translation = -bwdSpeed * Time.deltaTime;
        //}
        //else
        //{
        //    translation = 0.0f;
        //}

        // 'side keys' will strafe character left and right
        float xInput = Input.GetAxis("Strafe");
        xTranslation = xInput * WalkingSpeed * Time.deltaTime;

        // 'jump key' will cause character to jump

        // TRANSFORM
        transform.Translate(xTranslation, 0, yTranslation);
        transform.Rotate(Vector3.up, rotation);

        anim.SetFloat("xMotion", xInput);
        anim.SetFloat("yMotion", yInput);
        return yTranslation;
    }
}
