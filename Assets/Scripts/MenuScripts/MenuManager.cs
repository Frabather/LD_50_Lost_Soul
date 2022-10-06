using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using Image = UnityEngine.UI.Image;

public class MenuManager : MonoBehaviour
{
    private GameObject StartButton;
    private Button StartComponent;
    private GameObject QuitButton;
    private Button QuitComponent;
    private float rotateStart = 0f;
    private bool ascencing = true;


    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        StartButton = GameObject.Find("StartButton");
        StartComponent = StartButton.GetComponent<Button>();
        StartComponent.onClick.AddListener(StartGame);

        QuitButton = GameObject.Find("QuitButton");
        QuitComponent = QuitButton.GetComponent<Button>();
        QuitComponent.onClick.AddListener(QuitGame);
    }

    // Update is called once per frame
    void Update()
    {
        if (rotateStart < 5f && ascencing)
        {
            StartButton.GetComponent<RectTransform>().rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, rotateStart);
            QuitButton.GetComponent<RectTransform>().rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, -rotateStart);
            rotateStart = rotateStart + 0.05f;
            if (rotateStart >= 5)
            {
                ascencing = false;
            }
        }
        if (!ascencing)
        {
            StartButton.GetComponent<RectTransform>().rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, rotateStart);
            QuitButton.GetComponent<RectTransform>().rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, -rotateStart);
            rotateStart = rotateStart - 0.05f;
            if (rotateStart <= -5f)
            {
                ascencing = true;
            }
        }
    }

    void StartGame()
    {
        StartButton.SetActive(false);
        QuitButton.SetActive(false);

        SceneManager.UnloadScene("MenuScene");
        SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
    }

    void QuitGame()
    {
        Application.Quit();
    }

}
