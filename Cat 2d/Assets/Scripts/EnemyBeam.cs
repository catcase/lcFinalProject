using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBeam : MonoBehaviour
{

    public GameObject bulletPrefab;

    private float fireDelay = 1;
    private float cooldown = 2;

    Transform player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (player == null)
        {
            //find player ship
            GameObject gameOb = GameObject.Find("Player");

            if (gameOb != null)
            {
                player = gameOb.transform;
            }

        }

        cooldown -= Time.deltaTime;

        if (cooldown <= 0 && player != null && Vector3.Distance(transform.position, player.position) < 4)
        {
            cooldown = fireDelay;

            Vector3 offset = transform.rotation * new Vector3(0, 1f, 0);
            GameObject bullet = Instantiate(bulletPrefab, transform.position + offset, transform.rotation);
            bullet.layer = gameObject.layer;
        }
    }
}
