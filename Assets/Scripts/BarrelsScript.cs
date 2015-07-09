﻿using UnityEngine;
using System.Collections;

public class BarrelsScript : MonoBehaviour {
	public GameObject barrelPrefab;
	private GameObject[] barrels = new GameObject[12];
	public Canvas canvas;

	// Use this for initialization
	void Start () {
		randomPlacement (12f, 12f, 250f, 250f, 0, 3);
		randomPlacement (255f, 12f, 485f, 250f, 3, 6);
		randomPlacement (12f, 255f, 250f, 485f, 6, 9);
		randomPlacement (255f, 255f, 485f, 485f, 9, 12);
		canvas.enabled = false;
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
		}
	}

	// Update is called once per frame
	void Update () {
		
	}
}
