using UnityEngine;
using System.Collections;

public class PowerupTurret : PowerupChild {
	public float fireSpeed;
	public GameObject bullet;
	public bool constant;
	private float fireCooldown = 0;

	// Update is called once per frame
	public override void OnUpdate () {
		if(!GlobalGameManager.bossAnim) {
			if (fireCooldown >= fireSpeed){
				if(constant) {
					Instantiate (bullet,transform.position,transform.rotation);
					fireCooldown = 0;
				} else {
					float inputX2 = InputManager.GetRightX(GlobalGameManager.GetPlayerGamepad(player.player));
					float inputY2 = InputManager.GetRightY(GlobalGameManager.GetPlayerGamepad(player.player));
				
					if (inputX2 > 0.5f || inputX2 < -0.5f || inputY2 > 0.5f || inputY2 < -0.5f) {
						Instantiate (bullet,transform.position,transform.rotation);
						fireCooldown = 0;
					}
				}
			} else {
				fireCooldown += Time.deltaTime;		
			}
		}
	}
}
