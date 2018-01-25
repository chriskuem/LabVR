using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MinotaurBehaviour : MonoBehaviour {

	Transform target;
	int damping=2;

	float life=50;

	bool isDead=false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (life <= 0) {
			//death of minotaur
			if (!isDead) {
				gameObject.GetComponent<Animator> ().Play ("Death1");
				isDead = true;
			}
			PlayerHealth.inFight = false;

		} else {
			
			if (target == null) {
				//player
				target = GameObject.Find ("Player").transform;

			} else {

				//check distance to player, if small --> attack
				float dist = Vector3.Distance (target.position, transform.position);

				//rotate into direction of player if far away
				if (dist > 0) {
					var lookPos = target.position - transform.position;
					lookPos.y = 0;
					var rotation = Quaternion.LookRotation (lookPos);
					transform.rotation = Quaternion.Slerp (transform.rotation, rotation, Time.deltaTime * damping);
				}

				//minotaur runs and attacks if player too close
				if (dist < 5) {

					//run until in front of player
					if (dist > 1) {
						float speed = 0.03f;
						transform.position = Vector3.MoveTowards (transform.position, target.position, speed);
						gameObject.GetComponent<Animator> ().Play ("Run");
					}
				//fight when close
				else {
						gameObject.GetComponent<Animator> ().Play ("Attack");
					}
				}
			}

			if (PlayerHealth.inFight) {
				life = life - 0.1f;

				//max 1 behind .
				life = Convert.ToInt32 (life * 10f) / 10f;
			} else {
				life = 50;
			}

		}
	}
}
