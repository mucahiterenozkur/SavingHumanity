using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    private void Awake()
    {
        int numberOfAudioManagers = FindObjectsOfType<AudioManager>().Length;
        if (numberOfAudioManagers > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }

        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name.Equals("Game"))
        {
            Cursor.visible = false;   //open it when you are done with the game.
        }
        else
        {
            Cursor.visible = true;
        }
    }
}
