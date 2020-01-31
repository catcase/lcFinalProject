using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBeam : MonoBehaviour
{

    public GameObject bulletPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {

            Vector3 offset = transform.rotation * new Vector3(0, 1f, 0);

            GameObject bullet = Instantiate(bulletPrefab, transform.position + offset, transform.rotation);
            bullet.layer = gameObject.layer;
            
        }

    }
}
