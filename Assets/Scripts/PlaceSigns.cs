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

		signContents.Add ("12.-13. Jh. v. Chr.| Fall Trojas|");
		signContents.Add ("814 v. Chr.| Gründung Karthago|");
		signContents.Add ("8. Jh. v. Chr.| Homer: Ilias & Odyssee|" 																							+ System.Environment.NewLine +System.Environment.NewLine + "Links: 8. Jh. v. Chr."+System.Environment.NewLine + "Rechts: 6. Jh. v. Chr.");
		signContents.Add ("753 v. Chr.| Gründung Roms|"																									+ System.Environment.NewLine +System.Environment.NewLine + "Links: 763 v. Chr."+System.Environment.NewLine + "Geradeaus: 753 v. Chr.");
		signContents.Add ("700 v. Chr.| „Werke und Tage“ – Hesiod|"																						+ System.Environment.NewLine +System.Environment.NewLine + "Rechts: 600 v. Chr."+System.Environment.NewLine + "Geradeaus: 700 v. Chr.");
		signContents.Add ("650-500 v. Chr.| Tyrannenherrschaften|"																						+ System.Environment.NewLine +System.Environment.NewLine + "Rechts: 650-500 v. Chr."+System.Environment.NewLine + "Geradeaus: 750-600 v. Chr.");
		signContents.Add ("561 v. Chr.| Beginn der Tyrannis " 				+ System.Environment.NewLine + "des Peisistratos in Athen|"					+ System.Environment.NewLine +System.Environment.NewLine + "Rechts: 511 v. Chr."+System.Environment.NewLine + "Links: 561 v. Chr.");
		signContents.Add ("550 v. Chr.| Peloponnesisches Bündnis " 			+ System.Environment.NewLine + "unter der Führung Spartas|" 				+ System.Environment.NewLine +System.Environment.NewLine + "Rechts: 550 v. Chr."+System.Environment.NewLine + "Geradeaus: 561 v. Chr.");		
		signContents.Add ("510 v. Chr.| Ende der römischen Königszeit|"																					+ System.Environment.NewLine +System.Environment.NewLine + "Rechts: 510 v. Chr."+System.Environment.NewLine + "Links: 410 v. Chr.");
		signContents.Add ("490 v. Chr.| Marathon (Perserkriege)|"																						+ System.Environment.NewLine +System.Environment.NewLine + "Rechts: 500 v. Chr."+System.Environment.NewLine + "Geradeaus, dann links: 495 v. Chr."+System.Environment.NewLine + "Geradeaus, dann rechts: 490 v. Chr.");
		signContents.Add ("480 v. Chr.| Salamis (Perserkriege)|");
		signContents.Add ("480 v. Chr.| Sieg des Tyrannen Gelon " + System.Environment.NewLine + "von Syrakus über die Karthager|");
		signContents.Add ("478/477 v. Chr.| Delisch-attischer " + System.Environment.NewLine + "Seebund wird gegründet, Athen übernimmt Führung|");
		signContents.Add ("469-399 v. Chr.| Sokrates|"																									+ System.Environment.NewLine +System.Environment.NewLine + "Rechts: 439-359 v. Chr."+System.Environment.NewLine + "Geradeaus: 469-399 v. Chr.");
		signContents.Add ("461-451 v. Chr.| Erster peloponnesischer Krieg|");
		signContents.Add ("431-404 v. Chr.| Zweiter peloponnesischer Krieg|");
		signContents.Add ("405-367 v. Chr.| Dionysios I. - Tyrann von Syrakus|");
		signContents.Add ("396 v. Chr.| Camillus erobert als " + System.Environment.NewLine + "römischer Diktator die Handelsstadt Veji|");
		signContents.Add ("356-323 v. Chr.| Alexander der Große|");
		signContents.Add ("301 v. Chr.| Schlacht von Ipsos – " + System.Environment.NewLine + "erste Konsolidierung des Diadochenreichs|"				+ System.Environment.NewLine +System.Environment.NewLine + "Links: 295 v. Chr."+System.Environment.NewLine + "Rechts: 301 v. Chr.");
		signContents.Add ("264-241 v. Chr.| I. Punischer Krieg|");
		signContents.Add ("218-201 v. Chr.| II. Punischer Krieg|");
		signContents.Add ("149-146 v. Chr.| III. Punischer Krieg|");
		signContents.Add ("133-122 v. Chr.| Die Gebrüder Gracchus " + System.Environment.NewLine + "versuchen als Volkstribunen Reformen durchzusetzen|"+ System.Environment.NewLine +System.Environment.NewLine + "Rechts: 105-82 v. Chr."+System.Environment.NewLine + "Geradeaus: 133-122 v. Chr.");
		signContents.Add ("100-44 v. Chr.| Gaius Iulius Caesar|");
		signContents.Add ("63 v. Chr.-14 n. Chr.| Augustus (Octavian)|"																					+ System.Environment.NewLine +System.Environment.NewLine + "Rechts: 63 v. Chr.-14 n. Chr."+System.Environment.NewLine + "Geradeaus: 58 v. Chr.-12 n. Chr.");
		signContents.Add ("31 v. Chr.| Octavian siegt über " + System.Environment.NewLine + "Marcus Antonius und Kleopatra|");
		signContents.Add ("0 (4 v. Chr.)| Jesus wird geboren|"																										+ System.Environment.NewLine +System.Environment.NewLine + "Links: 14 (10 n. Chr.)"+System.Environment.NewLine + "Rechts: 0 (4 v. Chr.)");
		signContents.Add ("117 n. Chr.| Größte Ausdehnung " + System.Environment.NewLine + "des römischen Reichs unter Trajan|"							+ System.Environment.NewLine +System.Environment.NewLine + "Links: 104 n. Chr."+System.Environment.NewLine + "Geradeaus: 117 n. Chr.");
		signContents.Add ("121-180 n. Chr.| Mark Aurel|");
		signContents.Add ("476 n. Chr.| Untergang des weströmischen Reichs|");
		signContents.Add ("493 n. Chr.| Herrschaftsbeginn " + System.Environment.NewLine + "des Ostgoten Theoderich in Italien|");
		signContents.Add ("1453 n. Chr.| Eroberung von Konstantinopel|");

		foreach (Transform child in gameObject.transform) {
			var placedSign = Instantiate (signPref, new Vector3(child.position.x, 1f, child.position.z), signPref.transform.rotation);
			placedSign.name = child.name+"_text";
			placedSign.transform.parent = child.gameObject.transform;

			placedSign.transform.localRotation = Quaternion.identity;
			placedSign.transform.Rotate (new Vector3 (0, 0, 0));

			GameObject gO = placedSign.transform.Find("Text").gameObject;
        	TextMesh tM = gO.GetComponent(typeof(TextMesh)) as TextMesh;

			int index = Convert.ToInt32 (child.name.Replace ("Sign", "").Replace ("_wrongway", ""))-1;

			string[] lines = signContents [index].Split(new[] { "|" },StringSplitOptions.None);
			if (child.name.Contains ("wrongway")) {
				tM.text = lines[0]+":"+lines[1];
			} else {
				if (lines [2].Length > 1) {
					tM.text = lines [1] + lines [2];
				} else {
					tM.text = lines[0]+":"+lines[1];
				}
			}

		}
	}
	
	// Update is called once per frame
	void Update () {
	}
}
