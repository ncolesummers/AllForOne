using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public int score = 0;
    private int numCoinsCollected = 0;
    // public int numCoinsInLevel = 25;

    public void AddScore(int value) {
        score += value;
        numCoinsCollected++;
    }

    public int GetCoins() {
        return numCoinsCollected;
    }

}
