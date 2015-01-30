using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnemyScript : MonoBehaviour {


	public static int maxHealth = 3000;
	public int currentHealth;
	public Slider healthBar;
	public float speed;
	public bool direction;
	public GameObject Explosion;
	private Vector2 position;

	public Vector2 limits = new Vector2(-7, 7);

	// Use this for initialization
	void Start () {
		currentHealth = maxHealth;
		if (healthBar != null) {
			healthBar.maxValue = maxHealth;
			healthBar.value = currentHealth;
		}
	}

	// Update is called once per frame
	void Update () {
		if (Debugger.isOn) {
			if(Input.GetKey(KeyCode.Space) && Input.GetKeyDown(KeyCode.K)) {
				currentHealth = (int)(currentHealth * 0.5f);
			}
				}

		if (currentHealth > 0) {
				Vector3 position = transform.position;
				if (position.x >= limits.y) {
						direction = true;
				} else if (position.x <= limits.x) {
						direction = false;
				}

				float sin = 0.01f * Mathf.Sin (Time.time + 1);
				if (direction)
						transform.Translate (Vector3.left * speed * Time.deltaTime + (Vector3.up * sin));
				else
						transform.Translate (Vector3.left * -speed * Time.deltaTime + (Vector3.up * sin));
		}
	}

	void Damage(DamageSource source) {
		if(healthBar != null)
			healthBar.value = currentHealth;

		//player takes damage
		currentHealth -= source.damageAmount;

		if (currentHealth <= (maxHealth / 2)) {
			gameHandler.instance.SpawnMinion();
				}


		if (currentHealth <= 0) {
			if(healthBar != null)
				healthBar.value = currentHealth;
			position = new Vector2 (gameObject.transform.position.x, gameObject.transform.position.y);
			Instantiate (Explosion,position,transform.rotation);
			CameraShaker.Shake(3, gameHandler.endSceneDelay * 0.2f);
			foreach(enemyParts ep in GetComponentsInChildren<enemyParts>()){
				ep.transform.parent = null;
				ep.ForceDestroy();
			}
			gameHandler.instance.KilledBoss();		
			Destroy (gameObject);
		}
	}

	void OnDrawGizmosSelected() {
		Vector3 a = new Vector3 (limits.x, transform.position.y, transform.position.z);
		Vector3 b = new Vector3 (limits.y, transform.position.y, transform.position.z);

		Gizmos.DrawLine (a, b);
		Gizmos.DrawWireSphere (a, 0.1f);
		Gizmos.DrawWireSphere (b, 0.1f);
	}
}
