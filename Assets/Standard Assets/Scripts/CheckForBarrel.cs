using UnityEngine;
using System.Collections;

public class CheckForBarrel : MonoBehaviour {
	private ClickBarrel[] clickBarrel;
	public GameObject clickedBarrel;
	// Use this for initialization
	void Start () {
		clickBarrel = GetComponentsInChildren<ClickBarrel> ();
	}
	
	// Update is called once per frame
	void Update () {
		foreach (ClickBarrel click in clickBarrel) {
			if(click.barrelFound == 1)
				clickedBarrel = click.gameObject;
		}
	}
}