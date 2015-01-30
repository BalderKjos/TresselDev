using UnityEngine;
using System.Collections;

public class enemyParts : MonoBehaviour {

	public int maxHealth = 500;
	private int currentHealth;
	public GameObject Explosion;
	//private Vector2 position;
	public GameObject mainBody;
	public bool multiplier = false;

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
				transform.Translate((Vector3.down * 0.01f) + (Vector3.left * sin));

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

	void Damage() {
		//player takes damage
		currentHealth -= 1;

		if(mainBody != null) {
			mainBody.SendMessage("Damage", SendMessageOptions.DontRequireReceiver);
			if (multiplier == true)
				mainBody.SendMessage("Damage", SendMessageOptions.DontRequireReceiver);
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
