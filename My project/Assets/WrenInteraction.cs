using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrenInteraction : MonoBehaviour
{
    public GameObject FloatingEPrefab;
    private FloatingE floatingEScript;
    public AudioSource Piano;
    public AudioSource Vessa;
    public AudioSource Fridge;
    public AudioSource Boxes;
    public AudioSource Hella;
    public AudioSource Television;
    public AudioSource Sink;
    public AudioSource Kaappi;
    //public float soundDuration = 10f;

    public GameObject spookOMeterGameObject;
    private SpookOMeter spookOMeter;

    private bool canInteract = false;

    private void Start()
    {
        // Alusta FloatingE-skripti
        floatingEScript = FloatingEPrefab.GetComponent<FloatingE>();

        if (floatingEScript == null)
        {
            Debug.LogError("FloatingE-skripti puuttuu!");
        }
        // Alusta spookOMeter
        spookOMeter = spookOMeterGameObject.GetComponent<SpookOMeter>();

        if (spookOMeter == null)
        {
            Debug.LogError("SpookOMeter-komponentti puuttuu!");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Interactable"))
        {
            Debug.Log("Wren huomasi Esineen " + other.gameObject.name);

            // Lis‰‰ FloatingE-n‰kyvyyden p‰ivitys t‰h‰n
            UpdateFloatingEVisibility(true);

            canInteract = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Interactable"))
        {
            // P‰ivit‰ FloatingE-n‰kyvyys pois p‰‰lt‰, kun Wren poistuu colliderista
            UpdateFloatingEVisibility(false);

            canInteract = false;
        }
    }

    private void Update()
    {
        if (canInteract && Input.GetKeyDown(KeyCode.E))
        {
            // Suorita interaktio vain, jos pelaaja voi vuorovaikuttaa ja painaa E-n‰pp‰int‰
            PerformInteraction();
        }
    }

    private void PerformInteraction()
    {
        if (spookOMeter != null)
        {
            // Tarkista ensin, onko "NPC1" tai "NPC2" "4NPC" objektin colliderissa
            Collider[] npcColliders = Physics.OverlapBox(spookOMeterGameObject.transform.position, spookOMeterGameObject.transform.localScale / 2f);
            bool hasNPC1 = false;
            bool hasNPC2 = false;

            foreach (Collider npcCollider in npcColliders)
            {
                if (npcCollider.CompareTag("NPC1"))
                {
                    hasNPC1 = true;
                }
                else if (npcCollider.CompareTag("NPC2"))
                {
                    hasNPC2 = true;
                }
            }

            if (hasNPC1 || hasNPC2)
            {
                // Soita ‰‰niefekti vain vuorovaikutukselliselle objektille
                PlayInteractionSound();

                // Lis‰‰ mittarin kasvattamisen koodi t‰h‰n
                for (float timer = 0; timer < 5f; timer += Time.deltaTime)
                {
                    spookOMeter.IncreaseSpookLevel();
                    // Keskeyt‰ looppi heti kun mittari on kasvatettu
                    return;
                }
            }
        }
        else
        {
            Debug.LogError("SpookOMeter-komponentti puuttuu!");
        }
    }

    private void PlayInteractionSound()
    {
        Debug.Log("Trying to play sounds...");
        // Tarkista jokainen AudioSource ja soita siihen liitetty ‰‰niefekti
        if (Piano != null && !Piano.isPlaying)
        {
            Debug.Log("Playing Piano sound...");
            Piano.Play();
        }

        if (Vessa != null && !Vessa.isPlaying)
        {
            Debug.Log("Playing Vessa sound...");
            Vessa.Play();
        }

        if (Fridge != null && !Fridge.isPlaying)
        {
            Debug.Log("Playing Fridge sound...");
            Fridge.Play();
        }

        if (Boxes != null && !Boxes.isPlaying)
        {
            Debug.Log("Playing Boxes sound...");
            Boxes.Play();
        }

        if (Hella != null && !Hella.isPlaying)
        {
            Debug.Log("Playing Hella sound...");
            Hella.Play();
        }

        if (Television != null && !Television.isPlaying)
        {
            Debug.Log("Playing Television sound...");
            Television.Play();
        }

        if (Sink != null && !Sink.isPlaying)
        {
            Debug.Log("Playing Sink sound...");
            Sink.Play();
        }

        if (Kaappi != null && !Kaappi.isPlaying)
        {
            Debug.Log("Playing Kaappi sound...");
            Kaappi.Play();
        }
}

    private void UpdateFloatingEVisibility(bool isVisible)
    {
        if (FloatingEPrefab != null)
        {
            FloatingE floatingEScript = FloatingEPrefab.GetComponent<FloatingE>();
            if (floatingEScript != null)
            {
                floatingEScript.SetFloatingEVisibility(isVisible);
            }
            else
            {
                Debug.LogError("FloatingE-skripti puuttuu FloatingE-objektista!");
            }
        }
        else
        {
            Debug.LogError("FloatingE-objekti puuttuu!");
        }
    }
}
