using UnityEngine;
using System.Collections;

public class Eventscript : MonoBehaviour {
	public string currentText = "";
	public GameObject debugText;

	// Use this for initialization
	void Start () {

		currentText = "";
	}
	
	// Update is called once per frame
	void Update () {
		if(debugText != null)
			debugText.SetActive (Debugger.isOn);

		if (InputManager.AnyAPress()) {
				Application.LoadLevel (5);
						EnemyScript.maxHealth = 3000;
						GlobalGameManager.stage = 1;
						gameHandler.minionSpawner = 15;
				}

		if (InputManager.AnyBPress()) {
						Application.Quit ();
				}
		if(Application.isEditor) {
			if (Input.GetKeyDown (KeyCode.D)) {
						currentText += "d";
				} else if (currentText == "d" && Input.GetKeyDown (KeyCode.E)) {
						currentText += "e";
				} else if (currentText == "de" && Input.GetKeyDown (KeyCode.B)) {
						currentText += "b";
				} else if (currentText == "deb" && Input.GetKeyDown (KeyCode.U)) {
						currentText += "u";
				} else if (currentText == "debu" && Input.GetKeyDown (KeyCode.G)) {
						Debugger.isOn = true;
				}
		}

		if(Debugger.isOn) {
			if(Input.GetKey(KeyCode.Space) && Input.GetKeyDown(KeyCode.Keypad1)) {
				Application.LoadLevel(5);
				EnemyScript.maxHealth = 3000;
				GlobalGameManager.stage = 2;
				gameHandler.minionSpawner = 15;
			}
			if(Input.GetKey(KeyCode.Space) && Input.GetKeyDown(KeyCode.Keypad2)) {
				Application.LoadLevel(5);
				EnemyScript.maxHealth = 3000;
				GlobalGameManager.stage = 3;
				gameHandler.minionSpawner = 15;
			}
			if(Input.GetKey(KeyCode.Space) && Input.GetKeyDown(KeyCode.Keypad3)) {
				Application.LoadLevel(5);
				EnemyScript.maxHealth = 3000;
				GlobalGameManager.stage = 4;
				gameHandler.minionSpawner = 15;
			}
			if(Input.GetKey(KeyCode.Space) && Input.GetKeyDown(KeyCode.Keypad4)) {
				Application.LoadLevel(5);
				EnemyScript.maxHealth = 3000;
				GlobalGameManager.stage = 5;
				gameHandler.minionSpawner = 15;
			}
		}
	}
}	
