using UnityEngine;
using System.Collections;

public class PlayerSpawner : MonoBehaviour {
	public Transform p1;
	public Transform p2;
	public Transform p3;
	public Transform p4;

	public int debugPlayerCount = 1;

	// Use this for initialization
	void Start () {
		int playerCount = GlobalGameManager.NumberOfPlayers();

		Vector3 cp = Camera.main.ViewportToWorldPoint(new Vector3(0,0,10));
		Vector3 div = Camera.main.ViewportToWorldPoint(new Vector3(1,0,10));
		float w = Vector3.Distance(cp, div) / (playerCount+1);

		transform.position = new Vector3(cp.x, transform.position.y, transform.position.z);

		if(playerCount >= 1)
			p1.localPosition = new Vector3(w * 1, 0, 0);
		if(playerCount >= 2)
			p2.localPosition = new Vector3(w * 2, 0, 0);
		if(playerCount >= 3)
			p3.localPosition = new Vector3(w * 3, 0, 0);
		if(playerCount >= 4)
			p4.localPosition = new Vector3(w * 4, 0, 0);
	}

	void OnDrawGizmosSelected() {
		Vector3 cp = Camera.main.ViewportToWorldPoint(new Vector3(0,0,10));
		Vector3 div = Camera.main.ViewportToWorldPoint(new Vector3(1,0,10));
		float w = Vector3.Distance(cp, div) / (debugPlayerCount+1);

		Gizmos.DrawWireSphere(transform.position + new Vector3(w*1,0,0), 0.1f);
		Gizmos.DrawWireSphere(transform.position + new Vector3(w*2,0,0), 0.1f);
		Gizmos.DrawWireSphere(transform.position + new Vector3(w*3,0,0), 0.1f);
		Gizmos.DrawWireSphere(transform.position + new Vector3(w*4,0,0), 0.1f);

		Gizmos.DrawSphere(cp, 0.1f);
		Gizmos.DrawSphere(div, 0.1f);
	}
}
