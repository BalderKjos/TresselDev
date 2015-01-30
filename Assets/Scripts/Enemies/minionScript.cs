using UnityEngine;
using System.Collections;

public class minionScript : MonoBehaviour {

	public int maxHealth = 50;
	private int currentHealth;
	public GameObject Explosion;
	private Vector3 position;
	private bool direction;
	public float speed;
	
	// Use this for initialization
	void Start () {
		currentHealth = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 position = transform.position;
		if (position.x >= 7) {
			direction = true;
		}
		
		else if (position.x <= -7){
			direction = false;
		}

		if(direction)
			transform.Translate (Vector3.left * speed * Time.deltaTime);
		else
			transform.Translate (Vector3.left * -speed * Time.deltaTime);
	}
	
	void Damage() {
		//player takes damage
		currentHealth -= 1;
		if (currentHealth <= 0) {
			position = new Vector2 (gameObject.transform.position.x, gameObject.transform.position.y);
			Instantiate (Explosion,position,transform.rotation);
			Destroy (gameObject);
		}
	}
}
