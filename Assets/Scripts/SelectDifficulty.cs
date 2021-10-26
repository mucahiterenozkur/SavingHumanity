using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectDifficulty : MonoBehaviour
{
    public GameObject splashCanvas;
    public GameObject difficultySelectionCanvas;

    // Start is called before the first frame update
    void Start()
    {
        splashCanvas.SetActive(true);
        difficultySelectionCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play()
    {
        splashCanvas.SetActive(false);
        difficultySelectionCanvas.SetActive(true);
        //maybe add anim
        //SceneManager.LoadScene("Game");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void EasyModeSelection()
    {
        //timeRemaining = 10;
        MeteorSpawner.meteorSpeed = 10f;
        MeteorSpawner.timeBetweenSpawns = 2f;
        SceneManager.LoadScene("Game");
    }

    public void HardModeSelection()
    {
        //timeRemaining = 20;
        MeteorSpawner.meteorSpeed = 10f;
        MeteorSpawner.timeBetweenSpawns = 1f;
        SceneManager.LoadScene("Game");
    }
}
