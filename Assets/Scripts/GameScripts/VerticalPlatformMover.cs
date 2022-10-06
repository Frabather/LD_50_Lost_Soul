using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalPlatformMover : MonoBehaviour
{
    private bool IsMovingUp = false;
    private Vector3 PlatformPos;
    private Rigidbody PlatformRb;
    private float minY, maxY;

    private void Awake()
    {
        PlatformPos = this.gameObject.GetComponent<Transform>().position;
        PlatformRb = this.gameObject.GetComponent<Rigidbody>();
        minY = PlatformPos.y - 4f;
        maxY = PlatformPos.y + 6f;
    }

    void Update()
    {
        PlatformPos = this.gameObject.GetComponent<Transform>().position;

        if (IsMovingUp)
        {
            if (PlatformPos.y >= minY) 
            {
                PlatformRb.MovePosition(PlatformPos + Vector3.down * Time.deltaTime * 5f);
            }
            else
            {
                IsMovingUp = false;
            }
        }
        else
        {
            if (PlatformPos.y <= maxY)
            {
                PlatformRb.MovePosition(PlatformPos + Vector3.up * Time.deltaTime * 5f);
            }
            else
            {
                IsMovingUp = true;
            }   
        }
    }
}
