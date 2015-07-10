using UnityEngine;
using System.Collections;

public class BarrelsScript : MonoBehaviour {

	public GameObject barrelPrefab;
	public Canvas canvas;
	public Material redColorBarrelMaterial;

	private GameObject[] barrels = new GameObject[12];
	private GameObject barrel;
	private ClickBarrel[] clickBarrel;
	private angleScript angScript;
	private float[] angle = new float[12];

	// Use this for initialization
	void Start () {
		randomPlacement (12f, 12f, 250f, 250f, 0, 3);
		randomPlacement (255f, 12f, 485f, 250f, 3, 6);
		randomPlacement (12f, 255f, 250f, 485f, 6, 9);
		randomPlacement (255f, 255f, 485f, 485f, 9, 12);
		canvas.enabled = false;

		clickBarrel = gameObject.GetComponentsInChildren<ClickBarrel> ();
		angScript = canvas.GetComponentInChildren<angleScript> ();
	
	}


	private void randomPlacement(float lowX,float lowZ,float highX,float highZ,int indexLow, int indexHigh){
		Collider[] colliders;
		Vector3 position;
		for (int i = indexLow; i < indexHigh; i++) {
			position = new Vector3 (Random.Range (lowX, highX), 0.0f, Random.Range (lowZ, highZ));
			colliders = Physics.OverlapSphere (position, 1.0F);
			while (colliders.Length != 0) {
				Debug.Log ("that place is taken!");
				position = new Vector3 (Random.Range (lowX, highX), 7.0f, Random.Range (lowZ, highZ));
				colliders = Physics.OverlapSphere (position, 1.0F);
			}
			barrels [i] = Instantiate (barrelPrefab, position - new Vector3(0.0F,7.0F,0.0F), Quaternion.identity) as GameObject;
			barrels[i].name = i.ToString();
		}
	}

	void changeColor(GameObject blueBarrel){
		MeshRenderer mesh = blueBarrel.GetComponentInChildren<MeshRenderer> ();
		mesh.material = redColorBarrelMaterial;
	}

	// Update is called once per frame
	void Update () {
		int selectedBarrelIndex;
		foreach (ClickBarrel clicked in clickBarrel) {
			if(clicked.barrelFound == 1){
				barrel = clicked.gameObject;
				canvas.enabled = true;
				clicked.barrelFound = 0;
				selectedBarrelIndex = int.Parse(clicked.gameObject.name);
				if(angScript.angle != 9999f){
					angle[selectedBarrelIndex] = angScript.angle;
				}else{
					Debug.Log("Error in angleScript!");
				}
				changeColor(barrel);
				barrel.layer = 8;
				clicked.barrelFound = 0;
				break;
			}
		}

	}
}
