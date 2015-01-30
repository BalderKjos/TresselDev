using UnityEngine;
using System.Collections;

public class enemyParts : MonoBehaviour {

	public int maxHealth = 500;
	private int currentHealth;
	public GameObject Explosion;
	//private Vector2 position;
	public GameObject mainBody;
	public bool multiplier = false;

	public Vector3 deathAngle = new Vector3(0,1,0);
	private float deathAnimTimer = 2;
	private bool kabooooom;

	// Use this for initialization
	void Start () {
		kabooooom = false;
		currentHealth = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
		if (currentHealth <= 0) {
			deathAnimTimer -= Time.deltaTime;
			GetComponent<SpriteRenderer>().color = new Color(1,1,1,deathAnimTimer);

			if(Explosion != null) {
				float sin = 0.1f * Mathf.Sin (Time.time * 50);
				transform.Translate((deathAngle * 0.01f) + (new Vector3(deathAngle.y, deathAngle.x, 0) * sin));

				if(Mathf.Floor(deathAnimTimer * 10) % 4 == 0) {
					if(!kabooooom) {
						kabooooom = true;
						Instantiate (Explosion,transform.position + new Vector3(Random.Range(-1.0f,1.0f), Random.Range(-1.0f,1.0f)),transform.rotation);
					}
				} else {
					kabooooom = false;
				}
			}

			if(deathAnimTimer <= 0)
				Destroy (gameObject);
		}
	}

	public void ForceDestroy() {
		currentHealth = 0;
		Instantiate (Explosion,transform.position,transform.rotation);
		CameraShaker.Shake(1,deathAnimTimer);
		GetComponent<PolygonCollider2D>().enabled = false;
	}

	void Damage(DamageSource source) {
		//player takes damage
		currentHealth -= 1;

		if(mainBody != null) {
			if (multiplier == true)
				source.damageAmount *= 2;
			mainBody.SendMessage("Damage", source, SendMessageOptions.DontRequireReceiver);
		}

		if (currentHealth <= 0) {
			//position = new Vector2 (gameObject.transform.position.x, gameObject.transform.position.y);
			if(Explosion != null)
				Instantiate (Explosion,transform.position,transform.rotation);
			CameraShaker.Shake(1,deathAnimTimer);
			if(GetComponent<PolygonCollider2D>() != null)
				GetComponent<PolygonCollider2D>().enabled = false;
		}
	}

}
