using UnityEngine;
using System.Collections;

public class CloudBoss : MonoBehaviour {
	public Transform Core;
	public Vector3[] positions;
	private EnemyScript enemy;
	private CloudBossChild[] clouds;
	private float lastJolt;

	// Use this for initialization
	void Start () {
		enemy = GetComponent<EnemyScript>();
		clouds = GetComponentsInChildren<CloudBossChild>();
		Jolt (false);
	}
	
	// Update is called once per frame
	void Update() {
		if(enemy.currentHealth < lastJolt - 100) {
			Jolt (true);
		}
	}

	void Jolt (bool moveClouds)
	{
		lastJolt = enemy.currentHealth;
		Core.position = positions [Random.Range (0, positions.Length - 1)];

		if(moveClouds) {
			foreach (CloudBossChild c in clouds) {
				c.Reset ();
			}
		}
	}

	void OnDrawGizmosSelected() {
		foreach(Vector3 p in positions)
			Gizmos.DrawSphere(p, 1);
	}
}
