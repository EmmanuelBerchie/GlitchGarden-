using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // setting master volume 
        PlayerPrefsController.SetMasterVolume(0.4f);
        // getting and confirming master volume from GetMaster volume
        Debug.Log(" Return value of " + PlayerPrefsController.GetMasterVolume()); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
