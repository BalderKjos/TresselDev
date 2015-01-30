using UnityEngine;
using System.Collections;

public class ShipVisuals : MonoBehaviour {
	public SpriteRenderer coloredSprite;
	
	// Update is called once per frame
	public void UpdateVisuals (Color c) {
		coloredSprite.color = c;
	}
}
