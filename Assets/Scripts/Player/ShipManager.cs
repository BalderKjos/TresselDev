using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShipManager : MonoBehaviour {
	public static ShipManager instance;

	public GameObject[] ships;

	public Color P1Color;
	public Color P2Color;
	public Color P3Color;
	public Color P4Color;

	// Use this for initialization
	void Start () {
		if(instance == null)
			instance = this;
		else
			Destroy(gameObject);

		DontDestroyOnLoad(gameObject);
	}

	public Color GetColor(int player) {
		if(player == 1)
			return P1Color;
		if(player == 2)
			return P2Color;
		if(player == 3)
			return P3Color;
		if(player == 4)
			return P4Color;
		return Color.white;
	}
}