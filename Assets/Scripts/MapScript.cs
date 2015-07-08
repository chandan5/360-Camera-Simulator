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
		if (Input.GetMouseButtonDown (0)) {
			Debug.Log(camera.ViewportToWorldPoint(Input.mousePosition));
			barrels[counter].transform.Translate(camera.ScreenToWorldPoint(Input.mousePosition));
			if(counter < 11)
				counter = counter + 1;

		}
	}
}
