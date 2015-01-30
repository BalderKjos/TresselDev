using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {
	public string ignoreTag;
	public string ignoreTag2;
	public string ignoreTag3;
	public string ignoreTag4;
	public string ignoreTag5;
	public string ignoreTag6;
	public string ignoreTag7;
	public string grazeTag;
	public float speed = 1f;
	public int playerNum;
	public GameObject sparks;
	public GameObject Explosion2;
	Vector3 bulletPosition;
	Object instantiatedObject;
	private float time;

	// Use this for initialization
	void Start () {
	
		if (GetComponent<AudioSource>()!=null){
			GetComponent<AudioSource>().pitch = Random.Range (0.9f,1.1f);
		}
	}
	
	// Update is called once per frame
	void Update () {
		time = Time.deltaTime * 30;
		transform.Translate (Vector3.up * speed * Time.deltaTime);
	}

	void OnTriggerEnter2D (Collider2D c) {
		HitSomething (c);
	}

	void OnCollisionEnter2D(Collision2D c) {
		HitSomething (c.collider);
		}

	void HitSomething(Collider2D c) {

		if (c.gameObject.tag == "BulletBlocker") {
			Destroy (gameObject);
		}

		else if (c.gameObject.tag != ignoreTag && c.gameObject.tag != ignoreTag2 
		    && c.gameObject.tag != ignoreTag3 && c.gameObject.tag != ignoreTag4 
		    && c.gameObject.tag != ignoreTag5 && c.gameObject.tag != ignoreTag6 
		    && c.gameObject.tag != grazeTag && c.gameObject.tag != ignoreTag7
		    && c.gameObject.tag != "MovementBlocker")
		{
			c.gameObject.SendMessage("Damage", SendMessageOptions.DontRequireReceiver);

			if (c.gameObject.tag == "Enemy"){
				bulletPosition = new Vector2 (gameObject.transform.position.x, gameObject.transform.position.y);
				instantiatedObject = Instantiate (Explosion2,bulletPosition,transform.rotation);
				((GameObject)instantiatedObject).transform.parent = c.gameObject.transform;
				Destroy(instantiatedObject, time);
			}


			Destroy (gameObject);
		}
	else if (c.gameObject.tag == grazeTag) {
		bulletPosition = new Vector2 (gameObject.transform.position.x, gameObject.transform.position.y);
		instantiatedObject = Instantiate (sparks,bulletPosition,transform.rotation);
		((GameObject)instantiatedObject).transform.parent = c.gameObject.transform;
		Destroy(instantiatedObject, time);
		}
}
}