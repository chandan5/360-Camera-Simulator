using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System.IO;

public class MP : MonoBehaviour {
	public GameObject BarrelPrefab;
	public GameObject dialogBox;
	public Material confirmBarrelColor;

	private Camera mapCamera;
	private DBS dbsScript;
	private GameObject[] BarrelsToPlace = new GameObject[BS.returnCount()];
//	private GameObject[] BarrelsToPlace = new GameObject[12];
	private int placedCount;
	private bool enableDialog;

	// Use this for initialization
	void Start () {
		mapCamera = gameObject.GetComponent<Camera> ();
		placedCount = 0;
		enableDialog = false;
		dbsScript = dialogBox.GetComponent<DBS> ();
	}

	public void SetEnableDialog(bool state){
		enableDialog = state;
	}

	public int returnPlacedCount(){
		return placedCount;
	}

	public bool enableDialogBox(){
		return enableDialog;
	}

	public void changePlacedBarrelColor(){
		BarrelsToPlace [placedCount - 1].GetComponentInChildren<MeshRenderer> ().material = confirmBarrelColor;
	}

	public void cancelPrevPlacement(){
		placedCount = placedCount - 1;
		Destroy (BarrelsToPlace [placedCount]);
	}

	public void MapLog(){
		Vector2[] barrelPositions2d = new Vector2[BS.returnCount()];
		Vector2[] positions2d = new Vector2[BS.returnCount()];
		
		for (int i = 0; i<BarrelsScript.returnFoundBarrelsCount(); i++) {
			barrelPositions2d[i] = new Vector2(BS.getSpawnPositions()[i].x,BS.getSpawnPositions()[i].z);
			positions2d[i] = new Vector2(BarrelsToPlace[i].gameObject.transform.position.x,BarrelsToPlace[i].gameObject.transform.position.z);
		}

		if(Directory.Exists("./GAMELOGS/"+WS.returnPlayerName()+"/"+LOG.returnCamType()))
			Debug.Log("Directory already exists!");
		else 
			Directory.CreateDirectory("./GAMELOGS/"+WS.returnPlayerName()+"/"+LOG.returnCamType());
		
		StreamWriter sw = new StreamWriter ("./GAMELOGS/"+WS.returnPlayerName()+"/"+LOG.returnCamType() + "/MapTask.txt");
		sw.WriteLine ("DISTANCES MATCHED CLOSEST TO EACH OTHER\n\nACTUAL BARREL POSITION\tPLAYER MAPPED POSITION\n");

		for ( int i=0; i <BS.returnCount(); i++ ){
			float distance = 99999f;
			int posIndex = 999;
			for(int j=0;j<BS.returnCount();i++){
				float temp;
				temp = (barrelPositions2d[i] - positions2d[j]).magnitude;
				if( temp < distance ){
					distance = temp;
					posIndex = j;
				}
			}

			sw.WriteLine(barrelPositions2d[i]+"\t\t"+positions2d[posIndex]);
			positions2d[posIndex].x = 999f;
			positions2d[posIndex].y = 999f;
		}
		sw.Close ();
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0) && dbsScript.canPlaceBarrel()) {
			if(placedCount < BS.returnCount()){
//			if(placedCount < 12){
				Debug.Log("Placed Barrel");
				BarrelsToPlace[placedCount] = Instantiate(BarrelPrefab,mapCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y,gameObject.transform.position.z)),Quaternion.identity) as GameObject;
				placedCount = placedCount + 1;
				enableDialog = true;
			}
			if(Input.GetKeyDown(KeyCode.L)){
				MapLog();
				Application.Quit();
			}
		}
	}
}
