using UnityEngine;
using System.Collections;

public class objectPlacement : MonoBehaviour {
	private float lowX,lowY,highX,highY;
	public GameObject prefab;
	private GameObject[] objects = new GameObject[12];
	private int positionNotOccupied = 0;
	private float minDistance = 999.0F;
	private int indx = 99;
	// Use this for initialization
	void Start () {
		lowX = 12.0F;
		lowY = 12.0F;
		highX = 250.0F;
		highY = 250.0F;

		for (int i = 0; i < 12; i++) {
			positionNotOccupied = 0;
			Vector3 position = new Vector3(Random.Range(lowX,highX),5.0F, Random.Range(lowY,highY));
			while(positionNotOccupied == 0){
				var hitColliders = Physics.OverlapSphere(position,2);
				if(hitColliders.Length == 0){
					positionNotOccupied = 1;
				}
				else{
					Debug.Log("That place is taken!");
					position = new Vector3(Random.Range(lowX,highX),5.0F, Random.Range(lowY,highY));
				}
			}
			objects[i] =  Instantiate(prefab,position,Quaternion.identity) as GameObject;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.P)) {
			Debug.Log("You Pressed P!");
			foreach(GameObject barrel in objects){
				if ( Vector3.Distance(transform.position,barrel.transform.position) < minDistance){
					Debug.Log("Hey, you're in the loop!");
					// indx = i;
					minDistance = Vector3.Distance(gameObject.transform.position,barrel.transform.position);
				}
			}
			Debug.Log("The minimum distance is "+ minDistance.ToString());
		}
		if (indx != 99) {
			Debug.Log ("destroying object");
			Debug.Log (indx);
			objects[indx].SetActive(false);
		}	
	}
}
