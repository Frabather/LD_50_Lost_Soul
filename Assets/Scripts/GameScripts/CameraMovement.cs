using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    //private Vector3 PlayerPos;
    private Transform PlayerTrans;

    private void Awake()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        PlayerTrans = GameObject.Find("Player").GetComponent<Transform>();
    }

    void Update()
    {
        this.gameObject.transform.position = new Vector3(PlayerTrans.position.x, PlayerTrans.position.y, -10);
    }
}
