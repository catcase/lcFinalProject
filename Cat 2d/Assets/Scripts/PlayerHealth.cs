using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour

{
    private int playerHealth = 1;
    private GameManager gameManager;

    void Start()
    {
        gameManager = GameObject.Find("Lives").GetComponent<GameManager>();

    }

        void OnTriggerEnter2D()
    {
        playerHealth--;
    }

    void Update()
    {
        if (playerHealth <= 0)
        {
            YouDead();
        }
    }

    void YouDead()
    {
        Destroy(gameObject);
        gameManager.UpdateLives(1);
    }
}
