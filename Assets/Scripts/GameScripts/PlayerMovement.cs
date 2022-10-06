using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private GameObject Player;
    private Rigidbody PlayerRb;
    private Transform PlayerTrans;
    private float PlayerSpeed = 1500f;
    public bool IsGrounded = false, IsMovePossible = true;
    Sprite LeftPlayerSprite, RightPlayerSprite;

    void Start()
    {
        Player = GameObject.Find("Player");
        PlayerRb = Player.GetComponent<Rigidbody>();
        PlayerTrans = Player.GetComponent<Transform>();
        GameObject.Find("Player").GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        GameObject.Find("Player").GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
        GameObject.Find("Player").GetComponent<AudioSource>().clip = GameObject.Find("GameAudioHolder").GetComponent<AudioSource>().clip;
        LeftPlayerSprite = GameObject.Find("RightPlayerRotationsHolder").GetComponent<SpriteRenderer>().sprite;
        RightPlayerSprite = GameObject.Find("LeftPlayerRotationsHolder").GetComponent<SpriteRenderer>().sprite;
    }


    private void Update()
    {
        if (IsMovePossible)
        {

            if (Input.GetKeyDown("a"))
            {
                Player.GetComponent<SpriteRenderer>().sprite = RightPlayerSprite;
            }
            if (Input.GetKeyDown("d"))
            {
                Player.GetComponent<SpriteRenderer>().sprite = LeftPlayerSprite;
            }
        }
    }

    void FixedUpdate()
    {
        if (PlayerTrans.position.y <= -20f)
        {
            if (PlayerTrans.position.x <= 310f)
            {
                if (!GameObject.Find("DemonicAltar3").GetComponent<DemonicAltarController>().SpawnWallOfDeath)
                {
                    GameObject.Find("FallingBackground").GetComponent<Transform>().position = new Vector3(5.5f, 13.98808f, 0f);
                    GameObject.Find("FallingBackground2").GetComponent<Transform>().position = new Vector3(-24.5f, 13.98808f, 0f);
                    PlayerTrans.position = new Vector3(0f, 2f, -0.5f);
                }
                else
                {
                    this.gameObject.GetComponent<GameOver>().IsGameOver = true;
                }
            }
            else
            {
                if (PlayerTrans.position.y <= -40f)
                {
                    if (!GameObject.Find("DemonicAltar3").GetComponent<DemonicAltarController>().SpawnWallOfDeath)
                    {
                        GameObject.Find("FallingBackground").GetComponent<Transform>().position = new Vector3(5.5f, 13.98808f, 0f);
                        GameObject.Find("FallingBackground2").GetComponent<Transform>().position = new Vector3(-24.5f, 13.98808f, 0f);
                        PlayerTrans.position = new Vector3(0f, 2f, -0.5f);
                    }
                    else
                    {
                        this.gameObject.GetComponent<GameOver>().IsGameOver = true;
                    }
                }
            } 
        }

        if (Input.GetKey("a") && PlayerRb.velocity.magnitude < 5f && IsMovePossible)
        {
            {
                PlayerRb.AddForce(-PlayerSpeed * Time.deltaTime, 0f, 0f) ;
            }
        }
        if (Input.GetKey("d") && PlayerRb.velocity.magnitude < 5f && IsMovePossible)
        {
            {
                PlayerRb.AddForce(PlayerSpeed * Time.deltaTime, 0f, 0f);
            }
        }
        if ((Input.GetKey("space") || Input.GetKeyDown("space")) && IsGrounded && IsMovePossible)
        {
            if(PlayerTrans.position.x <= 230f)
            {
                IsGrounded = false;
                PlayerRb.AddForce(0, PlayerSpeed * 20f * Time.deltaTime, 0);
            }
            else
            {
                IsGrounded = false;
                PlayerRb.AddForce(0, PlayerSpeed * 25f * Time.deltaTime, 0);
            }
        }
    }
}
