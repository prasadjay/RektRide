using UnityEngine;
using System.Collections;

public class MainMenuLinker : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void onPlayButtonPressed()
    {
        Debug.Log(Logger.Log("Loading Test Level"));
        Application.LoadLevel("testlevel");
    }

}
