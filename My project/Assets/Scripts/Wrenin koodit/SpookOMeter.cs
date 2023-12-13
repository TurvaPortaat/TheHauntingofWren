using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SpookOMeter : MonoBehaviour
{

    public Slider mySlider;

    int maksimi = 100;

    void Start()
    {
        

        mySlider.value = 0;

        if (mySlider == null)
        {
            Debug.LogError("Slider is not assigned!");
        }
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.E))
        {
            mySlider.value += 10;

            //if (mySlider.value > mySlider.maxValue) 
            //{
            //    mySlider.value = mySlider.maxValue;
            //}
        }


        if (mySlider.value == maksimi)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
        }
    }


    //public void IncreaseSpookLevel()
    //{
    //spookLevel += 5; // Voit s‰‰t‰‰ kasvum‰‰r‰‰ tarpeidesi mukaan
    //Debug.Log($"Spook-o-meter kasvoi! Uusi taso: {spookLevel}");
    // Voit lis‰t‰ t‰ss‰ muita toimintoja mittarin kasvattamisen yhteydess‰
    //}
}
