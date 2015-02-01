using UnityEngine;
using System.Collections;

public class DamageArea : MonoBehaviour {
	public string[] ignoreTags;
	public float damagePerSecond;

	private float ticks;
	private float timer;

	void Start() {
		ticks = 1.0f / damagePerSecond;
	}

	void OnTriggerStay2D (Collider2D c) {
		HitSomething (c);
	}
	
	void OnCollisionStay2D(Collision2D c) {
		HitSomething (c.collider);
	}
	
	void HitSomething(Collider2D c) {
		if (c.gameObject.tag == "BulletBlocker") {
			Destroy (gameObject);
		} else {
			bool ignored = false;

			foreach(string s in ignoreTags) {
				if(c.gameObject.tag == s) {
					ignored = true;
					break;
				}
			}

			if(!ignored && c.gameObject.tag != "MovementBlocker") {
				timer += Time.deltaTime;
				if(timer > ticks) {
					timer -= ticks;
					c.gameObject.SendMessage("Damage", new DamageSource(1, transform.position), SendMessageOptions.DontRequireReceiver);
				}
			}
		}
	}
}
