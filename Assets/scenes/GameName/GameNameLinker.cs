using UnityEngine;
using System.Collections;

public class GameNameLinker : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
                Debug.Log(Logger.Log("Loading Main Menu"));
                Application.LoadLevel("MainMenu");
        }
	}
}
