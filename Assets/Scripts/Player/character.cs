using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class character : MonoBehaviour {
	public GameObject Visual;
	public float speed = 5f;
	public float maxSpeed = 5f;
	public float boostSpeed = 10f;
	private Vector2 movement;
	public int player = 1;
	public float maxBoost = 3;
	private float boost = 1;
	private bool shield = false;
	public float fireSpeed = 0.1f;
	private float fireCooldown;
	public GameObject bullet;
	public Transform muzzleA;
	public Transform muzzleB;
	public ParticleSystem exaust;
	public GameObject ShieldObject;
	public GameObject playerExplosion;
	Vector2 position;
	public GameObject playerHurt;

	public int maxHealth = 10;
	public int currentHealth;

	public PlayerGui playerGui;

	void Start () {
		if(GlobalGameManager.GetPlayerGamepad(player) == -1) {
			if(playerGui != null)
				Destroy(playerGui.gameObject);
			Destroy(gameObject);
		}

		currentHealth = maxHealth;
		boost = maxBoost;

		Destroy(Visual);
		Visual = (GameObject)Instantiate(ShipManager.instance.ships[GlobalGameManager.GetPlayerShip(player)]);
		Visual.transform.parent = transform;
		Visual.transform.localPosition = Vector3.zero;
		Visual.transform.localScale = Vector3.one;
		Visual.GetComponent<ShipVisuals>().UpdateVisuals(ShipManager.instance.GetColor(player));
		ShieldObject.GetComponentInChildren<ParticleSystem>().startColor = ShipManager.instance.GetColor(player);

		if (playerGui != null) {
			playerGui.SetupBars(maxHealth, maxBoost, ShipManager.instance.GetColor(player));
			playerGui.UpdateBars(currentHealth, boost);
		}
	}
	// Update is called once per frame
	void Update () {

		float inputX = InputManager.GetLeftX(GlobalGameManager.GetPlayerGamepad(player));
		float inputY = InputManager.GetLeftY(GlobalGameManager.GetPlayerGamepad(player));
		
		movement = new Vector2(
			inputX * speed,
			inputY * speed
			);
		
		movement = new Vector2(
			Mathf.Clamp(movement.x, -maxSpeed, maxSpeed),
			Mathf.Clamp(movement.y, -maxSpeed, maxSpeed)
			);

		//float inputLT = Input.GetAxis ("LTrigger" + player);
		//float inputRT = Input.GetAxis ("RTrigger" + player);
		shield = InputManager.GetLeftBumper(GlobalGameManager.GetPlayerGamepad(player));
		ShieldObject.SetActive(shield);

		if (InputManager.GetRightBumper(GlobalGameManager.GetPlayerGamepad(player))) {
						if (boost > 0) {
								rigidbody2D.AddForce (movement * boostSpeed, ForceMode2D.Force);
								//maxSpeed = 50f;
								//speed = 50f;
								//Debug.Log ("HELLO!" + player + "_" + Time.deltaTime);
								boost -= Time.deltaTime;
								exaust.enableEmission = true;
						} else {
				exaust.enableEmission = false;
			}
				} else if (boost < maxBoost) {
			exaust.enableEmission = false;
						boost += Time.deltaTime;
				} else {
			exaust.enableEmission = false;
				}
		float inputX2 = InputManager.GetRightX(GlobalGameManager.GetPlayerGamepad(player));
		float inputY2 = InputManager.GetRightY(GlobalGameManager.GetPlayerGamepad(player));

		if (inputX2 > 0.5f || inputX2 < -0.5f || inputY2 > 0.5f || inputY2 < -0.5f) {
			transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, Mathf.Atan2(-inputX2, -inputY2) * Mathf.Rad2Deg);
			if (!shield && !GlobalGameManager.bossAnim){
				if (fireCooldown >= fireSpeed){
					Instantiate (bullet,muzzleA.position,transform.rotation);
					Instantiate (bullet,muzzleB.position,transform.rotation);
					fireCooldown = 0;
				}
			}
			//rigidbody2D.angularVelocity = 0;
				}
		if (fireCooldown < fireSpeed) {
			fireCooldown += Time.deltaTime;		
		}

		playerGui.UpdateBars(currentHealth, boost);
	}

	void Damage(DamageSource source) {
		//player takes damage
		currentHealth -= source.damageAmount;
		position = new Vector2 (gameObject.transform.position.x, gameObject.transform.position.y);
		if (currentHealth <= 0) {
			playerGui.UpdateBars(currentHealth, boost);

			Instantiate (playerExplosion,position,transform.rotation);
			gameHandler.deadPlayers += 1;
			Destroy (gameObject);
		}
		else 
			Instantiate (playerHurt,position,transform.rotation);
		}
	
	void FixedUpdate()
	{
		rigidbody2D.velocity = movement;


	}
}