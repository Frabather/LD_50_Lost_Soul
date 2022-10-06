using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundControl : MonoBehaviour
{
    private float PlayerPos;
    //private float LavaSpeed = 20f;


    void Update()
    {
        PlayerPos = GameObject.Find("Player").GetComponent<Transform>().position.x;

        if (Mathf.Abs(this.gameObject.GetComponent<Transform>().position.x - PlayerPos) >= 29.5f)
        {
            if (Input.GetKey("a"))
            {
                this.gameObject.GetComponent<Transform>().position = new Vector3(this.gameObject.GetComponent<Transform>().position.x - (2 * 29.5f), this.gameObject.GetComponent<Transform>().position.y, this.gameObject.GetComponent<Transform>().position.z);
            }
            if (Input.GetKey("d"))
            {
                this.gameObject.GetComponent<Transform>().position = new Vector3(this.gameObject.GetComponent<Transform>().position.x + (2 * 29.5f), this.gameObject.GetComponent<Transform>().position.y, this.gameObject.GetComponent<Transform>().position.z);
            }
        }
    }
}
