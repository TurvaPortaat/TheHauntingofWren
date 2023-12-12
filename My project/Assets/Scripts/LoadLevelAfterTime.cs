using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevelAfterTime : MonoBehaviour
{
    [SerializeField]
    private float delayBeforeLoading = 10f;
    [SerializeField]
    private string scenNameToLoad;

    private float timeElapsed;
    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }
    private void Update()
    {
        timeElapsed += Time.deltaTime;

        if(timeElapsed > delayBeforeLoading )
        {
            SceneManager.LoadScene(3);
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

