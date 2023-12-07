using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrenInteraction : MonoBehaviour
{
    public GameObject FloatingEPrefab;
    public AudioSource Piano;   //Tarkista ett‰ oikea k‰ytˆss‰, vink unityforum
    public float soundDuration = 10f;

    public SpookOMeter spookOMeter; //viitataan mittariin
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
                    //T‰ss‰ voi lis‰t‰ muita toimintoja myˆs pianoon
                    break;

                case "Television":
                    Debug.Log("Telkkari tos!");
                    //PlaySound(Television);
                    StartCoroutine(UpdateSpookOMeter());
                    //T‰ss‰ voi lis‰t‰ toimintoja telkkuu
                    break;

                case "fridgeWren":
                    Debug.Log("J‰‰kaappi tos!");
                    //PlaySound(Television);
                    StartCoroutine(UpdateSpookOMeter());
                    //T‰ss‰ voi lis‰t‰ toimintoja j‰‰kaappii
                    break;

                case "hellaWren":

                    Debug.Log("Hella tos!");
                    //PlaySound(Hella);
                    StartCoroutine(UpdateSpookOMeter());
                    //T‰ss‰ voi lis‰t‰ toimintoja
                    break;

                case "ekaKaappiWren":

                    Debug.Log("Eka kaappi tos!");
                    //PlaySound(Kaappi);
                    StartCoroutine(UpdateSpookOMeter());
                    //T‰ss‰ voi lis‰t‰ toimintoja
                    break;

                case "tokaKaappiWren":

                    Debug.Log("Toka kaappi tos!");
                    //PlaySound(Kaappi);
                    StartCoroutine(UpdateSpookOMeter());
                    //T‰ss‰ voi lis‰t‰ toimintoja
                    break;

                case "sinkWren":

                    Debug.Log("Sink tos!");
                    //PlaySound(Sink);
                    StartCoroutine(UpdateSpookOMeter());
                    //T‰ss‰ voi lis‰t‰ toimintoja
                    break;

                case "vessaWren":

                    Debug.Log("Vessa tos!");
                    //PlaySound(Vessa);
                    StartCoroutine(UpdateSpookOMeter());
                    //T‰ss‰ voi lis‰t‰ toimintoja
                    break;

                case "boxesWren":

                    Debug.Log("Laatikoit tos!");
                    //PlaySound(Boxes);
                    StartCoroutine(UpdateSpookOMeter());
                    //T‰ss‰ voi lis‰t‰ toimintoja
                    break;


                case "boxesWren2":

                    Debug.Log("Lis‰‰ laatikoit tos!");
                    //PlaySound(Boxes);
                    StartCoroutine(UpdateSpookOMeter());
                    //T‰ss‰ voi lis‰t‰ toimintoja
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
        yield return new WaitForSeconds(0.1f); // venaillaan ett‰ muutokset ehtii tapahtuu

        //P‰ivit‰ mittari

        if(spookOMeter != null) 
        {
            spookOMeter.IncreaseSpookLevel();
        }
        else
        {
            Debug.Log("Spook-o-meter puuttuu!");
        }
       
       
    }
    public class SpookOMeter : MonoBehaviour
    {
        private float spookLevel = 0f;

        public void IncreaseSpookLevel()
        {
            spookLevel += 1f; // Voit s‰‰t‰‰ kasvum‰‰r‰‰ tarpeidesi mukaan
            Debug.Log($"Spook-o-meter kasvoi! Uusi taso: {spookLevel}");
            // Voit lis‰t‰ t‰ss‰ muita toimintoja mittarin kasvattamisen yhteydess‰
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
