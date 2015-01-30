using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerGui : MonoBehaviour {
	public Slider healthBar;
	public Image healthBarImage;

	public Slider energyBar;

	public Slider powerupBar;

	void Start() {
		powerupBar.gameObject.SetActive(false);
	}

	public void SetupBars (float hp, float energy, Color healthColor) {
		healthBar.maxValue = hp;
		energyBar.maxValue = energy;
		healthBarImage.color = healthColor;
	}

	public Slider ActivatePowerup(Powerup p) {
		Slider pb = ((GameObject)Instantiate(powerupBar.gameObject)).GetComponent<Slider>();
		pb.transform.SetParent(powerupBar.transform.parent);

		pb.maxValue = p.duration;
		pb.value = p.duration;

		pb.gameObject.SetActive(true);
		return pb;
	}

	public void UpdateBars (float hp, float energy) {
		healthBar.value = hp;
		energyBar.value = energy;
	}
}
