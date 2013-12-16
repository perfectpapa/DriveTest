using UnityEngine;
using System.Collections;

public class LogitechLed : MonoBehaviour {
	
	int red,blue,green;
	public string effectLabel;
	
	// Use this for initialization
	void Start () {

		blue = 0;
		red = 0;
		green = 0;
		LogitechGSDK.LogiLedInit();
		LogitechGSDK.LogiLedSaveCurrentLighting(LogitechGSDK.LOGITECH_LED_ALL);
		//LogitechGSDK.LogiLedSetLighting(LogitechGSDK.LOGITECH_LED_ALL,0,0,0);
		effectLabel = "Press F to test flashing effect, P to test pulsing effect";
	}
	void OnGUI(){
		GUI.Label(new Rect(10, 250, 500, 50), effectLabel);
	}
	
	// Update is called once per frame
	void Update () {
		
		if(Input.GetKey(KeyCode.Mouse0)){
			//On mouse click set random color backlighting. In the monochrome backlighting devices it will change the brightness.
			System.Random random = new System.Random();
			red = random.Next(0, 100);
			blue = random.Next(0, 100);
			green = random.Next(0, 100);
			LogitechGSDK.LogiLedSetLighting(LogitechGSDK.LOGITECH_LED_KEYBOARD,red,blue,green);
		}
		if(Input.GetKey(KeyCode.Mouse1)){
			//On mouse click set random color backlighting. In the monochrome backlighting devices it will change the brightness.
			System.Random random = new System.Random();
			red = random.Next(0, 100);
			blue = random.Next(0, 100);
			green = random.Next(0, 100);
			LogitechGSDK.LogiLedSetLighting(LogitechGSDK.LOGITECH_LED_MOUSE,red,blue,green);
		}
		if(Input.GetKey(KeyCode.F)){
			//Flashing preset effect
			System.Random random = new System.Random();
			red = random.Next(0, 100);
			blue = random.Next(0, 100);
			green = random.Next(0, 100);
			LogitechGSDK.LogiLedFlashLighting(LogitechGSDK.LOGITECH_LED_ALL,red,blue,green,5000,200);
		}
		if(Input.GetKey(KeyCode.P)){
			//Pulsing preset effect
			System.Random random = new System.Random();
			red = random.Next(0, 100);
			blue = random.Next(0, 100);
			green = random.Next(0, 100);
			LogitechGSDK.LogiLedPulseLighting(LogitechGSDK.LOGITECH_LED_ALL,red,blue,green,5000);
		}
	}
	
	void OnDestroy () {
		//Before quitting, we need to restore the user's backlighting settings
		LogitechGSDK.LogiLedRestoreLighting(LogitechGSDK.LOGITECH_LED_ALL);
     	LogitechGSDK.LogiLedShutdown();
	}
}
