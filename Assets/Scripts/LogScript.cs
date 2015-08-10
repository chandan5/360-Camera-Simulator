using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class LogScript : MonoBehaviour {
	public GameObject timerText;

	private GameObject WelcomeCam;
	private static int  allDone = 0;
	private static string playerName;
	private static string cameraName;

	private BarrelsScript barrelsScript;
	private TimerScript timerScript;

	private int lastMinute;
	private int lastSecond;

	private List<float> estimatedAngles = new List<float>();
	private List<float> actualAngles = new List<float>();
	private List<string> orderOfSelection = new List<string> ();
	private List<Vector3> allPositions = new List<Vector3> ();
	private static List<Vector3> barrelPositions = new List<Vector3> ();

	private GameObject[] barrels = new GameObject[12];

	// Use this for initialization
	void Start () {
		barrelsScript = gameObject.GetComponent<BarrelsScript> ();
		barrelsScript.returnLists (out estimatedAngles,out actualAngles,out orderOfSelection);
		barrels = barrelsScript.returnBarrelsArray ();

		WelcomeCam = GameObject.Find ("Welcome Camera");
		WelcomeCam.SetActive (false);

		playerName = WelcomeCam.GetComponent<WelcomeScript> ().returnName ();
		cameraName = gameObject.name;

		timerScript = timerText.GetComponent<TimerScript> ();

		for(int i = 0;i<12;i++){
			if(barrels[i].gameObject.layer == 8)
				barrelPositions.Add(barrels[i].gameObject.transform.position);

		}
	}
	public static void setStatus(int status){
		allDone = status;
	}

	public static void returnNames(out string camera,out string player){
		camera = cameraName;
		player = playerName;
	}

	public static void returnBarrelPositions(out List<Vector3> positions){
		positions = barrelPositions;
	}
	// Update is called once per frame
	void Update () {
		if (allDone == 1) {
			timerScript.returnAllPositions(out allPositions);

			if(Directory.Exists("./GAMELOGS/"+cameraName))
				Debug.Log("Directory already exits!");
			else 
				Directory.CreateDirectory("./GAMELOGS/"+cameraName);

			StreamWriter sw = new StreamWriter("./GAMELOGS/"+cameraName+"/"+playerName+"Angles.txt",false);
			sw.WriteLine("ESTIMATED ANGLES\tACTUAL ANGLES\tBARREL ID");
			for(int i=0; i < estimatedAngles.Count ; i++ ){
				sw.WriteLine(estimatedAngles[i]+" \t"+actualAngles[i]+"\t"+orderOfSelection[i]);
			}
			sw.WriteLine("\n");
			sw.WriteLine("---------------------------------------------------------------------");
			sw.WriteLine("---------------------------------------------------------------------");
			sw.WriteLine("\n");
			sw.WriteLine("BARREL ID\tLOCATION (IN WORLD COORDS)");
			for(int i = 0 ; i< 12 ; i++){
				sw.WriteLine(barrels[i].name+" \t"+barrels[i].transform.position);
			}
			sw.Close();

			sw = new StreamWriter("./GAMELOGS/"+cameraName+"/"+playerName+"AllPositions.txt",false);
			sw.WriteLine("All postions taken at each second\n-----------------------------------------------\n");
			for (int i = 0;i<allPositions.Count;i++){
				sw.WriteLine(allPositions[i]);
			}
			sw.WriteLine("------------------------------------------------------------------------------------\n");

			sw.WriteLine("TIME TAKEN :--");
			timerScript.returnTimeTaken(out lastMinute,out lastSecond);
			sw.WriteLine("\t"+lastMinute+" min "+lastSecond+" sec\n");

			sw.Close();

		}
	}
}
