using UnityEngine;
using System.Collections;

public class gameHandler : MonoBehaviour {
	public static gameHandler instance;

	public static int endSceneDelay = 5;
	public static int deadPlayers;
	public GameObject minion;
	private bool minionCheck = false;
	private Vector2 position;
	private float timer;
	private float timer2;
	private int randomizer;
	private Vector2 spawnLoc1 = new Vector2 (15f,5f);
	private Vector2 spawnLoc2 = new Vector2 (-15f,5f);
	private Vector2 spawnLoc;
	public static float minionSpawner = 15;
	public int bossNumbers;

	private float powerupTimer;

	// Use this for initialization
	void Start () {
		instance = this;

		//if (Camera.main.GetComponent<CameraShaker> () == null)
						//Camera.main.gameObject.AddComponent<CameraShaker> ();

		deadPlayers = 0;
	}

	public void KilledBoss() {
		bossNumbers--;

	}

	public void SpawnPowerup()
	{
		PowerupManager.instance.SpawnPowerup();
	}

	public void SpawnMinion ()
	{
		if (bossNumbers > 0) {
				if (minionCheck == false) {
						randomizer = Random.Range (1, 3);
						if (randomizer == 1)
								spawnLoc = spawnLoc1;
						if (randomizer == 2)
								spawnLoc = spawnLoc2;
						position = spawnLoc;
						Instantiate (minion, position, transform.rotation);
						minionCheck = true;
				} else {
						timer2 += Time.deltaTime;
						if (timer2 >= minionSpawner) {
								minionCheck = false;
								timer2 = 0;
						}
				}
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (deadPlayers >= GlobalGameManager.NumberOfPlayers()){
			deadPlayers = 0;
			Application.LoadLevel (2);
		}

		if (bossNumbers <= 0) {
			timer += Time.deltaTime;
			if (timer >= endSceneDelay)
				Application.LoadLevel (3);
		}

		if (Input.GetKey (KeyCode.Escape)) {
			Application.Quit();
		}

		if(powerupTimer >= 30 * GlobalGameManager.NumberOfPlayers()) {
			SpawnPowerup();
			powerupTimer = 0;
		} else {
			powerupTimer += Time.deltaTime;
		}
	}
}
