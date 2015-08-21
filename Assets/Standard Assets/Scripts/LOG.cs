using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class LOG : MonoBehaviour {

	public GameObject compassTimer;

	private TS tsScript;
	private StreamWriter logFile;
	private BS bsInLog;
	private List<float> estimations = new List<float>();
	private List<float> actuals = new List<float>();
	private List<string> order = new List<string>();
	private bool logged;
	private static string nameOfCamType;

	// Use this for initialization
	void Start () {
		nameOfCamType = gameObject.name;
		logged = true;
		bsInLog = gameObject.GetComponent<BS> ();
		tsScript = compassTimer.GetComponent<TS> ();
		if(Directory.Exists("./GAMELOGS/"+WS.returnPlayerName()+"/"+gameObject.name))
			Debug.Log("Directory already exists!");
		else 
			Directory.CreateDirectory("./GAMELOGS/"+WS.returnPlayerName()+"/"+gameObject.name);

	}

	public static string returnCamType(){
		return nameOfCamType;
	}
	
	// Update is called once per frame
	void Update () {
		if ((bsInLog.canLog () && logged) || (tsScript.timeUp() && logged)) {

			List<Vector3> pathLog = new List<Vector3>();
			bsInLog.returnAllLists(out estimations,out actuals,out order);

			logFile = new StreamWriter("./GAMELOGS/"+WS.returnPlayerName()+"/"+gameObject.name+"/PlayLog.txt");
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
			logFile.Close();

			logFile = new StreamWriter("./GAMELOGS/"+WS.returnPlayerName()+"/"+gameObject.name+"/PathLog.txt");
			bsInLog.returnPathLog(out pathLog);
			for(int i = 0;i<pathLog.Count;i++){
				logFile.WriteLine(pathLog[i]);
			}
			logFile.Close();
			Application.LoadLevel(2);
			logged = false;
		}
	}
}