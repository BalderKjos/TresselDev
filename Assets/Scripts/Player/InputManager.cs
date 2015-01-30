using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {
	public static InputManager instance;

	public static PlayerInput Player1;
	public static PlayerInput Player2;
	public static PlayerInput Player3;
	public static PlayerInput Player4;

	void Start() {
		if(instance == null)
			instance = this;
		else
			Destroy(gameObject);

		DontDestroyOnLoad(gameObject);	

		Player1 = new PlayerInput();
		Player2 = new PlayerInput();
		Player3 = new PlayerInput();
		Player4 = new PlayerInput();
	}
	// Update is called once per frame
	void Update () {
		Player1.LeftX = Input.GetAxis("Horizontal1");
		Player1.LeftY = Input.GetAxis("Vertical1");
		Player1.RightX = Input.GetAxis("LookH1");
		Player1.RightY = Input.GetAxis("LookV1");
		Player1.A = Input.GetButton ("P1A");
		Player1.APress = Input.GetButtonDown ("P1A");
		Player1.B = Input.GetButton ("P1B");
		Player1.BPress = Input.GetButtonDown ("P1B");
		Player1.LeftBumber = Input.GetButton ("LTrigger1");
		Player1.LeftBumberPress = Input.GetButtonDown ("LTrigger1");
		Player1.RightBumber = Input.GetButton ("RTrigger1");
		Player1.RightBumberPress = Input.GetButtonDown ("RTrigger1");

		Player2.LeftX = Input.GetAxis("Horizontal2");
		Player2.LeftY = Input.GetAxis("Vertical2");
		Player2.RightX = Input.GetAxis("LookH2");
		Player2.RightY = Input.GetAxis("LookV2");
		Player2.A = Input.GetButton ("P2A");
		Player2.APress = Input.GetButtonDown ("P2A");
		Player2.B = Input.GetButton ("P2B");
		Player2.BPress = Input.GetButtonDown ("P2B");
		Player2.LeftBumber = Input.GetButton ("LTrigger2");
		Player2.LeftBumberPress = Input.GetButtonDown ("LTrigger2");
		Player2.RightBumber = Input.GetButton ("RTrigger2");
		Player2.RightBumberPress = Input.GetButtonDown ("RTrigger2");

		Player3.LeftX = Input.GetAxis("Horizontal3");
		Player3.LeftY = Input.GetAxis("Vertical3");
		Player3.RightX = Input.GetAxis("LookH3");
		Player3.RightY = Input.GetAxis("LookV3");
		Player3.A = Input.GetButton ("P3A");
		Player3.APress = Input.GetButtonDown ("P3A");
		Player3.B = Input.GetButton ("P3B");
		Player3.BPress = Input.GetButtonDown ("P3B");
		Player3.LeftBumber = Input.GetButton ("LTrigger3");
		Player3.LeftBumberPress = Input.GetButtonDown ("LTrigger3");
		Player3.RightBumber = Input.GetButton ("RTrigger3");
		Player3.RightBumberPress = Input.GetButtonDown ("RTrigger3");

		Player4.LeftX = Input.GetAxis("Horizontal4");
		Player4.LeftY = Input.GetAxis("Vertical4");
		Player4.RightX = Input.GetAxis("LookH4");
		Player4.RightY = Input.GetAxis("LookV4");
		Player4.A = Input.GetButton ("P4A");
		Player4.APress = Input.GetButtonDown ("P4A");
		Player4.B = Input.GetButton ("P4B");
		Player4.BPress = Input.GetButtonDown ("P4B");
		Player4.LeftBumber = Input.GetButton ("LTrigger4");
		Player4.LeftBumberPress = Input.GetButtonDown ("LTrigger4");
		Player4.RightBumber = Input.GetButton ("RTrigger4");
		Player4.RightBumberPress = Input.GetButtonDown ("RTrigger4");

	}

	public static bool PressedStart() {
		return Input.GetButtonDown("Start");
	}
	
	public static bool AnyAPress() {
		return Player1.APress || Player2.APress || Player3.APress || Player4.APress;
	}

	public static bool AnyBPress() {
		return Player1.BPress || Player2.BPress || Player3.BPress || Player4.BPress;
	}
	
	public static float GetLeftX(int player) {
		if(player == 2)
			return Player2.LeftX;
		if(player == 3)
			return Player3.LeftX;
		if(player == 4)
			return Player4.LeftX;
		return Player1.LeftX;
	}
	
	public static float GetLeftY(int player) {
		if(player == 2)
			return Player2.LeftY;
		if(player == 3)
			return Player3.LeftY;
		if(player == 4)
			return Player4.LeftY;
		return Player1.LeftY;
	}
	
	public static float GetRightX(int player) {
		if(player == 2)
			return Player2.RightX;
		if(player == 3)
			return Player3.RightX;
		if(player == 4)
			return Player4.RightX;
		return Player1.RightX;
	}
	
	public static float GetRightY(int player) {
		if(player == 2)
			return Player2.RightY;
		if(player == 3)
			return Player3.RightY;
		if(player == 4)
			return Player4.RightY;
		return Player1.RightY;
	}
	
	public static bool GetA(int player) {
		if(player == 2)
			return Player2.A;
		if(player == 3)
			return Player3.A;
		if(player == 4)
			return Player4.A;
		return Player1.A;
	}
	
	public static bool GetAPress(int player) {
		if(player == 2)
			return Player2.APress;
		if(player == 3)
			return Player3.APress;
		if(player == 4)
			return Player4.APress;
		return Player1.APress;
	}
	
	public static bool GetB(int player) {
		if(player == 2)
			return Player2.B;
		if(player == 3)
			return Player3.B;
		if(player == 4)
			return Player4.B;
		return Player1.B;
	}
	
	public static bool GetBPress(int player) {
		if(player == 2)
			return Player2.BPress;
		if(player == 3)
			return Player3.BPress;
		if(player == 4)
			return Player4.BPress;
		return Player1.BPress;
	}
	
	public static bool GetLeftBumper(int player) {
		if(player == 2)
			return Player2.LeftBumber;
		if(player == 3)
			return Player3.LeftBumber;
		if(player == 4)
			return Player4.LeftBumber;
		return Player1.LeftBumber;
	}
	
	public static bool GetLeftBumperPress(int player) {
		if(player == 2)
			return Player2.LeftBumberPress;
		if(player == 3)
			return Player3.LeftBumberPress;
		if(player == 4)
			return Player4.LeftBumberPress;
		return Player1.LeftBumberPress;
	}
	
	public static bool GetRightBumper(int player) {
		if(player == 2)
			return Player2.RightBumber;
		if(player == 3)
			return Player3.RightBumber;
		if(player == 4)
			return Player4.RightBumber;
		return Player1.RightBumber;
	}
	
	public static bool GetRightBumperPress(int player) {
		if(player == 2)
			return Player2.RightBumberPress;
		if(player == 3)
			return Player3.RightBumberPress;
		if(player == 4)
			return Player4.RightBumberPress;
		return Player1.RightBumberPress;
	}
}

public class PlayerInput {
	public float LeftX;
	public float LeftY;
	public float RightX;
	public float RightY;
	
	public bool A;
	public bool APress;

	public bool B;
	public bool BPress;

	public bool LeftBumber;
	public bool LeftBumberPress;
	
	public bool RightBumber;
	public bool RightBumberPress;
}
