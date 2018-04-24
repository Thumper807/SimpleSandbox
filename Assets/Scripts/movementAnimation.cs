using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementAnimation : MonoBehaviour
{
    private Animator m_animator;
    private CreatureContext m_creatureContext;
    private Queue<float> movementXQueue;
    private Queue<float> movementYQueue;

    void Start()
    {
        m_animator = this.GetComponent<Animator>();
        m_creatureContext = this.GetComponent<CreatureContext>();
        movementXQueue = new Queue<float>();
        movementYQueue = new Queue<float>();
    }

    void Update()
    {
        // Normalize
        float normMovementX = m_creatureContext.Direction.x / m_creatureContext.RunSpeedMax;
        float normMovementY = m_creatureContext.Direction.z / m_creatureContext.RunSpeedMax;

        //Debug.Log(normMovementY);
        if (normMovementY < 0.49f || normMovementY > 0.51f)
            Debug.Log("OUT");
        else
            Debug.Log("IN");

        if (movementXQueue.Count < 10)
        {
            movementXQueue.Enqueue(normMovementX);
            movementYQueue.Enqueue(normMovementY);
        }
        else
        {
            movementXQueue.Dequeue();
            movementYQueue.Dequeue();
            movementXQueue.Enqueue(normMovementX);
            movementYQueue.Enqueue(normMovementY);
        }

        float totalX = 0.0f;
        foreach (float num in movementXQueue)
            totalX += num;

        float avgX = totalX / movementXQueue.Count;

        float totalY = 0.0f;
        foreach (float num in movementYQueue)
            totalY += num;

        float avgY = totalY / movementYQueue.Count;

        avgX = (Mathf.Round(avgX * 10)) / 10;
        avgY = (Mathf.Round(avgY * 10)) / 10;
        //Debug.Log(avgY);

        // Set Animation Parameters
        m_animator.SetFloat("xMotion", avgX);//, 0.1f, Time.deltaTime);
        m_animator.SetFloat("yMotion", avgY);//, 0.1f, Time.deltaTime);

        if (Input.GetButtonDown("Jump"))
        {
            m_animator.SetTrigger("isJumping");
        }
    }
}
