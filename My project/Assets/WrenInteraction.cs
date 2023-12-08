using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrenInteraction : MonoBehaviour
{
    public GameObject FloatingEPrefab;
    public AudioSource Piano;   //Tarkista että oikea käytössä, vink unityforum
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
                    //Tässä voi lisätä muita toimintoja myös pianoon
                    break;

                case "Television":
                    Debug.Log("Telkkari tos!");
                    //PlaySound(Television);
                    StartCoroutine(UpdateSpookOMeter());
                    //Tässä voi lisätä toimintoja telkkuu
                    break;

                case "fridgeWren":
                    Debug.Log("Jääkaappi tos!");
                    //PlaySound(Television);
                    StartCoroutine(UpdateSpookOMeter());
                    //Tässä voi lisätä toimintoja jääkaappii
                    break;

                case "hellaWren":

                    Debug.Log("Hella tos!");
                    //PlaySound(Hella);
                    StartCoroutine(UpdateSpookOMeter());
                    //Tässä voi lisätä toimintoja
                    break;

                case "ekaKaappiWren":

                    Debug.Log("Eka kaappi tos!");
                    //PlaySound(Kaappi);
                    StartCoroutine(UpdateSpookOMeter());
                    //Tässä voi lisätä toimintoja
                    break;

                case "tokaKaappiWren":

                    Debug.Log("Toka kaappi tos!");
                    //PlaySound(Kaappi);
                    StartCoroutine(UpdateSpookOMeter());
                    //Tässä voi lisätä toimintoja
                    break;

                case "sinkWren":

                    Debug.Log("Sink tos!");
                    //PlaySound(Sink);
                    StartCoroutine(UpdateSpookOMeter());
                    //Tässä voi lisätä toimintoja
                    break;

                case "vessaWren":

                    Debug.Log("Vessa tos!");
                    //PlaySound(Vessa);
                    StartCoroutine(UpdateSpookOMeter());
                    //Tässä voi lisätä toimintoja
                    break;

                case "boxesWren":

                    Debug.Log("Laatikoit tos!");
                    //PlaySound(Boxes);
                    StartCoroutine(UpdateSpookOMeter());
                    //Tässä voi lisätä toimintoja
                    break;


                case "boxesWren2":

                    Debug.Log("Lisää laatikoit tos!");
                    //PlaySound(Boxes);
                    StartCoroutine(UpdateSpookOMeter());
                    //Tässä voi lisätä toimintoja
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
        // Ei odotusta tässä vaiheessa, ellei tarvita
        // Odota halutun ajan vain, jos on erityinen syy

        // Päivitä SpookOMeter-objektia, jos se on liitetty
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
