using UnityEngine;
using System.Collections;

public class BossAnimator : MonoBehaviour {
	public BossAnimatorClip[] clips;
	private EnemyScript enemy;
	private Animator anim;

	public void AnimComplete() {
		GlobalGameManager.bossAnim = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(clips.Length == 0)
			return;

		if(enemy == null)
			enemy = GetComponent<EnemyScript>();
		if(anim == null)
			anim = GetComponent<Animator>();

		foreach(BossAnimatorClip bac in clips) {
			if(!bac.ignore) {
				if(bac.type == BossAnimatorClip.clipTypes.HealthBellow) {
					if(enemy.currentHealth < bac.healthBellow) {
						bac.ignore = true;
						anim.Play(bac.animationName);
					}
				} else if(bac.type == BossAnimatorClip.clipTypes.PartsMissing) {
					bool allPartsMissing = true;

					foreach(GameObject g in bac.partsMissing) {
						if(g != null) {
							allPartsMissing = false;
							break;
						}
					}

					if(allPartsMissing) {
						bac.ignore = true;
						anim.Play(bac.animationName);
					}
				}
			}
		}
	}
}

[System.Serializable]
public class BossAnimatorClip {
	public string animationName;

	public enum clipTypes {HealthBellow, PartsMissing}
	public clipTypes type;

	public int healthBellow;
	public GameObject[] partsMissing;

	public bool ignore;
}