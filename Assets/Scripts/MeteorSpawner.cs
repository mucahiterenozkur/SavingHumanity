using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MeteorSpawner : MonoBehaviour
{
    public List<Transform> spawnPoints;
    public List<GameObject> meteors;
    public static float meteorSpeed = 10;
    public static float timeBetweenSpawns = 2f;

    private float countDownNumber = 3;
    public TextMeshProUGUI countDownText;
    public static bool iscountDownFinished = false;

    //private float timeToSpawn = 2f;
    //public float timeBetweenSpawns = 1f;

    // Start is called before the first frame update
    void Start()
    {
        countDownNumber = 3;
        countDownText.text = countDownNumber.ToString();

        if (iscountDownFinished)
        {
            iscountDownFinished = false;
        }

        //if (iscountDownFinished)
        //{
        //    StartCoroutine(SpawnMeteor());
        //}
        
    }

    void Update()
    {       
        if (!iscountDownFinished)
        {
            //Debug.Log("worked");
            countDownNumber -= Time.deltaTime;
            countDownText.text = countDownNumber.ToString("0");

            if (countDownNumber <= 0)
            {
                countDownText.gameObject.SetActive(false);
                iscountDownFinished = true;
                StartCoroutine(SpawnMeteor());
                

            }
            

        }


        //if(Time.time >= timeToSpawn)
        //{
        //    SpawnMeteor();
        //    timeToSpawn = Time.time + timeBetweenSpawns;
        //}
    }

    public IEnumerator SpawnMeteor()
    {
        //Debug.Log("co worked");

        if (Healthbar.timerIsRunning)
        {
            List<int> whereToPlaced = new List<int>();

            for (int i = 0; i < 7; i++)
            {
                int randomPoint = Random.Range(0, 5);

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
        }
        
        yield return new WaitForSeconds(timeBetweenSpawns);

        if (Healthbar.timerIsRunning)
        {
            StartCoroutine(SpawnMeteor());
        }
        
    }

}
