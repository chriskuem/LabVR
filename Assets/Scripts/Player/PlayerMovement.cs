using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float distance = 5f;
    public Camera camera;

    int controllerMode = -1;

	void Start () {
		this.controllerMode = PlayerPrefs.GetInt("controllerMode");
	}
	
	// Update is called once per frame
	void Update() {

        if (controllerMode == 0) {
            // steady walk
            if (GvrControllerInput.IsTouching) transform.position = transform.position + Camera.main.transform.forward * distance * Time.deltaTime;
        } else if (controllerMode == 1) {
            // teleport
            gameObject.transform.GetChild(1).GetChild(0).gameObject.active = true;
        } else if (controllerMode == 2) {
            // tunneling
            gameObject.transform.GetChild(0).gameObject.active = true;
        }

    }
}
