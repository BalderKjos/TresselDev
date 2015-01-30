using UnityEngine;
using System.Collections;

public class audioPitch : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
		if (GetComponent<AudioSource>()!=null){
			GetComponent<AudioSource>().pitch = Random.Range (0.9f,1.1f);
		}
	}
	
	// Update is called once per frame
	void Update () {
	


	}
}
