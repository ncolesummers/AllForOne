using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{

    public GameObject gameManagerObject;
    public GameManager gameManager;
    private int coinValue = 1;

    void Start() {
        gameManagerObject = GameObject.FindWithTag("GameController");
        if (gameManagerObject != null) {
            gameManager = gameManagerObject.GetComponent<GameManager>();
        }
        else {
            Debug.LogError("Game Manager not found :(");
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            if (gameManager != null) {
                gameManager.AddScore(coinValue);
                gameObject.SetActive(false);
            }
        }
    }

}
