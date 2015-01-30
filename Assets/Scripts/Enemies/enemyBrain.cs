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

	void Damage() {
		//player takes damage
		mainBody.SendMessage("Damage", SendMessageOptions.DontRequireReceiver);
		if (multiplier == true)
		mainBody.SendMessage("Damage", SendMessageOptions.DontRequireReceiver);
	}
}
