using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectDifficulty : MonoBehaviour
{
    public GameObject splashCanvas;
    public GameObject difficultySelectionCanvas;
    public Animator splashAnimator;
    public Animator difficultySelectAnimator;

    // Start is called before the first frame update
    void Start()
    {
        //splashAnimator.SetBool("isPlayPressed", false);
        difficultySelectAnimator.SetBool("difficultySelect", false);
        //splashCanvas.SetActive(true);
        //difficultySelectionCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play()
    {
        splashAnimator.SetBool("isPlayPressed", true);
        difficultySelectAnimator.SetBool("difficultySelect", true);
        //splashCanvas.SetActive(false);
        //difficultySelectionCanvas.SetActive(true);
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

    public void MediumModeSelection()
    {
        //timeRemaining = 20;
        MeteorSpawner.meteorSpeed = 10f;
        MeteorSpawner.timeBetweenSpawns = 1f;
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
