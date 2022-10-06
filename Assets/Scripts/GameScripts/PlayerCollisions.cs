using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    private Light DieCameraLight;
    private GameObject Finish1, Finish2, Finish3, LastWords;

    private void Awake()
    {
        DieCameraLight = GameObject.Find("Main Camera").GetComponent<Light>();
        Finish1 = GameObject.Find("Back_Wall (3)");
        Finish2 = GameObject.Find("Back_Wall (4)");
        Finish3 = GameObject.Find("FloorToCopy (30)");
        LastWords = GameObject.Find("Touch Last Char");
        Finish1.SetActive(false);
        Finish2.SetActive(false);
        Finish3.SetActive(false);
        LastWords.SetActive(false);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            GameObject.Find("Player").GetComponent<PlayerMovement>().IsGrounded = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Finish")
        {
            GameObject.Find("Player").GetComponent<GameOver>().IsLastChance = true;
            GameObject.Find("DemonicAltar3").GetComponent<DemonicAltarController>().SpawnWallOfDeath = true;

            Finish1.SetActive(true);
            Finish2.SetActive(true);
            Finish3.SetActive(true);
            LastWords.SetActive(true);


            //if (DieCameraLight.intensity <= 10f)
            //{
            //    DieCameraLight.intensity += 0.075f;
            //}
            //else
            //{
            //    DieCameraLight.intensity = 0;
            //    this.gameObject.GetComponent<GameOver>().IsGameOver = true;
            //
            //}
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "WOD")
        {
            if (DieCameraLight.intensity <= 10f)
            {
                DieCameraLight.intensity += 0.075f;
            }
            else
            {
                DieCameraLight.intensity = 0;
                this.gameObject.GetComponent<GameOver>().IsGameOver = true;
                //Debug.Log("You died!");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "WOD")
        {
            //Debug.Log("Stop Triggered");
            DieCameraLight.intensity = 0;
        }
    }

}
