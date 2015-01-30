using UnityEngine;
using System.Collections;

public class BossMovement : MonoBehaviour {
	private Vector3 origin;

	public float horizontalAmplitude = 1;
	public float horizontalSpeed = 1;

	public float verticalAmplitude = 1;
	public float verticalSpeed = 1;
	
	public float movementSpeed;
	public float phase;
	public bool lookInDirection;

	private float lifetime;

	// Use this for initialization
	void Start () {
		ResetOrigin();
	}


	public void ResetOrigin() {
		origin = transform.localPosition;
	}

	public void ResetOrigin(Vector3 pos) {
		origin = pos;
	}

	// Update is called once per frame
	void Update () {
		lifetime += Time.deltaTime;

		Vector3 p = new Vector3(horizontalAmplitude * Mathf.Sin((Time.time + phase + lifetime) * horizontalSpeed * movementSpeed), 
		                        verticalAmplitude * Mathf.Sin((Time.time + phase + lifetime) * verticalSpeed* movementSpeed),
		                        0);

		if(lookInDirection) {
			Quaternion rot = Quaternion.LookRotation(origin+p - transform.localPosition, transform.TransformDirection(Vector3.up));
			transform.rotation = new Quaternion(0,0,rot.z, rot.w);
		}

		transform.localPosition = origin + p;
	}

	void OnDrawGizmosSelected() {
		if(!Application.isPlaying && origin != transform.localPosition) {
			ResetOrigin();
		}

		Vector3 p = Vector3.zero;
		Vector3 v = Vector3.zero;

		for(int i = 0; i < (50); i ++) {
			p = new Vector3(horizontalAmplitude * Mathf.Sin(((i-1) * 0.1f + phase) * horizontalSpeed * movementSpeed), 
			                verticalAmplitude * Mathf.Sin(((i-1) * 0.1f + phase) * verticalSpeed * movementSpeed),
			                0);

			v = new Vector3(horizontalAmplitude * Mathf.Sin((i * 0.1f + phase) * horizontalSpeed * movementSpeed), 
			                verticalAmplitude * Mathf.Sin((i * 0.1f + phase) * verticalSpeed * movementSpeed),
			                0);

			Gizmos.DrawLine(origin + p, origin + v);
			Gizmos.DrawWireSphere(origin + v, 0.1f);
		}
	}
}
