using UnityEngine;
using System.Collections;
using System;

public class TouchGesture
{
    [System.Serializable]
    public class GestureSettings
    {
        public float minSwipeDist = 100;
        public float maxSwipeTime = 10;
    }

    private GestureSettings settings;
    private float swipeStartTime;
    private bool couldBeSwipe;
    private Vector2 startPos;
    private int stationaryForFrames;
    private TouchPhase lastPhase;

    public TouchGesture(GestureSettings gestureSettings)
    {
        this.settings = gestureSettings;
    }

    public IEnumerator CheckHorizontalSwipes(Action onLeftSwipe, Action onRightSwipe, Action onUpSwipe, Action onDownSwipe) //Coroutine, which gets Started in "Start()" and runs over the whole game to check for swipes
    {
        while (true)
        { 
            foreach (Touch touch in Input.touches)
            { 
                switch (touch.phase)
                {
                    case TouchPhase.Began: 
                        couldBeSwipe = true;
                        startPos = touch.position;  
                        swipeStartTime = Time.time; 
                        stationaryForFrames = 0;
                        break;

                    case TouchPhase.Stationary: 
                        if (isContinouslyStationary(frames: 6))
                            couldBeSwipe = false;
                        break;

                    case TouchPhase.Ended:
                        if (isASwipe(touch))
                        {
                            couldBeSwipe = false; 

                            if (Mathf.Sign(touch.position.x - startPos.x) == 1f) //Swipe-direction, either 1 or -1.   
                                onRightSwipe(); //Right-swipe
                            else
                                onLeftSwipe(); //Left-swipe
                        }
                        if (isVerticalSwipe(touch))
                        {
                            couldBeSwipe = false; //<-- Otherwise this part would be called over and over again.

                            if (Mathf.Sign(touch.position.y - startPos.y) == 1f) //Swipe-direction, either 1 or -1.   
                                onUpSwipe(); //Right-swipe
                            else
                                onDownSwipe(); //Left-swipe
                        }
                        break;
                }
                lastPhase = touch.phase;
            }
            yield return null;
        }
    }

    private bool isContinouslyStationary(int frames)
    {
        if (lastPhase == TouchPhase.Stationary)
            stationaryForFrames++;
        else // reset back to 1
            stationaryForFrames = 1;

        return stationaryForFrames > frames;
    }

    private bool isASwipe(Touch touch)
    {
        float swipeTime = Time.time - swipeStartTime; //Time the touch stayed at the screen till now.
        float swipeDist = Mathf.Abs(touch.position.x - startPos.x); //Swipe distance
        return couldBeSwipe && swipeTime < settings.maxSwipeTime && swipeDist > settings.minSwipeDist;
    }

        private bool isVerticalSwipe(Touch touch)
    {
        float swipeTime = Time.time - swipeStartTime; //Time the touch stayed at the screen till now.
        float swipeDist = Mathf.Abs(touch.position.y - startPos.y); //Swipe distance
        return couldBeSwipe && swipeTime < settings.maxSwipeTime && swipeDist > settings.minSwipeDist;
    }
}



