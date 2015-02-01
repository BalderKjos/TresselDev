using UnityEngine;
using System.Collections;

public class CloudBossChild : MonoBehaviour {
	public float knockback = 1;

	private Vector3 origin;
	private float speed = 0.1f;

	void Start() {
		origin = transform.localPosition;
	}

	void Update() {
		rigidbody2D.AddForce((transform.position - (transform.parent.position + origin)).normalized * -speed);

		if(speed > 0.1f) {
			speed -= Time.deltaTime * 10;
		} else {
			speed = 0.1f;
		}
	}

	// Update is called once per frame
	void Damage(DamageSource source) {
		rigidbody2D.AddForce((transform.position - source.hitPoint).normalized * source.damageAmount * knockback);
	}

	public void Reset() {
		transform.localPosition = origin;

		rigidbody2D.velocity = Vector2.zero;
		rigidbody2D.angularVelocity	 = 0;
		speed = 10;
	}
}
