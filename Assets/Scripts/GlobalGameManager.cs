using UnityEngine;
using System.Collections;

public class GlobalGameManager {
	public static int player1id = -1;
	public static int player2id = -1;
	public static int player3id = -1;
	public static int player4id = -1;

	public static int player1ship = 1;
	public static int player2ship = 1;
	public static int player3ship = 1;
	public static int player4ship = 1;

	public static int stage;

	public static bool bossAnim;

	public static void ResetPlayers() {
		player1id = -1;
		player2id = -1;
		player3id = -1;
		player4id = -1;
	}

	public static int NumberOfPlayers() {		
		int i = 0;
		if(player1id != -1)
			i++;
		if(player2id != -1)
			i++;
		if(player3id != -1)
			i++;
		if(player4id != -1)
			i++;
		return i;
	}

	public static int GetPlayerGamepad(int playerNumber) {
		if(playerNumber == 1)
			return player1id;
		if(playerNumber == 2)
			return player2id;
		if(playerNumber == 3)
			return player3id;
		if(playerNumber == 4)
			return player4id;

		return 0;
	}
	
	public static int GetPlayerNumber(int gamepadNumber) {
		if(player1id == gamepadNumber)
			return 1;
		if(player2id == gamepadNumber)
			return 2;
		if(player3id == gamepadNumber)
			return 3;
		if(player4id == gamepadNumber)
			return 4;
		
		return 0;
	}

	public static void AddNewPlayer(int gamepadId) {
		if(player1id == -1) {
			player1id = gamepadId;
		} else if(player2id == -1) {
			player2id = gamepadId;
		} else if(player3id == -1) {
			player3id = gamepadId;
		} else if(player4id == -1) {
			player4id = gamepadId;
		}
	}
	
	public static void RemovePlayer(int gamepadId) {
		if(player1id == gamepadId) {
			player1id = -1;
		}
		if(player2id == gamepadId) {
			player2id = -1;
		}
		if(player3id == gamepadId) {
			player3id = -1;
		}
		if(player4id == gamepadId) {
			player4id = -1;
		}
	}

	public static void SelectNewShip(int playerNumber, int newShip) {
		int shipId = newShip;
		if(shipId < 0)
			shipId = ShipManager.instance.ships.Length - 1;
		if(shipId > ShipManager.instance.ships.Length - 1)
			shipId = 0;

		if(playerNumber == 1)
			player1ship = shipId;
		if(playerNumber == 2)
			player2ship = shipId;
		if(playerNumber == 3)
			player3ship = shipId;
		if(playerNumber == 4)
			player4ship = shipId;
	}

	public static int GetPlayerShip(int playerNumber) {
		if(playerNumber == 1)
			return player1ship;
		if(playerNumber == 2)
			return player2ship;
		if(playerNumber == 3)
			return player3ship;
		if(playerNumber == 4)
			return player4ship;
		
		return 0;
	}
}
