using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PauseMenuUI : MonoBehaviour
{

//    public GameObject Hud;
    public bool hudOpen = false;
    public GameObject pauseMenuUI;
    //public GameObject button;
    //public TextMeshProUGUI hudText;
    //public GameObject gameManagerObject;
    //public GameManager gameManager;

    void Start() {
     //   gameManagerObject = GameObject.FindWithTag("GameController");
    }

    void Update() {
        if(Input.GetKeyDown(KeyCode.Tab)) {
            Debug.Log("Tab Pressed");
            if (!hudOpen) {
                closeHud();
            }
            else {
                openHud();
            }
        }
    }

    void openHud() {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        hudOpen = false;
    }

    void closeHud() {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        hudOpen = true;
    }
    public void PlayGame()
    {
        openHud();
    }

    public void RestartGame()
    {
        //add code for this
    }
    public void QuitGame()
    {
        Application.Quit();
    }

}
