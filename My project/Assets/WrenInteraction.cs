using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public Slider spookOMeterSlider;

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

        // Poista kommentti t‰st‰, jotta spookOMeter otetaan k‰yttˆˆn
        //spookOMeter = spookOMeterGameObject.GetComponent<SpookOMeter>();

        if (spookOMeterSlider == null)
        {
            Debug.LogError("Slider-komponentti puuttuu!");
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
        else if (other.CompareTag("4NPC"))
        {
            Debug.Log("Wren entered 4NPC collider");
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
        else if (other.CompareTag("4NPC"))
        {
            Debug.Log("Wren exited 4NPC collider");
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
            case "sinkwren":
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
        Debug.Log("Playing interaction sound...");
        PlayInteractionSound(interactableName);

        // Tarkista pelaajan l‰hell‰ olevat colliderit
        Collider[] npcColliders = Physics.OverlapBox(transform.position, transform.localScale / 2f);

        // Tarkista, onko pelaaja (Wren) colliderissa
        bool wrenIsPresent = false;
        foreach (Collider npcCollider in npcColliders)
        {
            if (npcCollider.CompareTag("Wren")) // Oletan t‰ss‰, ett‰ pelaajan tagi on "Player", voit vaihtaa sen tarvittaessa
            {
                wrenIsPresent = true;
                break;
            }
        }

        // Jos pelaaja (Wren) on l‰sn‰, tarkista "4NPC" -tagattu objekti ja "NPC1" ja "NPC2" hahmot
        if (wrenIsPresent)
        {
            bool has4NPC = false;
            bool hasNPC1 = false;
            bool hasNPC2 = false;

            foreach (Collider npcCollider in npcColliders)
            {
                if (npcCollider.CompareTag("4NPC"))
                {
                    has4NPC = true;
                }
                else if (npcCollider.CompareTag("NPC1"))
                {
                    hasNPC1 = true;
                }
                else if (npcCollider.CompareTag("NPC2"))
                {
                    hasNPC2 = true;
                }
            }

            // Jos molemmat ehdot t‰yttyv‰t, lis‰‰ spook-o-meterin tasoa
            if (has4NPC && (hasNPC1 || hasNPC2))
            {
                spookOMeterSlider.value += 1; // T‰m‰ kasvattaa spook-o-meterin arvoa. Voit s‰‰t‰‰ arvoa tarpeidesi mukaan.
                Debug.Log("Increasing Spook Level!");
            }
            else
            {
                Debug.Log("Conditions not met for Spook-o-meter increase.");
            }
        }
        else
        {
            Debug.Log("Player (Wren) not present in colliders.");
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
