using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonicAltarController : MonoBehaviour
{
    private float PlayerPos;
    private Vector3 PlayerPosVec;
    private GameObject DP1, DP2, DP3, DP4, DP5, DP6;
    public bool SpawnWallOfDeath = false;

    private void Awake()
    {
        if (this.gameObject.name == "DemonicAltar1")
        {
            DP1 = GameObject.Find("DemonicPage1");
            DP1.SetActive(false);
        }

        if (this.gameObject.name == "DemonicAltar2")
        {
            DP2 = GameObject.Find("DemonicPage2");
            DP2.SetActive(false);
        }

        if (this.gameObject.name == "DemonicAltar3")
        {
            DP3 = GameObject.Find("DemonicPage3");
            DP3.SetActive(false);
        }

        if (this.gameObject.name == "DemonicAltar4")
        {
            DP4 = GameObject.Find("DemonicPage4");
            DP4.SetActive(false);
        }

        if (this.gameObject.name == "DemonicAltar5")
        {
            DP5 = GameObject.Find("DemonicPage5");
            DP5.SetActive(false);
        }

        if (this.gameObject.name == "DemonicAltar6")
        {
            DP6 = GameObject.Find("DemonicPage6");
            DP6.SetActive(false);
        }

    }

    void Update()
    {
        if (Time.time >= 120f)
        {
            SpawnWallOfDeath = true;
        }

        PlayerPos = GameObject.Find("Player").GetComponent<Transform>().position.x;
        PlayerPosVec = GameObject.Find("Player").GetComponent<Transform>().position;


        if (Mathf.Abs(this.gameObject.GetComponent<Transform>().position.x - PlayerPos) <= 1.5f)
        {
            if(Input.GetKeyDown("e"))
            {
                int PageNumber = this.gameObject.name[name.Length - 1];
                GameObject.Find("Player").GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);

                LearnLore(PageNumber);
            }
        }
    }

    void LearnLore(int PageNumber)
    {
        switch (PageNumber)
        {
            case '1': 
                {
                    if(DP1.active)
                    {
                        DP1.SetActive(false);
                        GameObject.Find("Player").GetComponent<PlayerMovement>().IsMovePossible = true;
                        GameObject.Find("Player").GetComponent<WallOfDeathController>().IsPlayerReading = false;
                    }
                    else
                    {
                        DP1.transform.position = new Vector3(PlayerPosVec.x, PlayerPosVec.y, -9f);
                        DP1.SetActive(true);
                        GameObject.Find("Player").GetComponent<PlayerMovement>().IsMovePossible = false;
                        GameObject.Find("Player").GetComponent<WallOfDeathController>().IsPlayerReading = true;
                    }
                }
                break;
            case '2':
                {
                    if (DP2.active)
                    {
                        DP2.SetActive(false);
                        GameObject.Find("Player").GetComponent<PlayerMovement>().IsMovePossible = true;
                        GameObject.Find("Player").GetComponent<WallOfDeathController>().IsPlayerReading = false;
                    }
                    else
                    {
                        DP2.transform.position = new Vector3(PlayerPosVec.x, PlayerPosVec.y, -9f);
                        DP2.SetActive(true);
                        GameObject.Find("Player").GetComponent<PlayerMovement>().IsMovePossible = false;
                        GameObject.Find("Player").GetComponent<WallOfDeathController>().IsPlayerReading = true;
                    }
                }
                break;
            case '3':
                {
                    if (DP3.active)
                    {
                        DP3.SetActive(false);
                        GameObject.Find("Player").GetComponent<PlayerMovement>().IsMovePossible = true;
                        GameObject.Find("Player").GetComponent<WallOfDeathController>().IsPlayerReading = false;
                    }
                    else
                    {
                        DP3.transform.position = new Vector3(PlayerPosVec.x, PlayerPosVec.y, -9f);
                        DP3.SetActive(true);
                        GameObject.Find("Player").GetComponent<PlayerMovement>().IsMovePossible = false;
                        GameObject.Find("Player").GetComponent<WallOfDeathController>().IsPlayerReading = true;
                        SpawnWallOfDeath = true;
                    }
                }
                break;
            case '4':
                {
                    if (DP4.active)
                    {
                        DP4.SetActive(false);
                        GameObject.Find("Player").GetComponent<PlayerMovement>().IsMovePossible = true;
                        GameObject.Find("Player").GetComponent<WallOfDeathController>().IsPlayerReading = false;
                    }
                    else
                    {
                        DP4.transform.position = new Vector3(PlayerPosVec.x, PlayerPosVec.y, -9f);
                        DP4.SetActive(true);
                        GameObject.Find("Player").GetComponent<PlayerMovement>().IsMovePossible = false;
                        GameObject.Find("Player").GetComponent<WallOfDeathController>().IsPlayerReading = true;
                    }
                }
                break;
            case '5':
                {
                    if (DP5.active)
                    {
                        DP5.SetActive(false);
                        GameObject.Find("Player").GetComponent<PlayerMovement>().IsMovePossible = true;
                        GameObject.Find("Player").GetComponent<WallOfDeathController>().IsPlayerReading = false;
                    }
                    else
                    {
                        DP5.transform.position = new Vector3(PlayerPosVec.x, PlayerPosVec.y, -9f);
                        DP5.SetActive(true);
                        GameObject.Find("Player").GetComponent<PlayerMovement>().IsMovePossible = false;
                        GameObject.Find("Player").GetComponent<WallOfDeathController>().IsPlayerReading = true;
                    }
                }
                break;
            case '6':
                {
                    if (DP6.active)
                    {
                        DP6.SetActive(false);
                        GameObject.Find("Player").GetComponent<PlayerMovement>().IsMovePossible = true;
                        GameObject.Find("Player").GetComponent<WallOfDeathController>().IsPlayerReading = false;
                    }
                    else
                    {
                        DP6.transform.position = new Vector3(PlayerPosVec.x, PlayerPosVec.y, -9f);
                        DP6.SetActive(true);
                        GameObject.Find("Player").GetComponent<PlayerMovement>().IsMovePossible = false;
                        GameObject.Find("Player").GetComponent<WallOfDeathController>().IsPlayerReading = true;
                    }
                }
                break;

            default:
                break;
        }
    }
}
