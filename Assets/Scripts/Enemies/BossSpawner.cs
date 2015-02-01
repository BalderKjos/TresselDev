using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BossSpawner : MonoBehaviour {
	public int debugPlayerCount = 1;
	
	public GameObject boss;
	public GameObject boss5;

	// Use this for initialization
	void Start () {
		GameObject prefab = boss;
		int stage = GlobalGameManager.stage;

		if(GlobalGameManager.stage % 5 == 0) {
			stage -= 5;
			prefab = boss5;
		}

		int bossNumber = (int)Mathf.Floor(stage / 5) + 1;
		
		Vector3 cp = Camera.main.ViewportToWorldPoint(new Vector3(0,0,10));
		Vector3 div = Camera.main.ViewportToWorldPoint(new Vector3(1,0,10));
		float w = (Vector3.Distance(cp, div) / (bossNumber + 1));
		
		transform.position = new Vector3(cp.x, transform.position.y, transform.position.z);
		
		for(int i = 1; i <= bossNumber; i++) {
			GameObject g = (GameObject)Instantiate(prefab);
			g.transform.parent = transform;
			g.transform.localPosition = new Vector3(w * i, 0, 0);
			if(g.GetComponent<BossMovement>() != null)
				g.GetComponent<BossMovement>().ResetOrigin(new Vector3(w * i, 0, 0));

			GameObject b = GuiManager.instance.NewBossHealthBar();

			if(g.GetComponent<EnemyScript>() != null) {
				g.GetComponent<EnemyScript>().SetHPBar(b.GetComponent<Slider>());
			} else {
				g.GetComponentInChildren<EnemyScript>().SetHPBar(b.GetComponent<Slider>());
			}
		}
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
