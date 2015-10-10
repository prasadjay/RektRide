using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class PerformanceMonitor : MonoBehaviour {

	float deltaTime = 0.0f;
	public Text Performance_Counter_TextLabel;
    Vector2 touchDeltaPosition;
    string touchside;
    public TouchGesture.GestureSettings GestureSetting;
    private TouchGesture touch;
	void Start() {
		Performance_Counter_TextLabel.color = Color.green;
        touchside =Application.persistentDataPath;
        Debug.Log(Application.persistentDataPath);

        touch = new TouchGesture(this.GestureSetting);
        StartCoroutine(touch.CheckHorizontalSwipes(
            onLeftSwipe: () => { touchside = "left"; },
            onRightSwipe: () => { touchside = "right"; },
             onUpSwipe: () => { touchside = "Up"; },
            onDownSwipe: () => { touchside = "Down"; }
            ));
	}
	void Update()
	{
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            // Get movement of the finger since last frame
            touchDeltaPosition = Input.GetTouch(0).deltaPosition;
        }

        //if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        //{
        //    // Get movement of the finger since last frame
        //    touchDeltaPosition = Input.GetTouch(0).position;
        //}



		deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
		float msec = deltaTime * 1000.0f;
		float fps = 1.0f / deltaTime;
        Performance_Counter_TextLabel.text = ((int)fps).ToString() + " FPS \n" + Screen.width.ToString() + " x " + Screen.height.ToString() + "\n" + ((int)touchDeltaPosition.x).ToString() + "\n" + ((int)touchDeltaPosition.y).ToString() + "\n"+ touchside;


	}
}
