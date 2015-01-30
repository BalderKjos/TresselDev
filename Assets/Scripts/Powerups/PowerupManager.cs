using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PowerupManager : MonoBehaviour {
	public static PowerupManager instance;

	public PowerupManagerElement[] powerups;

	private List<GameObject> _powerups;

	// Use this for initialization
	void Start () {
		if(instance == null)
			instance = this;
		else
			Destroy(gameObject);
		
		DontDestroyOnLoad(gameObject);

		_powerups = new List<GameObject>();
		foreach(PowerupManagerElement pme in powerups) {
			for(int i = 0; i <= pme.weight; i++) {
				_powerups.Add(pme.prefab);	
			}
		}
	}
	
	public void SpawnPowerup() {
		SpawnPowerup(Random.Range(0, _powerups.Count -1));
	}

	public void SpawnPowerup(int i) {
		Instantiate(_powerups[i], Vector3.zero, Quaternion.identity);
	}
}

[System.Serializable]
public class PowerupManagerElement {
	public GameObject prefab;
	public int weight = 1;
}