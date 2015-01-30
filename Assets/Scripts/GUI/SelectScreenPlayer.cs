using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SelectScreenPlayer : MonoBehaviour {
	public Image ReadyBG;
	public Image ShipColor;
	public GameObject shipDisplay;
	private Transform shipDisplayParent;

	private Color readyBgOriginal;

	// Use this for initialization
	void Start () {
		readyBgOriginal = ReadyBG.color;
		ShipColor.color = Color.grey;
		shipDisplayParent = shipDisplay.transform.parent;
		Destroy(shipDisplay);
	}
	
	// Update is called once per frame
	public void UpdateVisual (int playerId, bool joined, bool ready) {
		Destroy(shipDisplay);

		if(joined) {
			ReadyBG.color = ready?Color.green:readyBgOriginal;

			shipDisplay = (GameObject)Instantiate(ShipManager.instance.ships[GlobalGameManager.GetPlayerShip(playerId)]);
			shipDisplay.GetComponent<ShipVisuals>().UpdateVisuals(ShipManager.instance.GetColor(playerId));
			shipDisplay.transform.parent = shipDisplayParent;				
			shipDisplay.transform.localScale = Vector3.one;	
			shipDisplay.transform.localPosition = Vector3.zero;	

			ShipColor.color = ShipManager.instance.GetColor(playerId);
		} else {
			ShipColor.color = Color.grey;
			ReadyBG.color = readyBgOriginal;
		}

	}
}