using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour

{
    private int enemyHealth = 1;
    private GameManager gameManager;

    void Start()
    {
        gameManager = GameObject.Find("Score").GetComponent<GameManager>();
    }

        void OnTriggerEnter2D()
    {
        enemyHealth--;
    }

    void Update()
    {
        if (enemyHealth <= 0)
        {
            YouDead();
        }
    }

    void YouDead()
    {
        Destroy(gameObject);
        gameManager.UpdateScore(5);
    }
}
