using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    int currentSceneIndex;
    [SerializeField] int timeToWait = 7;
     void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if( currentSceneIndex == 0)
        {
            StartCoroutine(gameDelay()); 
        }

        
    }
    public void RestartScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void LoadMainMenu() 
    {
        Time.timeScale = 1; 
        SceneManager.LoadScene("Start Scene");
    }

    public void LoadNextScene()
    {
     SceneManager.LoadScene(currentSceneIndex + 1); 
    } 

    public void LoadYouLose()
    {
        SceneManager.LoadScene("Game Over"); 
    }
    public void LoadOptions()
    {
        SceneManager.LoadScene("Options");
    }

    IEnumerator gameDelay()
    {
      
        yield return new WaitForSeconds(timeToWait);
        LoadNextScene();
    }

    public void Quit()
    {
        Application.Quit();  
    }



}

