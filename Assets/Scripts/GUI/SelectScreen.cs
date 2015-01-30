using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SelectScreen : MonoBehaviour {
	private bool p1joined;
	private bool p2joined;
	private bool p3joined;
	private bool p4joined;

	private bool p1Ready;
	private bool p2Ready;
	private bool p3Ready;
	private bool p4Ready;

	private bool p1changed;
	private bool p2changed;
	private bool p3changed;
	private bool p4changed;

	public SelectScreenPlayer p1;
	public SelectScreenPlayer p2;
	public SelectScreenPlayer p3;
	public SelectScreenPlayer p4;

	public Button backButton;
	public Button startButton;

	// Use this for initialization
	void Start () {
		GlobalGameManager.ResetPlayers();

		p1joined = false;
		p2joined = false;
		p3joined = false;
		p4joined = false;
		p1Ready = false;
		p2Ready = false;
		p3Ready = false;
		p4Ready = false;

		p1changed = false;
		p2changed = false;
		p3changed = false;
		p4changed = false;
	}

	public void BackPressed() {
		Application.LoadLevel(0);
	}

	public void PlayGame ()
	{
		Application.LoadLevel (1);
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.Escape)) {
			BackPressed();
		}
		if(!p1joined && !p2joined && !p3joined && !p4joined) {
			backButton.interactable = true;
			if(InputManager.AnyBPress())
				BackPressed();
		} else {
			backButton.interactable = false;
		}

		CheckPlayerJoin ();
		CheckPlayerLeave ();		
		CheckShipSelect ();

		if((p1Ready || !p1joined) && (p2Ready || !p2joined) && (p3Ready || !p3joined) && (p4Ready || !p4joined)) {
			startButton.interactable = true;
			if(InputManager.PressedStart())
				PlayGame ();
		} else {
			startButton.interactable = false;
		}

		if(Debugger.isOn && Input.GetKeyDown(KeyCode.Backspace)) {
			Application.LoadLevel(6);
		}
		if(Debugger.isOn && Input.GetKeyDown(KeyCode.T)) {
			Application.LoadLevel(7);
		}
	}

	void UpdateVisuals(int gamepad) {
		int pnumber = GlobalGameManager.GetPlayerNumber(gamepad);

		if(gamepad == 1) {
			GetPlayerDisplay(pnumber).UpdateVisual(pnumber, p1joined, p1Ready);
		}
		if(gamepad == 2) {
			GetPlayerDisplay(pnumber).UpdateVisual(pnumber, p2joined, p2Ready);
		}
		if(gamepad == 3) {
			GetPlayerDisplay(pnumber).UpdateVisual(pnumber, p3joined, p3Ready);
		}
		if(gamepad == 4) {
			GetPlayerDisplay(pnumber).UpdateVisual(pnumber, p4joined, p4Ready);
		}
	}

	SelectScreenPlayer GetPlayerDisplay(int player) {
		if(player == 1)
			return p1;
		if(player == 2)
			return p2;
		if(player == 3)
			return p3;
		if(player == 4)
			return p4;
		return null;
	}

	void CheckPlayerJoin ()
	{
		if (InputManager.Player1.APress) {
			if (p1joined) {
				p1Ready = true;

				UpdateVisuals(1);
			}
			else {
				GlobalGameManager.AddNewPlayer (1);
				p1joined = true;
				UpdateVisuals(1);
			}
		}
		if (InputManager.Player2.APress) {
			if (p2joined) {
				p2Ready = true;
				UpdateVisuals(2);
			}
			else {
				GlobalGameManager.AddNewPlayer (2);
				p2joined = true;
				UpdateVisuals(2);
			}
		}
		if (InputManager.Player3.APress) {
			if (p3joined) {
				p3Ready = true;
				UpdateVisuals(3);
			}
			else {
				GlobalGameManager.AddNewPlayer (3);
				p3joined = true;
				UpdateVisuals(3);
			}
		}
		
		if (InputManager.Player4.APress) {
			if (p4joined) {
				p4Ready = true;
				UpdateVisuals(4);
			}
			else {
				GlobalGameManager.AddNewPlayer (4);
				p4joined = true;
				UpdateVisuals(4);
			}
		}
	}

	void CheckPlayerLeave ()
	{
		if (InputManager.Player1.BPress) {
			if (p1Ready) {
				p1Ready = false;
				UpdateVisuals(1);
			}
			else {
				p1joined = false;
				UpdateVisuals(1);
				GlobalGameManager.RemovePlayer (1);
			}
		}
		if (InputManager.Player2.BPress) {
			if (p2Ready) {
				p2Ready = false;
				UpdateVisuals(2);
			}
			else {
				p2joined = false;
				UpdateVisuals(2);
				GlobalGameManager.RemovePlayer (2);
			}
		}
		if (InputManager.Player3.BPress) {
			if (p3Ready) {
				p3Ready = false;
				UpdateVisuals(3);
			}
			else {
				p3joined = false;
				UpdateVisuals(3);
				GlobalGameManager.RemovePlayer (3);
			}
		}
		if (InputManager.Player4.BPress) {
			if (p4Ready) {
				p4Ready = false;
				UpdateVisuals(4);
			}
			else {
				p4joined = false;
				UpdateVisuals(4);
				GlobalGameManager.RemovePlayer (4);
			}
		}
	}

	void CheckShipSelect ()
	{
		if (p1joined && !p1Ready) {
			float inputY = InputManager.Player1.LeftY;
			int Pnumber = GlobalGameManager.GetPlayerNumber (1);
			if (inputY > 0.1f) {
				if (!p1changed) {
					GlobalGameManager.SelectNewShip (Pnumber, GlobalGameManager.GetPlayerShip (Pnumber) + 1);
					p1changed = true;
					UpdateVisuals(1);
				}
			}
			else
				if (inputY < -0.1f) {
					if (!p1changed) {
						GlobalGameManager.SelectNewShip (Pnumber, GlobalGameManager.GetPlayerShip (Pnumber) - 1);
						p1changed = true;
					UpdateVisuals(1);
				}
				}
				else {
					p1changed = false;
				}
		}

		if (p2joined && !p2Ready) {
			float inputY = InputManager.Player2.LeftY;
			int Pnumber = GlobalGameManager.GetPlayerNumber (2);
			if (inputY > 0.1f) {
				if (!p2changed) {
					GlobalGameManager.SelectNewShip (Pnumber, GlobalGameManager.GetPlayerShip (Pnumber) + 1);
					p2changed = true;
					UpdateVisuals(2);
				}
			}
			else
			if (inputY < -0.1f) {
				if (!p2changed) {
					GlobalGameManager.SelectNewShip (Pnumber, GlobalGameManager.GetPlayerShip (Pnumber) - 1);
					p2changed = true;
					UpdateVisuals(2);
				}
			}
			else {
				p2changed = false;
			}
		}

		if (p3joined && !p3Ready) {
			float inputY = InputManager.Player3.LeftY;
			int Pnumber = GlobalGameManager.GetPlayerNumber (3);
			if (inputY > 0.1f) {
				if (!p3changed) {
					GlobalGameManager.SelectNewShip (Pnumber, GlobalGameManager.GetPlayerShip (Pnumber) + 1);
					p3changed = true;
					UpdateVisuals(3);
				}
			}
			else
			if (inputY < -0.1f) {
				if (!p3changed) {
					GlobalGameManager.SelectNewShip (Pnumber, GlobalGameManager.GetPlayerShip (Pnumber) - 1);
					p3changed = true;
					UpdateVisuals(3);
				}
			}
			else {
				p3changed = false;
			}
		}
		
		if (p4joined && !p4Ready) {
			float inputY = InputManager.Player4.LeftY;
			int Pnumber = GlobalGameManager.GetPlayerNumber (4);
			if (inputY > 0.1f) {
				if (!p4changed) {
					GlobalGameManager.SelectNewShip (Pnumber, GlobalGameManager.GetPlayerShip (Pnumber) + 1);
					p4changed = true;
					UpdateVisuals(4);
				}
			}
			else
			if (inputY < -0.1f) {
				if (!p4changed) {
					GlobalGameManager.SelectNewShip (Pnumber, GlobalGameManager.GetPlayerShip (Pnumber) - 1);
					p4changed = true;
					UpdateVisuals(4);
				}
			}
			else {
				p4changed = false;
			}
		}
	}
}
