using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerHealth : MonoBehaviour {

	int maxHealth = 100;
	public static float life = 100;
	public static bool inFight = false;

	float healthBarLength;
	float xPosi;

	// Use this for initialization
	void Start () {   
		healthBarLength = Screen.width/2;  
		xPosi = Screen.width/4;  
		maxHealth = Convert.ToInt32(life);
	}

	// Update is called once per frame
	void FixedUpdate () {
		if (inFight) {
			life=life-0.1f;

			//max 1 behind .
			life=Convert.ToInt32(life*10f)/10f;
		}
	}

	void OnGUI () {
		// Create one Group to contain both images
		// Adjust the first 2 coordinates to place it somewhere else on-screen
		GUI.BeginGroup (new Rect (xPosi,0, healthBarLength,32));

		// Draw the background image
		GUI.Box (new Rect (0,0, healthBarLength,32), life+"%");

		// Create a second Group which will be clipped
		// We want to clip the image and not scale it, which is why we need the second Group
		GUI.BeginGroup (new Rect (0,0, life / maxHealth * healthBarLength, 32));

		// Draw the foreground image
		GUI.Box (new Rect (0,0,healthBarLength,32), life+"%");

		// End both Groups
		GUI.EndGroup ();

		GUI.EndGroup ();
	}

}