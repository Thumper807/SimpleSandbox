using UnityEngine;
using System.Collections;
using System;

public class CharacterMovement : MonoBehaviour {

    private Animator m_animator;
    public float WalkingSpeed = 1.75f;
    public float RotationSpeed = 500.0f;
    public bool Active;

    // Use this for initialization
    void Start () 
    {
        m_animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update () 
    {
        float xInput = 0.0f;
        float yInput = 0.0f;

        if (Active)
        {
            Move(out xInput, out yInput);

            if (Input.GetButtonDown("Jump"))
            {
                m_animator.SetTrigger("isJumping");
            }
        }

        m_animator.SetFloat("xMotion", xInput);
        m_animator.SetFloat("yMotion", yInput);
    }

    private void Move(out float xInput, out float yInput)
    {
        float yTranslation;
        float xTranslation;

        // CHARACTER MOVEMENT
        // Right mousebutton will rotate character
        float rotation = 0.0f;
        if (Input.GetMouseButton(1))
        {
            rotation = RotationSpeed * Input.GetAxis("Mouse X") * Time.deltaTime;
        }
        
        // 'left', 'right', 'a', and 'd' keys will rotate character (overrides the mouse)
        if (Mathf.Abs(Input.GetAxis("Horizontal")) > 0.0f)
        {
            rotation = RotationSpeed * Input.GetAxis("Horizontal") * Time.deltaTime;
        }

        // 'fwd key' or 'backward key' will move character forward or backwards
        yInput = Input.GetAxis("Vertical");
        float runInput = Input.GetAxis("RunModifier");

        yInput = yInput * (runInput + 1);

        yInput = Mathf.Clamp(yInput, -1.0f, 2.0f);
        yTranslation = yInput * WalkingSpeed * Time.deltaTime;

        // 'side keys' will strafe character left and right
        xInput = Input.GetAxis("Strafe");
        xTranslation = xInput * WalkingSpeed * Time.deltaTime;

        // 'jump key' will cause character to jump

        // TRANSFORM
        transform.Translate(xTranslation, 0, yTranslation);
        transform.Rotate(Vector3.up, rotation);
    }
}
