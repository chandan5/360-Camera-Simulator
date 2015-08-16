using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class LOG : MonoBehaviour {
	public GameObject gameCamera;

	private StreamWriter logFile;
	private BS bsInLog;
	private List<float> estimations = new List<float>();
	private List<float> actuals = new List<float>();
	private List<string> order = new List<string>();
	private bool logged;

	// Use this for initialization
	void Start () {
		logged = true;
		if(Directory.Exists("./GAMELOGS/"+gameCamera.name))
			Debug.Log("Directory already exists!");
		else 
			Directory.CreateDirectory("./GAMELOGS/"+gameCamera.name);
		bsInLog = gameCamera.GetComponent<BS> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (bsInLog.canLog () && logged) {
			bsInLog.returnAllLists(out estimations,out actuals,out order);
			logFile = new StreamWriter("./GAMELOGS/"+gameCamera.name+"/PlayLog.txt");

			logFile.WriteLine("Estimated Angle\tActual Angle\tBarrel ID");
			logFile.WriteLine("-------------------------------------------");
			for(int i = 0;i<estimations.Count;i++){
				logFile.WriteLine(estimations[i]+"\t\t"+actuals[i]+"\t\t"+order[i]);
			}
			logFile.WriteLine("\n\n");
			logFile.WriteLine("Barrel ID\tPosition");
			for(int i=0;i<12;i++){
				logFile.WriteLine(i+"\t\t"+BS.getSpawnPositions()[i]);
			}
			logged = false;
		}
	}
}

