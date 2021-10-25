using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Healthbar : MonoBehaviour
{
    private MeteorSpawner meteorSpawner;

    public Slider slider;
    public Image fillArea;
    private int totalHealth = 20;

    public TextMeshProUGUI timerText;
    public float timeRemaining = 120;
    public static bool timerIsRunning = false;

    public GameObject inGameCanvas;
    public GameObject gameOverCanvas;

    // Start is called before the first frame update
    void Start()
    {
        meteorSpawner = FindObjectOfType<MeteorSpawner>();

        timerIsRunning = true;
        slider.value = totalHealth;
        fillArea.color = Color.green;

        inGameCanvas.SetActive(true);
        gameOverCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                gameOverCanvas.SetActive(true);
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                timerIsRunning = false;
            }
        }
    }

    public void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Meteor")
        {
            totalHealth--;
            slider.value = totalHealth;
            Debug.Log(slider.value);

            if(slider.value == 0)
            {
                //do gameover condition.
                fillArea.color = Color.red;
            }
        }
    }
}
