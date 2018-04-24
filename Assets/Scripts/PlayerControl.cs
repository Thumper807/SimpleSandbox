using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : CreatureContext
{

    protected override void Update()
    {
        base.Update();

        if (!Active)
            return;

        // Perform movement.
        float runInput = Input.GetAxis("RunModifier") + 1;
        float movementSpeed = base.WalkSpeed * runInput;

        float translation = Input.GetAxis("Vertical") * movementSpeed;
        float rotation = Input.GetAxis("Horizontal") * base.RotationSpeed;
        float strafe = Input.GetAxis("Strafe") * movementSpeed;

        // Right mouse button will rotate via mouse.
        if (Input.GetMouseButton(1))
        {
            rotation = Mathf.Clamp(Input.GetAxis("Mouse X"), -5.0f, 5.0f) * base.RotationSpeed;
        }
        // If left & right mouse buttons are down, then translate forward.
        if (Input.GetMouseButton(0) && Input.GetMouseButton(1))
        {
            translation = movementSpeed;
        }

        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;
        strafe *= Time.deltaTime;

        transform.Translate(strafe, 0, translation);
        transform.Rotate(0, rotation, 0);

    }
}
