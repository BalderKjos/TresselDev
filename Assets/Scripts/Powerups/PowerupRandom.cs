using UnityEngine;
using System.Collections;

public class PowerupRandom : PowerupChild {
	public Powerup[] randoms;

	public override void OnStartup()
	{

		int rand = Random.Range(0, randoms.Length-1);
		GameObject prefab = randoms[rand].ActiveChild;
		Vector3 lp = prefab.transform.localPosition;
		GameObject go = (GameObject)Instantiate(prefab);
		go.transform.parent = transform.parent;
		go.transform.localPosition = lp;

		if(go.GetComponent<PowerupChild>() != null) {
			go.GetComponent<PowerupChild>().Init(player, display, duration);
		}

		transform.parent.GetComponent<Powerup>().ActiveChild = go;

		Destroy(gameObject);
	}
}
