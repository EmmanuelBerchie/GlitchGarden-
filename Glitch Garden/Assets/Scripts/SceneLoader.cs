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
   

    public void LoadNextScene()
    {
     SceneManager.LoadScene(currentSceneIndex + 1); 
    } 

    IEnumerator gameDelay()
    {
      
        yield return new WaitForSeconds(timeToWait);
        LoadNextScene();
    }


}

