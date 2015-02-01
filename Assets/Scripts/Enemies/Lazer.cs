using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Lazer : MonoBehaviour {
	public SpriteRenderer spiteRenderer;
	public Sprite Warning1;
	public Sprite Warning2;
	public Sprite lazer;

	public float warningDuration;
	public float damageDuration;
	public Color lazerColor;

	private bool damaging;
	private float duration;

	void Start() {
		duration = warningDuration + damageDuration;
		spiteRenderer.color = lazerColor;
	}
	
	// Update is called once per frame
	void Update () {
		duration -= Time.deltaTime;

		if(duration > damageDuration) { //Warning
			spiteRenderer.sprite = spiteRenderer.sprite == null ? Warning1 : spiteRenderer.sprite == Warning1 ? Warning2 : null;
		} else if(duration > 0) { //Damage
			if(damaging) {
				spiteRenderer.color = spiteRenderer.color == lazerColor ? Color.white : lazerColor;
			} else {
				damaging = true;
				spiteRenderer.collider2D.enabled = true;			
				spiteRenderer.sprite = lazer;
			}
		} else {
			Destroy(gameObject);
		}
	}
}
