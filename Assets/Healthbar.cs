using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    public Slider slider;
    public Image fillArea;
    private int totalHealth = 10;

    // Start is called before the first frame update
    void Start()
    {
        slider.value = totalHealth;
        fillArea.color = Color.green;
    }

    // Update is called once per frame
    void Update()
    {
        
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
