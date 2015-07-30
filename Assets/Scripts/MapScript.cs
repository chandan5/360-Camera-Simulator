using UnityEngine;
using System.Collections;

public class MapScript : MonoBehaviour {
	public Canvas canvas;
	public GameObject BarrelPrefab;

	private GameObject prevCamera;
	private GameObject[] barrels = new GameObject[12];
	private Vector3[] positions;
	private Camera camera;
	private int count;
	
	void Start() {
		count = 0;
		camera = gameObject.GetComponent<Camera> ();
		canvas.enabled = false;
		prevCamera = GameObject.Find ("Welcome Camera");
		Debug.Log (prevCamera.name);
		prevCamera.SetActive (false);
	}
	
	public void confirmPosition(string answer){
		if (answer == "Y") {
			canvas.enabled = false;
		} else if (answer == "N") {
			count = count - 1;
			Destroy(barrels[count].gameObject);
			barrels[count] = new GameObject();
			canvas.enabled = false;
		}
		
		
	}
	public int returnCount(){
		return count;
	}
	
	void Update() {
		Vector3 mousePosition = Input.mousePosition;
		mousePosition.z = gameObject.transform.position.z;
		if(count == 11){
			Debug.Log("You're done!");
		}else if (Input.GetMouseButtonDown (0) && canvas.enabled == false) {
			Debug.Log (camera.ScreenToWorldPoint (mousePosition));
			barrels[count] = Instantiate(BarrelPrefab, camera.ScreenToWorldPoint (mousePosition) ,Quaternion.identity) as GameObject;
			positions[count] = camera.ScreenToWorldPoint (mousePosition);
			count = count + 1;
			canvas.enabled = true;
		}
	}
}