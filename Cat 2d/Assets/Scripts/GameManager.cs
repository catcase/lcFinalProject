using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class GameManager : MonoBehaviour
{

    public TextMeshProUGUI lifeText;
    private int numLives;

    public TextMeshProUGUI scoreText;
    private int score;

    public TextMeshProUGUI gameOverText;

    public bool isGameActive;

    // Start is called before the first frame update
    void Start()
    {
        numLives = 3;
        UpdateLives(0);

        score = 0;
        UpdateScore(0);

        isGameActive = true;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateLives(int livesTaken)
    {
        numLives -= livesTaken;
        lifeText.text = "Lives: " + numLives;
         
        if (numLives == 0)
        {
            gameOverText.gameObject.SetActive(true);
            isGameActive = false;
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }
}
