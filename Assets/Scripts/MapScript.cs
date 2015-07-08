using UnityEngine;
using System.Collections;

public class MapScript : MonoBehaviour {
	public GameObject barrelPrefab;
	public Camera camera;
	private GameObject[] barrels = new GameObject[12];
	private int counter = 0;
	// Use this for initialization
	void Start () {
		for(int i = 0;i < 12 ; i++){
			barrels[i] = Instantiate(barrelPrefab,new Vector3(0f,0f,0f),Quaternion.identity) as GameObject;
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector3 mousePosition = Input.mousePosition;
		mousePosition.z = 450f;
		if (Input.GetMouseButtonDown (0)) {
			Debug.Log (camera.ScreenToWorldPoint (mousePosition));
			Debug.Log("Current counter value :: "+ counter);
			barrels[counter].transform.Translate(camera.ScreenToWorldPoint(mousePosition));
			if(counter < 11){
				counter = counter + 1;
			}
		}
	}
}