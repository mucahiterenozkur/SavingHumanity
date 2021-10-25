using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteors : MonoBehaviour
{
    public GameObject explodeMeteorParticleEffect;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {

        if(other.gameObject.tag == "Bullet")
        {
            Debug.Log(other.gameObject.name);
            Destroy(gameObject);
            Destroy(other.gameObject);
            GameObject particle = Instantiate(explodeMeteorParticleEffect, other.transform.position, other.transform.rotation) as GameObject;
            Destroy(particle, 1f);
        }

        //if(other.gameObject.tag == "Earth")
        //{
        //    Debug.Log(other.gameObject.name);
        //    Destroy(gameObject);
        //    //Destroy(other.gameObject);
        //    //GameObject particle = Instantiate(explodeMeteorParticleEffect, other.transform.position, other.transform.rotation) as GameObject;
        //    //Destroy(particle, 1f);
        //}
        
    }
}
