using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Powerup : MonoBehaviour {
	public float duration;
	public BossMovement IdleMovement;
	public GameObject IdleChild;
	public GameObject ActiveChild;

	private character player;

	// Use this for initialization
	void Start () {
		IdleMovement.enabled = true;

		IdleChild.SetActive(true);
		ActiveChild.SetActive(false);
	}

	void OnTriggerEnter2D (Collider2D c) {
		HitSomething (c);
	}
	
	void OnCollisionEnter2D(Collision2D c) {
		HitSomething (c.collider);
	}
	
	void HitSomething(Collider2D c) 
	{
		player = c.GetComponent<character>();

		if (player != null)
		{ 
			IdleMovement.enabled = false;
			IdleChild.SetActive(false);

			ActiveChild.GetComponent<PowerupChild>().Init(player, player.playerGui.ActivatePowerup(this), duration);

			Vector3 lp = ActiveChild.transform.localPosition;
			ActiveChild.transform.parent = player.transform;
			ActiveChild.transform.localPosition = lp;
			ActiveChild.transform.localRotation = Quaternion.identity;

			if(ActiveChild.GetComponent<BossMovement>() != null)
				ActiveChild.GetComponent<BossMovement>().ResetOrigin();

			ActiveChild.SetActive(true);
			Destroy(ActiveChild, duration);

			Destroy(gameObject);
		}
	}
}
