using UnityEngine;
using System.Collections;

public class ContinueGame : MonoBehaviour {
	public bool isGameOver;

	// Update is called once per frame
	void Update () {
		if (InputManager.AnyAPress()) {	
			if(isGameOver) {
				EnemyScript.maxHealth = 3000;
				GlobalGameManager.stage = 1;
				gameHandler.minionSpawner = 15;
			} else {
				GlobalGameManager.stage++;

				if (gameHandler.minionSpawner >= 5){			
					gameHandler.minionSpawner = gameHandler.minionSpawner - 1;
				}
			}

			Application.LoadLevel (1);
		}

		if (InputManager.AnyBPress())
			Application.LoadLevel(0);
	}
}	
