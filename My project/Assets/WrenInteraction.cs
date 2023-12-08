using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrenInteraction : MonoBehaviour
{
    public GameObject FloatingEPrefab;
    public AudioSource Piano;   //Tarkista ett� oikea k�yt�ss�, vink unityforum
    public float soundDuration = 10f;

    public GameObject spookOMeterGameObject;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Interactable")
        {
            Debug.Log("Wren huomasi Esineen" + other.gameObject.name);

            switch (other.gameObject.name)
            {
                case "pianoWren":

                    Debug.Log("Piano tos!");
                    //PlaySound(Piano);
                    StartCoroutine(UpdateSpookOMeter());
                    //T�ss� voi lis�t� muita toimintoja my�s pianoon
                    break;

                case "Television":
                    Debug.Log("Telkkari tos!");
                    //PlaySound(Television);
                    StartCoroutine(UpdateSpookOMeter());
                    //T�ss� voi lis�t� toimintoja telkkuu
                    break;

                case "fridgeWren":
                    Debug.Log("J��kaappi tos!");
                    //PlaySound(Television);
                    StartCoroutine(UpdateSpookOMeter());
                    //T�ss� voi lis�t� toimintoja j��kaappii
                    break;

                case "hellaWren":

                    Debug.Log("Hella tos!");
                    //PlaySound(Hella);
                    StartCoroutine(UpdateSpookOMeter());
                    //T�ss� voi lis�t� toimintoja
                    break;

                case "ekaKaappiWren":

                    Debug.Log("Eka kaappi tos!");
                    //PlaySound(Kaappi);
                    StartCoroutine(UpdateSpookOMeter());
                    //T�ss� voi lis�t� toimintoja
                    break;

                case "tokaKaappiWren":

                    Debug.Log("Toka kaappi tos!");
                    //PlaySound(Kaappi);
                    StartCoroutine(UpdateSpookOMeter());
                    //T�ss� voi lis�t� toimintoja
                    break;

                case "sinkWren":

                    Debug.Log("Sink tos!");
                    //PlaySound(Sink);
                    StartCoroutine(UpdateSpookOMeter());
                    //T�ss� voi lis�t� toimintoja
                    break;

                case "vessaWren":

                    Debug.Log("Vessa tos!");
                    //PlaySound(Vessa);
                    StartCoroutine(UpdateSpookOMeter());
                    //T�ss� voi lis�t� toimintoja
                    break;

                case "boxesWren":

                    Debug.Log("Laatikoit tos!");
                    //PlaySound(Boxes);
                    StartCoroutine(UpdateSpookOMeter());
                    //T�ss� voi lis�t� toimintoja
                    break;


                case "boxesWren2":

                    Debug.Log("Lis�� laatikoit tos!");
                    //PlaySound(Boxes);
                    StartCoroutine(UpdateSpookOMeter());
                    //T�ss� voi lis�t� toimintoja
                    break;

                default:
                    Debug.Log("Tunnistamaton esine tos!");
                    break;

            }
        }
    }

    private void PlaySound(AudioSource audioSource)
    {
        if (audioSource != null)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        else
        {
            Debug.Log("AudioSource puuttuu!");
        }
    }

    private IEnumerator UpdateSpookOMeter()
    {
        // Ei odotusta t�ss� vaiheessa, ellei tarvita
        // Odota halutun ajan vain, jos on erityinen syy

        // P�ivit� SpookOMeter-objektia, jos se on liitetty
        if (spookOMeterGameObject != null)
        {
            SpookOMeter spookOMeter = spookOMeterGameObject.GetComponent<SpookOMeter>();
            if (spookOMeter != null)
            {
                spookOMeter.IncreaseSpookLevel();
            }
            else
            {
                Debug.LogError("SpookOMeter-komponentti puuttuu!");
            }
        }
        else
        {
            Debug.LogError("SpookOMeter-objekti puuttuu!");
        }

        yield return null;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
