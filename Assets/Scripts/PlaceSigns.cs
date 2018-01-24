using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceSigns : MonoBehaviour {

	List<string> signContents = new List<string>();

	public GameObject signPref;

	// Use this for initialization
	void Start () {
		signContents.Add ("Test1");
		signContents.Add ("Test2");
		signContents.Add ("Test3");
		signContents.Add ("Test4");
		signContents.Add ("Test5");

		foreach (Transform child in gameObject.transform) {
			var placedSign = Instantiate (signPref, new Vector3(child.position.x, 0.3f, child.position.z), signPref.transform.rotation);
			placedSign.name = child.name+"_text";
			placedSign.transform.parent = child.gameObject.transform;

			GameObject gO = placedSign.transform.Find("Text").gameObject;
        	TextMesh tM = gO.GetComponent(typeof(TextMesh)) as TextMesh;
			tM.text = signContents[0];
		}
	}
	
	// Update is called once per frame
	void Update () {
	}
}
