using UnityEngine;
using System.Collections;

public class CameraShaker : MonoBehaviour {
	public static CameraShaker instance;

	private float timeRemaining;
	private float amount;
	private Vector3 origin;

	// Use this for initialization
	void Start () {
		instance = this;
		origin = transform.position;
	}

	public static void Shake(float strength, float duration) {
		instance.DoShake (strength * 2.0f, duration);
		}

	private void DoShake(float strength, float duration) {
		if (duration > timeRemaining)
			timeRemaining = duration;

		if(strength > amount)
			amount = strength;
	}

	// Update is called once per frame
	void Update () {
		if (Debugger.isOn) {
						if (Input.GetKeyDown (KeyCode.S) && Input.GetKey (KeyCode.Space))
								Shake (1, 1);
				}

		if (timeRemaining > 0) {
			float f = amount * Mathf.Sin(Time.time * Mathf.PI * (amount * 50));
			transform.position = origin + new Vector3(f,f);
			timeRemaining -= Time.deltaTime;
		} else {
			transform.position = origin;
			amount = 0;
		}
	}
}
