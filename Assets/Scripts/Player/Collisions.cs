using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collisions : MonoBehaviour {

	Vector3 startPos;

	// Use this for initialization
	void Start () {
		startPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter (Collision col)
	{
		if(col.gameObject.name == "Spitze1"||col.gameObject.name == "Spitze2"||col.gameObject.name == "Stab"||col.gameObject.name == "Minotaur")
		{
			transform.position=startPos;
		}
	}
}
