using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public bool IsGameOver = false, IsLastChance = false;
    private GameObject RestartButton;
    private Button RestartComponent;

    private void Awake()
    {
        //Debug.Log(Screen.width);
        //Debug.Log(Screen.height);
        RestartButton = GameObject.Find("RestartGameButton");
        RestartComponent = RestartButton.GetComponent<Button>();
        RestartComponent.onClick.AddListener(RestartGame);
        RestartButton.SetActive(false);
    }
    void Update()
    {
        if (IsGameOver)
        {
            SoulHasBeenLost();
            IsGameOver = false;
        }
    }

    void SoulHasBeenLost()
    {
        if (!IsLastChance)
        {
            GameObject.Find("Player").GetComponent<Transform>().position = new Vector3(GameObject.Find("Player").GetComponent<Transform>().position.x, 700f, GameObject.Find("Player").GetComponent<Transform>().position.z - 15000f);
            GameObject.Find("Lose game").GetComponent<Transform>().position = new Vector3(GameObject.Find("Player").GetComponent<Transform>().position.x, 700f, GameObject.Find("Player").GetComponent<Transform>().position.z + 15000f);
            GameObject.Find("Player").GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
            GameObject.Find("Player").GetComponent<AudioSource>().clip = GameObject.Find("DeathAudioHolder").GetComponent<AudioSource>().clip;
            GameObject.Find("Player").GetComponent<AudioSource>().enabled = false;
            GameObject.Find("Player").GetComponent<AudioSource>().enabled = true;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            RestartButton.SetActive(true);
        }
        else
        {
            GameObject.Find("Player").GetComponent<Transform>().position = new Vector3(GameObject.Find("Player").GetComponent<Transform>().position.x, 700f, GameObject.Find("Player").GetComponent<Transform>().position.z - 15000f);
            GameObject.Find("Kindof Lose game").GetComponent<Transform>().position = new Vector3(GameObject.Find("Player").GetComponent<Transform>().position.x, 700f, GameObject.Find("Player").GetComponent<Transform>().position.z + 15000f);
            GameObject.Find("Player").GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
            GameObject.Find("Player").GetComponent<AudioSource>().clip = GameObject.Find("DeathAudioHolder").GetComponent<AudioSource>().clip;
            GameObject.Find("Player").GetComponent<AudioSource>().enabled = false;
            GameObject.Find("Player").GetComponent<AudioSource>().enabled = true;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            RestartButton.SetActive(true);
        }




    }


    void RestartGame()
    {  
        SceneManager.UnloadScene("GameScene");
        SceneManager.LoadScene("MenuScene", LoadSceneMode.Single);
    }
}
