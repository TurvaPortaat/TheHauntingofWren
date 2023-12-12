using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    public GameObject pauseMenu;

    void Start()
    {
        // Alussa varmistetaan, että pauseMenu on piilotettu
        if (pauseMenu != null)
        {
            pauseMenu.SetActive(false);
        }
    }

    void Update()
    {
        // ESC-painikkeen painaminen
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePauseMenu();
        }
    }

    void TogglePauseMenu()
    {
        // Vaihda pause menun näkyvyys
        if (pauseMenu != null)
        {
            bool isPaused = !pauseMenu.activeSelf;
            pauseMenu.SetActive(isPaused);

            // Ajan hallinta
            if (isPaused)
            {
                // Peli on pausella
                Time.timeScale = 0;
            }
            else
            {
                // Peli ei ole pausella, jatka normaalisti
                Time.timeScale = 1;
            }
        }
    }
}
