using UnityEngine;
using System.Collections;
using System.IO;
using System;

public class Logger : MonoBehaviour {
	private static bool isLoggerEnabled= true;
	private static ArrayList screenLogs = new ArrayList ();
	private static int MaxScreenLogEntries= 15;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public static string WriteLog(string Message, string originClass){
		DateTime now = DateTime.Now;
		string LogMessage = "[ " + now + " ] @ " + originClass + " : " + Message;
		string ScreenMessage = originClass + " : " + Message;

        //write to file
        string logFileName = Application.persistentDataPath + "/RektRideEventLog.txt";
 
         try
         {

             if (File.Exists(logFileName) || !File.Exists(logFileName))
             {
                 File.AppendAllText(logFileName, (LogMessage+"\r\n"), System.Text.Encoding.UTF8);
             }
           
         }catch (Exception ex) {
             Debug.Log(ex.Message);
         }

		//Write to Screen 
		WriteLogToScreen (ScreenMessage);
		//Write to Unity Prompt
		Debug.Log (ScreenMessage);

		return GetScreenLogs();
	}
	
	public static string GetScreenLogs(){
		string returnString = "";
		foreach (string value in screenLogs){
			returnString += value + "\n";
		}
		return returnString;
	}

	public static void WriteLogToScreen(string message){
		if (screenLogs.Count == MaxScreenLogEntries){
			screenLogs.RemoveAt(0);
			screenLogs.Add (message);
		}else{
			screenLogs.Add (message);
		}
	}


}
