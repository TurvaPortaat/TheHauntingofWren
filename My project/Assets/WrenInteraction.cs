using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrenInteraction : MonoBehaviour
{
    public GameObject FloatingEPrefab;
    public AudioSource Piano;   //Tarkista ett‰ oikea k‰ytˆss‰, vink unityforum
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
             
            if(other.gameObject.name == "Television")
            {
                Debug.Log("Telkkari tos!");
               //trigger event -> animation and sound
            }

            if(other.gameObject.name == "fridgeWren")
            {
               Debug.Log("J‰‰kaappi tos!");
            }

            if (other.gameObject.name == "hellaWren")
            {
                Debug.Log("Hella tos!");
            }

            if (other.gameObject.name == "ekaKaappiWren")
            {
                Debug.Log("Eka kaappi tos!");
            }

            if (other.gameObject.name == "tokaKaappiWren")
            {
                Debug.Log("Toka kaappi tos!");
            }

            if (other.gameObject.name == "sinkWren")
            {
                Debug.Log("Sink tos!");
            }

            if (other.gameObject.name == "vessaWren")
            {
                Debug.Log("Vessa tos!");
            }

            if (other.gameObject.name == "boxesWren")
            {
                Debug.Log("Laatikoit tos!");
            }

            if (other.gameObject.name == "boxesWren2")
            {
                Debug.Log("Lis‰‰ laatikoit tos!");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
