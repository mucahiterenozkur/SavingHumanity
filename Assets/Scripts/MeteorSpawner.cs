using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    public List<Transform> spawnPoints;
    public List<GameObject> meteors;
    public float meteorSpeed;

    //private float timeToSpawn = 2f;
    //public float timeBetweenSpawns = 1f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnMeteor());
    }

    void Update()
    {
        //if(Time.time >= timeToSpawn)
        //{
        //    SpawnMeteor();
        //    timeToSpawn = Time.time + timeBetweenSpawns;
        //}
    }

    IEnumerator SpawnMeteor()
    {
        //Debug.Log("co worked");
        List<int> whereToPlaced = new List<int>();

        for (int i = 0; i < 10; i++)
        {
            int randomPoint = Random.Range(0, 7);

            if (!whereToPlaced.Contains(randomPoint))
            {
                whereToPlaced.Add(randomPoint);
                //Debug.Log(randomPoint);
                int randomMeteor = Random.Range(0, meteors.Count);
                GameObject meteor = Instantiate(meteors[randomMeteor], spawnPoints[randomPoint].position, spawnPoints[randomPoint].rotation, spawnPoints[randomPoint].transform) as GameObject;
                meteor.GetComponent<Rigidbody2D>().velocity = Vector2.left * meteorSpeed; // dont put time.deltatime here because it affects the velocity of meteors.
                //Debug.Log(meteor.GetComponent<Rigidbody2D>().velocity);
            }

        }

        yield return new WaitForSeconds(2f);

        StartCoroutine(SpawnMeteor());

    }


}
