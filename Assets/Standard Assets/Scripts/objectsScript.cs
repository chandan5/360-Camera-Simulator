using UnityEngine;
using System.Collections;
using System.IO;

public class objectsScript : MonoBehaviour {
	private float lowX,highX,lowZ,highZ;
	public GameObject prefab;
	private GameObject[] barrels = new GameObject[12];
	private int[] order = new int[12];
	private int counter = 0;
	//private int index = 999;
	private string[] dirs = new string[12];
	private float[] timeTaken = new float[12];
	private int currentIndex = 99;
	private Canvas dirUI;
	public GameObject ui; 
	//private int actvUI = 0;

	// Use this for initialization
	void Start () {
		Debug.Log ("Hiya!");
		Vector3 position;
		Collider[] colliders;
		dirUI = ui.GetComponent<Canvas> ();
		dirUI.enabled = false;

		lowX = 12.0F;
		lowZ = 12.0F;
		highX = 250.0F;
		highZ = 250.0F;

		for (int i = 0; i < 3; i++) {
			position = new Vector3 (Random.Range (lowX, highX), 0.0f, Random.Range (lowZ, highZ));
			colliders = Physics.OverlapSphere (position, 1.0F);
			while (colliders.Length != 0) {
				Debug.Log ("that place is taken!");
				position = new Vector3 (Random.Range (lowX, highX), 7.0f, Random.Range (lowZ, highZ));
				colliders = Physics.OverlapSphere (position, 1.0F);
			}
			barrels [i] = Instantiate (prefab, position - new Vector3(0.0F,7.0F,0.0F), Quaternion.identity) as GameObject;
		}

		lowX = 255.0F;
		lowZ = 12.0F;
		highX = 485.0F;
		highZ = 250.0F;
		
		for (int i = 3; i < 6; i++) {
			position = new Vector3 (Random.Range (lowX, highX), 0.0f, Random.Range (lowZ, highZ));
			colliders = Physics.OverlapSphere (position, 1.0F);
			while (colliders.Length != 0) {
				Debug.Log ("that place is taken!");
				position = new Vector3 (Random.Range (lowX, highX), 7.0f, Random.Range (lowZ, highZ));
				colliders = Physics.OverlapSphere (position, 1.0F);
			}
			barrels [i] = Instantiate (prefab, position - new Vector3(0.0F,7.0F,0.0F), Quaternion.identity) as GameObject;
		}

		lowX = 12.0F;
		lowZ = 255.0F;
		highX = 250.0F;
		highZ = 485.0F;
		
		for (int i = 6; i < 9; i++) {
			position = new Vector3 (Random.Range (lowX, highX), 0.0f, Random.Range (lowZ, highZ));
			colliders = Physics.OverlapSphere (position, 1.0F);
			while (colliders.Length != 0) {
				Debug.Log ("that place is taken!");
				position = new Vector3 (Random.Range (lowX, highX), 7.0f, Random.Range (lowZ, highZ));
				colliders = Physics.OverlapSphere (position, 1.0F);
			}
			barrels [i] = Instantiate (prefab, position - new Vector3(0.0F,7.0F,0.0F), Quaternion.identity) as GameObject;
		}

		lowX = 255.0F;
		lowZ = 255.0F;
		highX = 485.0F;
		highZ = 485.0F;
		
		for (int i = 9; i < 12; i++) {
			position = new Vector3 (Random.Range (lowX, highX), 0.0f, Random.Range (lowZ, highZ));
			colliders = Physics.OverlapSphere (position, 1.0F);
			while (colliders.Length != 0) {
				Debug.Log ("that place is taken!");
				position = new Vector3 (Random.Range (lowX, highX), 7.0f, Random.Range (lowZ, highZ));
				colliders = Physics.OverlapSphere (position, 1.0F);
			}
			barrels [i] = Instantiate (prefab, position - new Vector3(0.0F,7.0F,0.0F), Quaternion.identity) as GameObject;
		}

	}

	private void placeBarrels(float lx,float lz,float hx,float hz,int indL,int indH){
		lowX = lx;
		lowZ = lz;
		highX = hx;
		highZ = hz;
		Vector3 position;
		Collider[] colliders;
		for (int i = indL; i < indH; i++) {
			position = new Vector3 (Random.Range (lowX, highX), 0.0f, Random.Range (lowZ, highZ));
			colliders = Physics.OverlapSphere (position, 1.0F);
			while (colliders.Length != 0) {
				Debug.Log ("that place is taken!");
				position = new Vector3 (Random.Range (lowX, highX), 7.0f, Random.Range (lowZ, highZ));
				colliders = Physics.OverlapSphere (position, 1.0F);
			}
			barrels [i] = Instantiate (prefab, position, Quaternion.identity) as GameObject;
		}
	}

	public void recvMessage(string direc){
		Debug.Log (direc);
		dirs [currentIndex] = direc;
		dirUI.enabled = false;
		order [counter] = currentIndex;
		counter = counter + 1;
//		Time.timeScale = 1;

	}
	private void makeFiles(){
		string pth = "./GAMELOGS";
		string filename = "./GAMELOGS/thelog.txt";
		if (Directory.Exists (pth)) {
			System.Console.WriteLine("Already Exists!");
		} else {
			Debug.Log("Creating Directory");
			Directory.CreateDirectory (pth);
		}
		if (counter == 11) {
			var sr = File.CreateText (filename);
			sr.WriteLine ("--------------THIS IS THE GAME LOG. DO NOT EDIT!!--------------");
			sr.WriteLine("Index\tPosition\tTime Since Beggining\t");  
			foreach(int indx in order){
				sr.WriteLine(indx.ToString()+"\t"+barrels[indx].transform.position.ToString()+timeTaken[indx].ToString());
			}
			sr.Close();
			counter = counter + 1;
		}
	}
	// Update is called once per frame
	void Update () {
		float[] distances = new float[12];
		//float minimum = 99999.0F;
		for(int i = 0; i < 12;i++){
			distances[i] = Vector3.Distance(transform.position,barrels[i].transform.position);
		}
		if(Input.GetKeyDown(KeyCode.P)){
			for(int i = 0;i < 12;i++){
				Debug.Log(barrels[i].transform.position);
				Debug.Log(transform.position);
				Debug.Log(distances[i]);
				if(distances[i] < 10.0F ){
					Debug.Log("the index is"+i.ToString());
					currentIndex = i;
					dirUI.enabled = true;
//					Time.timeScale = 0;
					if(Input.GetKeyDown(KeyCode.Escape)){
						dirUI.enabled = !dirUI.enabled;
					}
					barrels[i].transform.Translate(new Vector3(0.0F,500.0F,0.0F));
					timeTaken[i] = Time.realtimeSinceStartup;
					makeFiles();
					break;
				}
			}
		}
	}
}
