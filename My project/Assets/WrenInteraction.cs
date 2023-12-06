using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrenInteraction : MonoBehaviour
{
    public GameObject FloatingEPrefab;
    public AudioSource Piano;   //Tarkista että oikea käytössä, vink unityforum
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="Interactable")
        {
            Debug.Log("Wren huomasi Esineen");

            if (other.gameObject.name == "pianoWren")
            {
                Debug.Log("Piano tos!");
                //PlayAudio diipadaapa
            }
            /* 
             * if(other.gameObject.name == "Television")
             * {
             *      Debug.Log("Telkkari tos!");
             * }
             */
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
