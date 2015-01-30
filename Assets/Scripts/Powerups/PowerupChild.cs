using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PowerupChild : MonoBehaviour {
	protected character player;
	protected float duration;
	protected Slider display;

	public void Init(character p, Slider d, float t) {
		player = p;
		display = d;
		duration = t;
		OnStartup();
	}

	public virtual void OnStartup() {

	}

	void Update() {
		if(display != null && !GlobalGameManager.bossAnim) {
			display.value = duration;
			duration -= Time.deltaTime;
			
			if(duration <= 0) {
				Destroy(display.gameObject);

				Destroy(gameObject);
			}
		}

		OnUpdate();
	}

	public virtual void OnUpdate() {
	}
}
