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

		signContents.Add ("12.-13. Jh. v. Chr.: Fall Trojas");
		signContents.Add ("814 v. Chr.: Gründung Karthago");
		signContents.Add ("8. Jh. v. Chr.: Ilias & Odysee");
		signContents.Add ("753 v. Chr.: Gründung Roms");
		signContents.Add ("700 v. Chr.: „Werke und Tage“ – Hesiod");
		signContents.Add ("650-500 v. Chr.: Tyrannenherrschaften");
		signContents.Add ("561 v. Chr.: Beginn der Tyrannis " + System.Environment.NewLine + "des Peisistratos in Athen");
		signContents.Add ("550 v. Chr.: Peloponnesisches Bündnis " + System.Environment.NewLine + "unter der Führung Spartas");		
		signContents.Add ("510 v. Chr.: Ende der römischen Königszeit");
		signContents.Add ("490 v. Chr.: Marathon (Perserkriege)");
		signContents.Add ("480 v. Chr.: Salamis (Perserkriege)");
		signContents.Add ("480 v. Chr.: Sieg des Tyrannen Gelon " + System.Environment.NewLine + "von Syrakus über die Karthager");
		signContents.Add ("478/477 v. Chr.: Delisch-attischer " + System.Environment.NewLine + "Seebund wird gegründet, Athen übernimmt Führung");
		signContents.Add ("469-399 v. Chr.: Sokrates");
		signContents.Add ("461-451 v. Chr.: Erster peloponnesischer Krieg");
		signContents.Add ("431-404 v. Chr.: Zweiter peloponnesischer Krieg");
		signContents.Add ("405-367 v. Chr.: Dionysos I. Tyrann von Syrakus");
		signContents.Add ("396 v. Chr.: Ernennung Marcus zum römischen Diktator");
		signContents.Add ("356-323 v. Chr.: Alexander der Große");
		signContents.Add ("301 v. Chr.: Schlacht von Ipsos " + System.Environment.NewLine + "– erste Konsolidierung des Diadochenreichs");
		signContents.Add ("264-241 v. Chr.: I Punischer Krieg");
		signContents.Add ("218-201 v. Chr.: II Punischer Krieg");
		signContents.Add ("149-146 v. Chr.: III Punischer Krieg");
		signContents.Add ("133-122 v. Chr.: Die Gebrüder Gracchus " + System.Environment.NewLine + "versuchen als Volkstribunen Reformen durchzusetzen");
		signContents.Add ("100-44 v. Chr.: Gaius Iulius Caesar");
		signContents.Add ("63 v. Chr.-14 n. Chr.: Augustus Octavian");
		signContents.Add ("31 v. Chr.: Octavian siegt über " + System.Environment.NewLine + "Marcus Antonius und Kleopatra");
		signContents.Add ("0 (4 v. Chr.): Jesus");
		signContents.Add ("117 n. Chr.: Größte Ausdehnung " + System.Environment.NewLine + "des römischen Reichs unter Trajan");
		signContents.Add ("121-180 n. Chr.: Mark Aurel");
		signContents.Add ("476 n. Chr.: Untergang des weströmischen Reichs");
		signContents.Add ("493 n. Chr.: Herrschaftsbeginn " + System.Environment.NewLine + "des Ostgoten Theoderich in Italien");
		signContents.Add ("1453 n. Chr.: Eroberung von Konstantinopel");

		foreach (Transform child in gameObject.transform) {
			var placedSign = Instantiate (signPref, new Vector3(child.position.x, 1f, child.position.z), signPref.transform.rotation);
			placedSign.name = child.name+"_text";
			placedSign.transform.parent = child.gameObject.transform;

			placedSign.transform.localRotation = Quaternion.identity;
			placedSign.transform.Rotate (new Vector3 (0, 0, 0));

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
