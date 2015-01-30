using UnityEngine;
using System.Collections;

public class TestScene : MonoBehaviour {
	public TestScenePowerup[] powerups;

	// Update is called once per frame
	void Update () {
		foreach(TestScenePowerup p in powerups) {
			if(Input.GetKeyDown(p.spawnKey)) {
				Instantiate(p.prefab, transform.position, Quaternion.identity);
			}
		}
	}
}

[System.Serializable]
public class TestScenePowerup {
	public GameObject prefab;
	public KeyCode spawnKey;
}
