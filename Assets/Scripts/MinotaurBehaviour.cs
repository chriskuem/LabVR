using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinotaurBehaviour : MonoBehaviour {

	Transform target;
	int damping=2;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (target == null) {
			//player
			target = GameObject.Find ("Player").transform;

		} else {

			//check distance to player, if small --> attack
			float dist = Vector3.Distance(target.position, transform.position);

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
	}
}
