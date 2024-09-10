using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	private AudioSource music;
    public int score = 0;
    private int numCoinsCollected = 0;
    public int numCoinsInLevel = 3;

    public Scorebar scorebar;
	
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
    }

    public int GetCoins() {
        return numCoinsCollected;
    }

}
