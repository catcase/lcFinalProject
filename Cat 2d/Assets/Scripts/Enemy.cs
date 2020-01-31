using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float rotSpeed = 90f;
    private float moveSpeed = 3f;
    Transform player;

    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {
        MoveSpeed();

        if (player == null)
        {
            //find player ship
            GameObject gameOb = GameObject.Find("Player");

            if (gameOb != null)
            {
                player = gameOb.transform;
            }

        }
        //player is found or does not exist

        if (player == null)
        {
            return;
        }

        //player is found - turn to face

        Vector3 direction = player.position - transform.position;
        direction.Normalize();

        //funky math to cause enemy to face player
        float zAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;

        Quaternion enemyRot = Quaternion.Euler(0, 0, zAngle);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, enemyRot, rotSpeed * Time.deltaTime);
    }

    void MoveSpeed()
    {
        Vector3 pos = transform.position;
        Vector3 velocity = new Vector3(0, moveSpeed * Time.deltaTime, 0);
        pos += transform.rotation * velocity;

        transform.position = pos;
    }
}