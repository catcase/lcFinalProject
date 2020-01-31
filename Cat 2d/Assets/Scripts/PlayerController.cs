using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 6.0f;
    private float rotSpeed = 280f;
    private float shipBound = 0.5f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        //ROTATE the ship
        Quaternion rot = transform.rotation;
        float z = rot.eulerAngles.z;
        z -= Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;
        rot = Quaternion.Euler(0, 0, z);
        transform.rotation = rot;

        //MOVE the ship
        Vector3 pos = transform.position;
        Vector3 velocity = new Vector3(0, Input.GetAxis("Vertical") * speed * Time.deltaTime, 0);
        pos += rot * velocity;
        transform.position = pos;

        //Restrict player to camera boundaries (top & bottom)
        if (pos.y + shipBound > Camera.main.orthographicSize)
        {
            pos.y = Camera.main.orthographicSize - shipBound;
        }
        if (pos.y - shipBound < -Camera.main.orthographicSize)
        {
            pos.y = -Camera.main.orthographicSize + shipBound;
        }

        //restrict player to bounds (left & right)
        float screenRatio = (float)Screen.width / (float)Screen.height;
        float widthOrtho = Camera.main.orthographicSize * screenRatio;

        if (pos.x + shipBound > widthOrtho)
        {
            pos.x = widthOrtho - shipBound;
        }
        if (pos.x - shipBound < -widthOrtho)
        {
            pos.x = -widthOrtho + shipBound;
        }

        transform.position = pos;
    }
}
