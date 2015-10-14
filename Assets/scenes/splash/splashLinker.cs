using UnityEngine;
using System.Collections;

public class splashLinker : MonoBehaviour {
	
	void Update () {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            if (settings.Resolution.x == 0 && settings.Resolution.y == 0)
            {
                Application.Quit();
            }
            else { 
                Debug.Log(Logger.WriteLog("Loading Main Menu"));
            }
           
        }
	}
}
