using UnityEngine;
using System.Collections;

public class testScript : MonoBehaviour {
	public Material secondMaterial;
	private MeshRenderer[] mesh;
	void Start(){
		mesh = GetComponentsInChildren<MeshRenderer> ();
	}

	void Update(){
		if(Input.GetKey(KeyCode.A)){
			mesh[0].material = secondMaterial;
		}
	}
}