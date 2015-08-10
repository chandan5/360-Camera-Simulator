using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class MapScript : MonoBehaviour {
	public Canvas canvas;
	public GameObject BarrelPrefab;
	public Material yellowMaterial;

	private GameObject prevCamera;
	private GameObject[] barrels = new GameObject[12];
	private List<Vector3> barrelPositions = new List<Vector3> ();
	private Vector3[] positions = new Vector3[12];
	private Camera camera;
	private int count;
	private string playerName;
	private string cameraName;
	
	void Start() {
		count = 0;
		camera = gameObject.GetComponent<Camera> ();

		canvas.enabled = false;

		prevCamera = GameObject.Find ("Welcome Camera");

		LogScript.returnBarrelPositions(out barrelPositions);

		for (int i=0; i<12; i++) {
			if (barrels [i].gameObject.layer == 8)
				barrelPositions.Add (barrels [i].transform.position);
		}

	}
	
	public void confirmPosition(string answer){
		if (answer == "Y") {
			barrels[count - 1].GetComponentInChildren<MeshRenderer>().material = yellowMaterial;
			canvas.enabled = false;

		} else if (answer == "N") {
			count = count - 1;
			Destroy (barrels [count].gameObject);
			barrels [count] = new GameObject ();
			canvas.enabled = false;
		}
	}

	void MapLog(){
		Vector2[] barrelPositions2d = new Vector2[barrelPositions.Count];
		Vector2[] positions2d = new Vector2[barrelPositions.Count];

		for (int i = 0; i<barrelPositions.Count; i++) {
			barrelPositions2d[i] = new Vector2(barrelPositions[i].x,barrelPositions[i].z);
			positions2d[i] = new Vector2(positions[i].x,positions[i].z);
		}

		LogScript.returnNames (out cameraName,out playerName);

		if(Directory.Exists("./GAMELOGS/"+cameraName))
			Debug.Log("Directory already exits!");
		else 
			Directory.CreateDirectory("./GAMELOGS/"+cameraName);

		StreamWriter sw = new StreamWriter ("./GAMELOGS/" + cameraName + "/" + playerName + "MapTask.txt");
		sw.WriteLine ("DISTANCES MATCHED CLOSEST TO EACH OTHER\nACTUAL BARREL POSITION\t\tPLAYER MAPPED POSITION\n");
		for (int i=0; i < barrelPositions.Count; i++) {
			float distance = 99999f;
			int posIndex = 999;
			for(int j=0;j<barrelPositions.Count;i++){
				float temp;
				temp = (barrelPositions2d[i] - positions2d[j]).magnitude;
				if(temp<distance){
					distance = temp;
					posIndex = j;
				}
			}
			sw.WriteLine(barrelPositions2d[i]+"\t\t"+positions2d[posIndex]);
			positions2d[posIndex].x = 999f;
			positions2d[posIndex].y = 999f;
		}
	}

	public int returnCount(){
		return count;
	}
	
	void Update() {
		Vector3 mousePosition = Input.mousePosition;
		mousePosition.z = gameObject.transform.position.z;
		if(count == barrelPositions.Count){
//		if(count == 12){
			Debug.Log("You're done!");
			MapLog();
			count = count + 1;
			Application.Quit();
		}else if (Input.GetMouseButtonDown (0) && canvas.enabled == false) {
			Debug.Log("The count is" + count);
			Debug.Log (camera.ScreenToWorldPoint (mousePosition));
			barrels[count] = Instantiate(BarrelPrefab, camera.ScreenToWorldPoint (mousePosition) ,Quaternion.identity) as GameObject;
			positions[count] = camera.ScreenToWorldPoint (mousePosition);
			count = count + 1;
			canvas.enabled = true;
		}
	}
}