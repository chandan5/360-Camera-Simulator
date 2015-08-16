using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BS : MonoBehaviour {

	public  Material foundObjectSkin;
	public GameObject barrelPrefab;
	public GameObject compass;

	private bool startLogging;
	private static int count = 0;
	private static Vector3[] spawnPositions = new Vector3[12];
	private BehaviourScript behaviour;
	private ANG ang;
	private bool enableCompass;
	private CB[] componentCameraCB;
	private GameObject foundObject;
	private GameObject[] barrels = new GameObject[12];
	private int foundLayer;

	private List<float> estimatedAngles = new List<float>();
	private List<float> actualAngles = new List<float> ();
	private List<string> orderOfSelection = new List<string> ();
	private List<Vector3> LogPositions = new List<Vector3>();


	// Use this for initialization
	void Start () {
		startLogging = false;
		ang = compass.GetComponent<ANG> ();
		behaviour = gameObject.GetComponent<BehaviourScript>();
		foundLayer = 8;
		enableCompass = false;
		randomPlacement (12f, 12f, 250f, 250f, 0, 3);
		randomPlacement (255f, 12f, 485f, 250f, 3, 6);
		randomPlacement (12f, 255f, 250f, 485f, 6, 9);
		randomPlacement (255f, 255f, 485f, 485f, 9, 12);
		componentCameraCB = gameObject.GetComponentsInChildren<CB> ();
	}

	public static Vector3[] getSpawnPositions(){
		return spawnPositions;
	}

	public void returnAllLists(out List<float> estimated,out List<float> actual, out List<string> order){
		estimated = estimatedAngles;
		actual = actualAngles;
		order = orderOfSelection;
	}

	private void randomPlacement(float lowX,float lowZ,float highX,float highZ,int indexLow, int indexHigh){
		Collider[] colliders;
		Vector3 position;
		for (int i = indexLow; i < indexHigh; i++) {
			position = new Vector3 (Random.Range (lowX, highX), 0.0f, Random.Range (lowZ, highZ));
			colliders = Physics.OverlapSphere (position, 1.0F);
			while (colliders.Length != 0) {
				position = new Vector3 (Random.Range (lowX, highX), 7.0f, Random.Range (lowZ, highZ));
				colliders = Physics.OverlapSphere (position, 1.0F);
			}
			barrels [i] = Instantiate (barrelPrefab, position - new Vector3(0.0F,7.0F,0.0F), Quaternion.identity) as GameObject;
			spawnPositions[i] = position - new Vector3(0f,7.0f,0.0f);
			barrels[i].name = i.ToString();
		}
	}

	public bool returnEnableCompass(){
		return enableCompass;
	}

	public static int returnCount(){
		return count;
	}

	public bool canLog(){
		return startLogging;
	}

	public void setEnableCompass(bool enable){
		enableCompass = enable;
	}

	public void returnPathLog(out List<Vector3> path){
		path = LogPositions;
	}

	private float calculateActualAngle(){
		Vector2 reference = new Vector2 (0f, 1f) - new Vector2 (0f, 0f);
		Vector2 barrelVector = new Vector2 (foundObject.transform.position.x, foundObject.transform.position.z) - new Vector2 (gameObject.transform.position.x,gameObject.transform.position.z);
		float barrelAngle = Vector2.Angle (reference,barrelVector);
		if (foundObject.transform.position.x < gameObject.transform.position.x)
			barrelAngle = -barrelAngle;
		Debug.Log ("The actual angle calculated is " + barrelAngle);
		return barrelAngle;
	}

	// Update is called once per frame
	void Update () {
		MeshRenderer foundObjectMeshRenderer;
		foreach(CB cb in componentCameraCB){
			if(cb.objectHit()){

				foundObject = cb.returnHitObject();
				foundObjectMeshRenderer = foundObject.GetComponentInChildren<MeshRenderer>();
				foundObjectMeshRenderer.material = foundObjectSkin;

				foundObject.layer = foundLayer;
				foundObject.GetComponentInChildren<Transform>().gameObject.layer = foundLayer;

				for(int j = 0;j< 12;j++){
					if(foundObject.transform.position == barrels[j].transform.position){
						Debug.Log("The transform matches with "+barrels[j].name);
						orderOfSelection.Add(barrels[j].name);
//						break;
					}
				}

				actualAngles.Add(calculateActualAngle());

				count = count + 1;
				setEnableCompass(true);
				behaviour.enabled = false;
			}
		}
		if (ang.IsAngleCalculated()) {
			behaviour.enabled = true;
			setEnableCompass(false);
			estimatedAngles.Add(ang.getAngle());
		}
		if (count == 12) {
			startLogging = true;
		}
		if (Input.GetKeyDown (KeyCode.P)) {
			startLogging = true;
		}
	}

	void FixedUpdate(){
		LogPositions.Add (gameObject.transform.position);
	}
}
