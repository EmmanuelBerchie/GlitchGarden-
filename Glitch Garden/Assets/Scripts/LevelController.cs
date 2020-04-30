using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] GameObject winLabel;
    [SerializeField] GameObject loseLabel; 
    [SerializeField] float waitToLoad = 4f;
    int numberOfAttackers = 0;
    bool levelTimerFinished = false;
    

    private void Start()
    {
        winLabel.SetActive(false);
        loseLabel.SetActive(false); 
    } 
    public void AttackerSpawned()
    {
        numberOfAttackers++; 
    }

    public void AttackerKilled()
    {
        numberOfAttackers--;

        if (numberOfAttackers <= 0 && levelTimerFinished)
        {
            Debug.Log("End Level now");
            StartCoroutine(HandleWinCondition());
        }
    }

    public void LevelTimerFinished()
    {
        levelTimerFinished = true;
        StopSpawners(); 
    }

    private void StopSpawners()
    {
        AttackerSpawner[] spawnerArray = FindObjectsOfType<AttackerSpawner>();
        foreach (AttackerSpawner spawner in spawnerArray)
        {
            spawner.StopSpwaning(); 
        }
    }

    IEnumerator HandleWinCondition()
    {
        winLabel.SetActive(true);
        GetComponent<AudioSource>().Play();
       
        yield return new WaitForSeconds(waitToLoad);
        
        FindObjectOfType<SceneLoader>().LoadNextScene();
    }

     public void YouLose()
    {
        StartCoroutine(HandleLoseCondition());
        
    }

    IEnumerator HandleLoseCondition()
    {
       

        yield return new WaitForSeconds(waitToLoad); 
        
        loseLabel.SetActive(true);
        Time.timeScale = 0; 

    }

}
