using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceSigns : MonoBehaviour {

	List<string> signContents;

	public GameObject signPref;

	// Use this for initialization
	void Start () {
		signContents.Add ("Test1");
		signContents.Add ("Test2");
		signContents.Add ("Test3");
		signContents.Add ("Test4");
		signContents.Add ("Test5");

		foreach (Transform child in gameObject.transform) {
			var placedSign = Instantiate (signPref, child.position, Quaternion.identity);
			placedSign.name = child.name+"_text";
			placedSign.transform.parent = child.gameObject.transform;
		}
	}
	
	// Update is called once per frame
	void Update () {
	}
}
