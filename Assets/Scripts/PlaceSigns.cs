using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlaceSigns : MonoBehaviour {

	List<string> signContents = new List<string>();
	List<int> rotationMap = new List<int>();

	public GameObject signPref;

	// Use this for initialization
	void Start () {
		
		signContents.Add ("Test1");
		signContents.Add ("Test2");
		signContents.Add ("Test3");
		signContents.Add ("Test4");
		signContents.Add ("Test5");
		signContents.Add ("Test6");
		signContents.Add ("Test7");
		signContents.Add ("Test8");
		signContents.Add ("Test9");
		signContents.Add ("Test10");
		signContents.Add ("Test11");
		signContents.Add ("Test12");
		signContents.Add ("Test13");
		signContents.Add ("Test14");
		signContents.Add ("Test15");
		signContents.Add ("Test16");
		signContents.Add ("Test17");
		signContents.Add ("Test18");
		signContents.Add ("Test19");
		signContents.Add ("Test20");
		signContents.Add ("Test21");
		signContents.Add ("Test22");
		signContents.Add ("Test23");
		signContents.Add ("Test24");
		signContents.Add ("Test25");
		signContents.Add ("Test26");
		signContents.Add ("Test27");
		signContents.Add ("Test28");
		signContents.Add ("Test29");
		signContents.Add ("Test30");
		signContents.Add ("Test31");
		signContents.Add ("Test32");
		signContents.Add ("Test33");
		signContents.Add ("Test34");
		signContents.Add ("Test35");


		foreach (Transform child in gameObject.transform) {
			var placedSign = Instantiate (signPref, new Vector3(child.position.x, 0.3f, child.position.z), signPref.transform.rotation);
			placedSign.name = child.name+"_text";
			placedSign.transform.parent = child.gameObject.transform;

			placedSign.transform.localRotation = Quaternion.identity;
			placedSign.transform.Rotate (new Vector3 (90, 0, 0));

			GameObject gO = placedSign.transform.Find("Text").gameObject;
        	TextMesh tM = gO.GetComponent(typeof(TextMesh)) as TextMesh;

			int index = Convert.ToInt32 (child.name.Replace ("Sign", "").Replace ("_wrongway", ""))-1;

			tM.text = signContents[index];
		}
	}
	
	// Update is called once per frame
	void Update () {
	}
}
