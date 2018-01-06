using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float distance = 5f;
    public Camera camera;
	// Use this for initialization
    bool walk = false;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update() {
        // if Controller is touched move in camera direction
        if (walk) transform.position = transform.position + Camera.main.transform.forward * distance * Time.deltaTime;

        if (GvrControllerInput.AppButtonDown) walk = true;
        else if (GvrControllerInput.AppButtonUp) walk = false;
    }
}
