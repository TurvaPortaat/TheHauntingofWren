using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpookOMeter : MonoBehaviour
{

    public Slider mySlider;

    void Start()
    {
        if (mySlider == null)
        {
            Debug.LogError("Slider is not assigned!");
        }
    }

    void Update()
    {
        if(Input.GetKeyUp(KeyCode.E))
        {
            mySlider.value += 10;

            if (mySlider.value > mySlider.maxValue) 
            {
                mySlider.value = mySlider.maxValue;
            }
        }
    }


    //public void IncreaseSpookLevel()
    //{
    //spookLevel += 5; // Voit s‰‰t‰‰ kasvum‰‰r‰‰ tarpeidesi mukaan
    //Debug.Log($"Spook-o-meter kasvoi! Uusi taso: {spookLevel}");
    // Voit lis‰t‰ t‰ss‰ muita toimintoja mittarin kasvattamisen yhteydess‰
    //}
}
