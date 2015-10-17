using UnityEngine;
using System.Collections;
using System.IO;
using System.Xml;
using UnityEngine.UI;

public class GraphicSettings : MonoBehaviour
{

    //THIS FILE INITIALIZES RESOLUTION DATA AND SAVES TO DISK/MEMORY
    // Use this for initialization
    void Awake()
    {

        Debug.Log(Logger.Log("Loading scene : " + Application.loadedLevelName));

        //Check for in memory settings

        if (settings.Resolution.x == 0 || settings.Resolution.y == 0)
        {
            Debug.Log(Logger.Log("New Game Instance....."));
            //check for file
            Vector2 valuesFromSettingsXML = XMLManager.readResolutionFromXML();

            if (valuesFromSettingsXML.x == 0 || valuesFromSettingsXML.y == 0)
            {
                //File Missing.. Just Use Default Resolution... No changes...
                Debug.Log(Logger.Log("Using Default Resolution"));
            }
            else
            {
                Debug.Log(Logger.Log("Using XML Resolution Data"));
                Screen.SetResolution((int)valuesFromSettingsXML.x, (int)valuesFromSettingsXML.y, Screen.fullScreen);
            }

            //write to memory
            settings.Resolution = valuesFromSettingsXML;

        }
        else
        {
            //Already in memory
            Screen.SetResolution((int)settings.Resolution.x, (int)settings.Resolution.y, Screen.fullScreen);
            Debug.Log(Logger.Log("Using In-Memory Resolution"));
        }

        Debug.Log(Logger.Log("Running Resolution : " + Screen.width.ToString() + "x" + Screen.height.ToString()));


    }

   

}
