using UnityEngine;
using System.Collections;

public class DEBUGControllerGUi : MonoBehaviour {
	public SelectScreen selectScreen;
	public int Player1;
	public int Player2;
	public int Player3;
	public int Player4;

	
	// Update is called once per frame
	void Update () {
		Player1 = GlobalGameManager.GetPlayerGamepad(1);
		Player2 = GlobalGameManager.GetPlayerGamepad(2);
		Player3 = GlobalGameManager.GetPlayerGamepad(3);
		Player4 = GlobalGameManager.GetPlayerGamepad(4);
	}
}