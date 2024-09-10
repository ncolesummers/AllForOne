using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
	private AudioSource music;
    public int score = 0;
    private int numCoinsCollected = 0;
    public int numCoinsInLevel = 3;

    public Scorebar scorebar;
    public TextMeshProUGUI winMessage;
    public GameObject gameOverScreen;
	
    void Start() {
		music = GetComponent<AudioSource>();
    }
	void Update() {
		music.loop = true;
    }

    public void AddScore(int value) {
        score += value;
        numCoinsCollected++;
        scorebar.UpdateScorebar(numCoinsCollected);
        CheckEndGame();
    }

    public int GetCoins() {
        return numCoinsCollected;
    }


    public void CheckEndGame()
	{
        if (numCoinsCollected == numCoinsInLevel)
		{
            EndGame();
		}
	}

    public void EndGame()
	{
        if (numCoinsCollected == numCoinsInLevel)
        {
            winMessage.SetText("You Won");
        }else
		{
            winMessage.SetText("You lost");
		}

        gameOverScreen.SetActive(true);
        Time.timeScale = 0;
    }
}
