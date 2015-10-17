using UnityEngine;
using System.Collections;

public class splashLinker : MonoBehaviour {
	
	void Update () {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        { 
                Debug.Log(Logger.Log("Loading Game Name Screen"));
                Application.LoadLevel("GameName");
        }
	}
}
