using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collisions : MonoBehaviour {

	Vector3 startPos;
	Quaternion startRot;

	// Use this for initialization
	void Start () {
		startPos = transform.position;
		startRot = transform.rotation;

		// startRot = Quaternion.LookRotation (new Vector3(0,0,0)-transform.position);
		// transform.rotation = startRot;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(PlayerHealth.life<=0){
			transform.position = startPos;
			transform.rotation = startRot;
			PlayerHealth.inFight = false;
			PlayerHealth.life = 100;
		}
	}

	void OnCollisionEnter (Collision col)
	{
		if (col.gameObject.name == "Spitze1" || col.gameObject.name == "Spitze2" || col.gameObject.name == "Stab") {
			//schaden durch Fallen
			PlayerHealth.life = PlayerHealth.life - 20;

			//Zerstöre Falle nach Kollision
			if (col.gameObject.name == "Stab") {
				Destroy (col.gameObject);
			} else {
				//Zerstöre parent der Spitze --> Stab
				Destroy (col.gameObject.transform.parent.gameObject);
			}
		} 
		//Start damaging player while in fight (you cant run away from this)
		else if (col.gameObject.name == "Minotaur") {
			PlayerHealth.inFight = true;
		}
	}
}
