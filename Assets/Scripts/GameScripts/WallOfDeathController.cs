using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallOfDeathController : MonoBehaviour
{

    public GameObject WallOfDeath;
    private Rigidbody WODRb;
    private Transform WODTrans;
    private Vector3 WODPos;
    private bool IsSpawnedOnce = false;
    public bool IsPlayerReading = false;
    private Transform PlayerTrans;
    private Vector3 PlayerPos;
    private float WODSpeed = 5f, offsetX;
    private Material WODMaterialOffset;

    private void Awake()
    {
        PlayerTrans = GameObject.Find("Player").GetComponent<Transform>();
        WallOfDeath = GameObject.Find("WallOfDeath");
        WODRb = WallOfDeath.GetComponent<Rigidbody>();
        WODTrans = WallOfDeath.GetComponent<Transform>();
        WODMaterialOffset = WallOfDeath.GetComponent<Renderer>().material;
        WallOfDeath.SetActive(false);

    }

    void FixedUpdate()
    {
        PlayerPos = PlayerTrans.position;

        if (GameObject.Find("DemonicAltar3").GetComponent<DemonicAltarController>().SpawnWallOfDeath && IsSpawnedOnce == false)
        {
            WallOfDeath.SetActive(true);
            IsSpawnedOnce = true;
        }

        if (WallOfDeath.active && !IsPlayerReading)
        {
            WODPos = WODTrans.position;
            offsetX += 0.01f;
            WODMaterialOffset.SetTextureOffset("_MainTex", new Vector2(0, offsetX));

            if (Mathf.Abs(WODTrans.position.x - PlayerPos.x) >= 50f)
            {
                WODSpeed = 40f;
                WODRb.MovePosition(WODPos + Vector3.right * Time.deltaTime * WODSpeed);
            }
            else
            {
                WODSpeed = 3f;
                WODRb.MovePosition(WODPos + Vector3.right * Time.deltaTime * WODSpeed);
            }
        }
    }
}
