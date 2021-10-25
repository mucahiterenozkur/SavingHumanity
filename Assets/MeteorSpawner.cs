using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    public List<Transform> spawnPoints;
    public List<GameObject> meteors;

    // Start is called before the first frame update
    void Start()
    {
        List<int> whereToPlaced = new List<int>();

        for (int i = 0; i < 10; i++)
        {
            int randomPoint = Random.Range(0, 7);
            
            if (!whereToPlaced.Contains(randomPoint))
            {
                whereToPlaced.Add(randomPoint);
                Debug.Log(randomPoint);
                int randomMeteor = Random.Range(0, meteors.Count);
                Instantiate(meteors[randomMeteor], spawnPoints[randomPoint].position, spawnPoints[randomPoint].rotation, spawnPoints[randomPoint].transform);
            }
            
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
