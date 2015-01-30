using UnityEngine;
using System.Collections;

public class enemyBrain : MonoBehaviour {
	
	public GameObject mainBody;
	public bool multiplier = true;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Damage(DamageSource source) {
		//player takes damage
		if (multiplier == true)
			source.damageAmount *= 2;

		mainBody.SendMessage("Damage", source, SendMessageOptions.DontRequireReceiver);
	}
}
