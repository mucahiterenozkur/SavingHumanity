using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using EZCameraShake;

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
    public GameObject winCanvas;

    private int numberForCameraShake;


    // Start is called before the first frame update
    void Start()
    {
        meteorSpawner = FindObjectOfType<MeteorSpawner>();

        //timerIsRunning = true;
        slider.value = totalHealth;
        fillArea.color = Color.green;

        inGameCanvas.SetActive(true);
        gameOverCanvas.SetActive(false);
        winCanvas.SetActive(false);

        numberForCameraShake = 0;
    }

    // Update is called once per frame
    void Update()
    {

        if (MeteorSpawner.iscountDownFinished)
        {
            timerIsRunning = true;
            if (timerIsRunning)
            {
                if (timeRemaining > 0 && slider.value > 0)
                {
                    timeRemaining -= Time.deltaTime;
                    DisplayTime(timeRemaining);
                }
                else
                {
                    //make the gameover or gamewin conditions
                    Debug.Log("Time has run out!");
                    timeRemaining = 0;
                    timerIsRunning = false;

                    if (slider.value > 0)
                    {
                        winCanvas.SetActive(true);
                    }
                    else
                    {
                        //CameraShaker.Instance.ShakeOnce(4f, 1f, 1f, 1f);
                        numberForCameraShake++;
                        if(numberForCameraShake == 1)
                        {
                            //Debug.Log("here");
                            CameraShaker.Instance.ShakeOnce(10f, 10f, 0.1f, 1f);
                            numberForCameraShake++;
                        }
                        
                        gameOverCanvas.SetActive(true);
                        
                    }

                }
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
            if (timerIsRunning)
            {
                totalHealth--;
                slider.value = totalHealth;
                Debug.Log(slider.value);
            }

            if(slider.value == 0)
            {
                //do gameover condition.
                fillArea.color = Color.red;
            }
        }
    }

    public void PlayAgain()
    {
        
        SceneManager.LoadScene("Game");
        
    }

    public void MainMenu()
    {
        //MeteorSpawner.iscountDownFinished = false;
        SceneManager.LoadScene("Splash");
        
    }

   
}
