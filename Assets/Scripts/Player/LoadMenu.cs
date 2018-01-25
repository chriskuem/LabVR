using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMenu : MonoBehaviour {

    void Start () {	}
	
	// Update is called once per frame
	void Update() {

        if (GvrControllerInput.AppButtonDown) SceneManager.LoadScene(0, LoadSceneMode.Single);

    }
    
}