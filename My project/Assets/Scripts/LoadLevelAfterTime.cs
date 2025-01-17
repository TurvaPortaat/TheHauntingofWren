using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadLevelAfterTime : MonoBehaviour
{
    [SerializeField]
    private float delayBeforeLoading = 10f;
    [SerializeField]
    private string scenNameToLoad;

    private float timeElapsed;

    public Button skipButton; // Reference to the skip button in the Unity Editor

    private void Start()
    {
        // Add a listener to the skip button to call the LoadNextLevel method when clicked
        if (skipButton != null)
        {
            skipButton.onClick.AddListener(LoadNextLevel);
        }
    }

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    private void Update()
    {
        timeElapsed += Time.deltaTime;

        if (timeElapsed > delayBeforeLoading)
        {
            SceneManager.LoadScene(1);
        }
        else if (Input.GetMouseButtonDown(0))
        {
            LoadNextLevel();
        }
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(levelIndex);
    }
}
