using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSpikes : MonoBehaviour {

	public GameObject toObject;
	public GameObject origPoint;
	float distance;
	bool reached = false;

	public void Start()
	{
	}

	public void Update()
	{
		if(!reached)
		{
			distance = Vector3.Distance(transform.position, toObject.transform.position);
			if(distance > .1)
			{
				move (transform.position, toObject.transform.position);
			}
			else
			{
				reached = true;
			}
		}
		else
		{
			distance = Vector3.Distance(transform.position, origPoint.transform.position);
			if(distance > .1)
			{
				move (transform.position, origPoint.transform.position);
			}
			else
			{
				reached = false;
			}
		}
	}

	void move(Vector3 pos, Vector3 towards)
	{
		transform.position = Vector3.MoveTowards(pos, towards, .1f);
	}
}
