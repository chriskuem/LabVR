using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateTiles : MonoBehaviour {

	public GameObject emptyTile;
	public GameObject player;

	public int labSize;
	public int minCornersToCenter;

	List<List<GameObject>> labArray;
	List<List<int>> activeArray;

	private UnityEngine.AI.NavMeshPath path2;

	int activeX ;
	int activeZ ;
	int startX,startZ;

	int roundsWithoutWayCutting;

	int direction;
	int stepsUntilDirectionChange;

	bool GenerationFinished=false;

	private bool playerIsInitialised = false;

	// Use this for initialization
	void Start () {
		activeX = 0;
		activeZ = 2;

		roundsWithoutWayCutting=0;

		direction=0;
		stepsUntilDirectionChange=0;

		GenerationFinished=false;



		startX = activeX;
		startZ = activeZ;

		path2 = new UnityEngine.AI.NavMeshPath();


		//LabArray
		labArray = new List<List<GameObject>>();

		float labScale = emptyTile.transform.localScale.x;//* 0.8f;

		for (int x = 0; x < labSize; x++) {
			List<GameObject> line = new List<GameObject> ();
			for (int z = 0; z < labSize; z++) {
				var placedTile = Instantiate (emptyTile, new Vector3 (x*labScale-labSize*labScale/2f, 0, z*labScale-labSize*labScale/2f), Quaternion.identity);
				placedTile.name = "emptyTile";
				placedTile.transform.parent = transform;

				line.Add(placedTile);
				//labArray [x] [z] = true;

				int labSizeHalf = System.Convert.ToInt32 (labSize / 2);
				if ((x >(labSizeHalf-2)&&x <(labSizeHalf+2))  && (z >(labSizeHalf-2)&&z <(labSizeHalf+2))) {
					placedTile.SetActive (false);
				}
			}
			labArray.Add (line);
		}


		//Liste bisher aktiver Kacheln
		activeArray = new List<List<int>>();
		for (int i = 0; i < labArray.Count; i++) {
			List<int> row = new List<int> ();
			for (int o = 0; o < labArray[0].Count; o++) {
				row.Add (0);
			}
			activeArray.Add (row);			
		}

		//Startkachel
		labArray [activeX] [activeZ].SetActive(false);
		labArray [activeX+1] [activeZ].SetActive(false);
		activeArray [activeX] [activeZ]++;
		activeArray [activeX+1] [activeZ]++;

		//player Placement
		if(!playerIsInitialised) {
			var placedPlayer = Instantiate (player, labArray [activeX] [activeZ].transform.position /*+ new Vector3(-10,0,-10)*/, Quaternion.identity);
			placedPlayer.name = "Player";
			placedPlayer.transform.parent = transform;
			placedPlayer.transform.rotation = Quaternion.LookRotation (new Vector3(0,0,0)-placedPlayer.transform.position);
			playerIsInitialised = true;
		}

		while (!GenerationFinished) {

			//if (stepsUntilDirectionChange <= 0) {
			//	stepsUntilDirectionChange = 1+System.Convert.ToInt32 (Random.value * (labArray.Count/10));
			direction = System.Convert.ToInt32 (Random.value * 3);
			//}

			if (direction == 0 && Placable (activeX - 1, activeZ)) {
				if (activeArray [activeX - 1] [activeZ] < 15) {
					activeX--;
					roundsWithoutWayCutting = 0;
				}
				else
					stepsUntilDirectionChange = 0;
			} else if (direction == 1 && Placable (activeX + 1, activeZ)) {
				if (activeArray [activeX + 1] [activeZ] < 15){
					activeX++;
					roundsWithoutWayCutting = 0;
				}
				else
					stepsUntilDirectionChange = 0;
			} else if (direction == 2 && Placable (activeX, activeZ - 1)) {
				if (activeArray [activeX] [activeZ - 1] < 15){
					activeZ--;
					roundsWithoutWayCutting = 0;
				}
				else
					stepsUntilDirectionChange = 0;
			} else if (direction == 3 && Placable (activeX, activeZ + 1)) {
				if (activeArray [activeX] [activeZ + 1] < 15){
					activeZ++;
					roundsWithoutWayCutting = 0;
				}
				else
					stepsUntilDirectionChange = 0;
			} else
				roundsWithoutWayCutting++;

			if (roundsWithoutWayCutting > 10) {
				roundsWithoutWayCutting = 0;

				//taking random way-point
				int tempX = -1;
				int tempZ = -1;
				for (int x = 0; x < labArray.Count; x++) {
					for (int z = 0; z < labArray [0].Count; z++) {
						if (activeArray [x] [z] < 3 && Placable (x, z) && !labArray [x] [z].activeSelf && x != System.Convert.ToInt32 (labSize / 2)) {
							tempX = x;
							tempZ = z;
						}
					}
				}
				if (tempX == -1){
					GenerationFinished = true;
				}

				activeX = tempX;
				activeZ = tempZ;
			}

			if (activeX > 0 && activeZ > 0 && activeX < labArray.Count - 1 && activeZ < labArray [0].Count - 1) {

				labArray [activeX] [activeZ].SetActive (false);
				activeArray [activeX] [activeZ]++;
				stepsUntilDirectionChange--;

			}


			//check if finished
			if (!GenerationFinished) {
				GenerationFinished = true;
				for (int x = 0; x < labArray.Count; x++) {
					for (int z = 0; z < labArray [0].Count; z++) {
						if (labArray [x] [z].activeSelf && Placable (x, z)) {
							GenerationFinished = false;
						}
					}
				}
			}

		}
	
	}
	
	// Update is called once per frame
	void Update () {

		if (GenerationFinished) {

			Vector3 center = labArray [System.Convert.ToInt32 (labSize / 2)] [System.Convert.ToInt32 (labSize / 2)].transform.position;
			Vector3 start = labArray [startX] [startZ].transform.position;
			center.y = start.y = 1f;

			//Draw Red Line
			if (UnityEngine.AI.NavMesh.CalculatePath (center, start, UnityEngine.AI.NavMesh.AllAreas, path2)) {
				for (int i = 0; i < path2.corners.Length - 1; i++)
					Debug.DrawLine (path2.corners [i], path2.corners [i + 1], Color.red);
				if (path2.corners.Length < minCornersToCenter) {
					//neu generieren
					for (int i = 0; i < labArray.Count; i++) {
						for (int o = 0; o < labArray.Count; o++) {
							Destroy (labArray [i] [o]);
						}
					}
					Start ();
				}
			}
		}
			

	}

	bool AtLocation(int x, int z){
		if (x > 0 && z > 0 && x < labArray.Count-1 && z < labArray [0].Count-1) {
			return labArray [x] [z].activeSelf;
		} else
			return false;
	}

	bool Placable(int x, int z){
		if (UpperLeft (x, z) && LowerLeft (x, z) && UpperRight (x, z) && LowerRight (x, z) && x!=0 && z!=0 && z!= labArray[0].Count-1 && x!= labArray.Count-1) {
			if (((!AtLocation (x - 1, z) && !AtLocation (x + 1, z)) || (!AtLocation (x, z + 1) && !AtLocation (x, z - 1)))&&x!=1&&z!=1) {
				//4er Kreuzungen vermeiden, außer ganz außen
				return false;
			}
			else
				return true;
		} else
			return false;
	}

	bool UpperRight(int x, int z){
		if ((AtLocation (x + 1, z + 1) == false && AtLocation (x + 1, z)== false  &&  AtLocation (x, z + 1) == false)) {
			return false;
		} else
			return true;
	}

	bool UpperLeft(int x, int z){
		if ((AtLocation (x - 1, z + 1) == false && AtLocation (x - 1, z)== false   && AtLocation (x, z + 1) == false)) {
			return false;
		} else
			return true;
	}

	bool LowerRight(int x, int z){
		if ((AtLocation (x + 1, z - 1) == false && AtLocation (x + 1, z) == false  &&  AtLocation (x, z - 1) == false)) {
			return false;
		} else
			return true;
	}

	bool LowerLeft(int x, int z){
		if ((AtLocation (x - 1, z - 1) == false  && AtLocation (x - 1, z) == false  && AtLocation (x, z - 1) == false)) {
			return false;
		} else
			return true;
	}
}
