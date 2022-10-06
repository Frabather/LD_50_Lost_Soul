using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalPlatformMover : MonoBehaviour
{
    private bool IsMovingUp = false;
    private Vector3 PlatformPos;
    private Rigidbody PlatformRb;
    private float minX, maxX;

    private void Awake()
    {
        PlatformPos = this.gameObject.GetComponent<Transform>().position;
        PlatformRb = this.gameObject.GetComponent<Rigidbody>();
        minX = PlatformPos.x - 2.5f;
        maxX = PlatformPos.x + 2.5f;
    }

    void FixedUpdate()
    {
        PlatformPos = this.gameObject.GetComponent<Transform>().position;

        if (IsMovingUp)
        {
            if (PlatformPos.x >= minX) 
            {
                PlatformRb.MovePosition(PlatformPos + Vector3.left * Time.deltaTime * 2f);
            }
            else
            {
                IsMovingUp = false;
            }
        }
        else
        {
            if (PlatformPos.x <= maxX)
            {
                PlatformRb.MovePosition(PlatformPos + Vector3.right * Time.deltaTime * 2f);
            }
            else
            {
                IsMovingUp = true;
            }   
        }
    }
}
