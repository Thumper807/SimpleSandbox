using UnityEngine;
using System.Collections;
using System;

public class CharacterMovement : CreatureContext
{
    private Animator m_animator;

    // Use this for initialization
    void Start () 
    {
        m_animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    protected override void Update () 
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
        yTranslation = yInput * base.WalkSpeed * Time.deltaTime;

        // 'side keys' will strafe character left and right
        xInput = Input.GetAxis("Strafe");
        xTranslation = xInput * base.WalkSpeed * Time.deltaTime;

        // 'jump key' will cause character to jump

        // TRANSFORM
        transform.Translate(xTranslation, 0, yTranslation);
        transform.Rotate(Vector3.up, rotation);
    }
}
