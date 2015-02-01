using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CloudBoss : MonoBehaviour {
	public Transform Core;
	public Vector3[] positions;
	public float teleportTimer;
	public GameObject teleportAway;
	public GameObject teleportBack;

	private float _teleport;
	private bool doneParty;
	private EnemyScript enemy;
	private CloudBossChild[] clouds;
	private float lastJolt;

	private List<int> positionIDs;

	// Use this for initialization
	void Start () {
		enemy = GetComponent<EnemyScript>();
		clouds = GetComponentsInChildren<CloudBossChild>();

		positionIDs = new List<int>();
		for(int i = 0; i<positions.Length; i++)
			positionIDs.Add(i);

		lastJolt = 1000000;
		Jolt (false);
	}
	
	// Update is called once per frame
	void Update() {
		if(enemy.currentHealth <= lastJolt - 100) {
			Jolt (true);
		}

		if(!Core.gameObject.activeSelf) {
			_teleport += Time.deltaTime;
			if(!doneParty && _teleport > teleportTimer * 0.5f) {
				doneParty = true;
				GameObject back = (GameObject)Instantiate(teleportBack, Core.position, Quaternion.identity);
				Destroy(back, back.GetComponent<ParticleSystem>().startLifetime * 2);
			} else if(_teleport > teleportTimer) {
				doneParty = false;
				Core.gameObject.SetActive(true);
				_teleport = 0;

			}
		}
	}

	void Jolt (bool moveClouds)
	{
		Core.gameObject.SetActive(false);
		if(moveClouds) {
			GameObject away = (GameObject)Instantiate(teleportAway, Core.position, Quaternion.identity);
			Destroy(away, away.GetComponent<ParticleSystem>().startLifetime * 2);
		}

		lastJolt = enemy.currentHealth;
		int id = Random.Range (0, positionIDs.Count);
		Core.position = positions [id];

		positionIDs = new List<int>();
		for(int i = 0; i<positions.Length; i++)
			if(i != id)
				positionIDs.Add(i);

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
