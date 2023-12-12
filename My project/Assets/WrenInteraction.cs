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

    public GameObject spookOMeterGameObject;
    private SpookOMeter spookOMeter;
    private string interactableName;

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

            //Store the name of the interactable object
            interactableName = other.gameObject.name.ToLower();
            Debug.Log("Lowercased interactable name: " + interactableName);
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

    private void PlayInteractionSound(string interactableName)
    {
        Debug.Log("Trying to play sounds...");
        Debug.Log("Object name received: " + interactableName);

        // Vertaa objektin nime‰ case-insensitive
        switch (interactableName.ToLower())
        {
            case "pianowren":
                Debug.Log("Playing Piano sound...");
                PlaySound(Piano);
                break;

            case "television":
                Debug.Log("Playing Television sound...");
                PlaySound(Television);
                break;

            case "fridgewren":
                Debug.Log("Playing Fridge sound...");
                PlaySound(Fridge);
                break;

            case "boxeswren":
                Debug.Log("Playing Boxes sound...");
                PlaySound(Boxes);
                break;

            case "vessawren":
                Debug.Log("Playing Vessa sound...");
                PlaySound(Vessa);
                break;

            case "hellawren":
                Debug.Log("Playing Hella sound...");
                PlaySound(Hella);
                break;

            case "lavuaariwren":
                Debug.Log("Playing Sink sound...");
                PlaySound(Sink);
                break;

            case "ekakaappiwren":
            case "tokakaappiwren":
                Debug.Log("Playing Kaappi sound...");
                PlaySound(Kaappi);
                break;

            default:
                Debug.Log("Unknown interactable object!");
                break;
        }
    }

    private void PlaySound(AudioSource audioSource)
    {
        if (audioSource != null && !audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

    private void PerformInteraction()
    {
        // Soita ‰‰niefekti ja anna tarvittava argumentti (tag)
        if (canInteract)
        {
            //string interactableTag = gameObject.tag; // K‰yt‰ oikeaa tapaa hakea objektin tagi
            PlayInteractionSound(interactableName); // Varmista, ett‰ annat oikean tagin
        }

        if (spookOMeter != null)
        {
            // Tarkista, onko "NPC1" tai "NPC2" "4NPC" objektin colliderissa
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
                // Lis‰‰ mittarin kasvattamisen koodi t‰h‰n
                spookOMeter.IncreaseSpookLevel();
            }
        }
        else
        {
            Debug.LogError("SpookOMeter-komponentti puuttuu!");
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
                Debug.LogError("FloatingE- skripti puuttuu FloatingE-objektista!");
            }
        }
        else
        {
            Debug.LogError("FloatingE-objekti puuttuu!");
        }
    }
}
