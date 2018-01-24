using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapGenerator : MonoBehaviour {

	public GameObject Trap1;
	public int SpikeRandomYesNo;
	public int AngleRandomZero90;

	// Use this for initialization
	void Start () {
		if (SpikeRandomYesNo != 2) {
			//percentage for create spikes
			int per = System.Convert.ToInt32 (Random.value * 100);

			if (per < 30 || SpikeRandomYesNo == 1) {
				var placedTrap1 = Instantiate (Trap1, transform.position, Quaternion.identity);
				placedTrap1.name = "SpikeTrap";
				placedTrap1.transform.parent = transform;

				if (AngleRandomZero90 != 1) {
					//randomly rotate spikes 90° or defined angle
					int turn = System.Convert.ToInt32 (Random.value * 100);
					if (turn < 50 || AngleRandomZero90 == 2) {
						placedTrap1.transform.Rotate (0, 90, 0);
					} 
				}
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
