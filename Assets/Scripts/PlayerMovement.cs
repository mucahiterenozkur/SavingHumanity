using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public PlayerBulletController playerBulletController;
    public Transform bulletSpawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Vector2 newPos = new Vector2(transform.position.x, Mathf.Clamp(transform.position.y, -5, 5));
        //transform.position = newPos;

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            //transform.position = new Vector2(transform.position.x, (transform.position.y + speed * Time.deltaTime));
            transform.position = new Vector2(transform.position.x, Mathf.Clamp(transform.position.y + speed * Time.deltaTime,-5,5));
        }

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            //transform.position = new Vector2(transform.position.x, (transform.position.y - speed * Time.deltaTime));  
            transform.position = new Vector2(transform.position.x, Mathf.Clamp(transform.position.y - speed * Time.deltaTime, -5, 5));
        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {     
            Instantiate(playerBulletController, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        }
    }
}
