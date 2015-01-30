using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GuiManager : MonoBehaviour {
	public HorizontalLayoutGroup bars;
	public GameObject skull;
	public GameObject goldenSkull;
	public GameObject newSkullEffect;

	private bool newSkull;
	private float endTimer;

	// Use this for initialization
	void Start () {
		int tw = (int)Camera.main.pixelWidth;
		float bw = Camera.main.pixelWidth * 0.25f;

		tw -= (int)(bw * GlobalGameManager.NumberOfPlayers());
		tw = (int)(tw * 0.5f);
		bars.padding = new RectOffset(tw, tw, bars.padding.top, bars.padding.bottom);

		skull.SetActive(false);
		goldenSkull.SetActive(false);

		if((GlobalGameManager.stage-1) > 0) {
			int sw = (int)skull.transform.parent.GetComponent<RectTransform>().rect.height;
			int cw = (int)skull.transform.parent.GetComponent<RectTransform>().rect.width;

			cw -= (int)(sw * (GlobalGameManager.stage));
			cw = (int)(cw * 0.5f);
			skull.transform.parent.GetComponent<HorizontalLayoutGroup>().padding = new RectOffset(cw, cw, 0, 0);

			for(int i = 0; i < (GlobalGameManager.stage-1); i++) {
				GameObject g = (GameObject)Instantiate((i+1)%5==0?goldenSkull:skull);
				g.transform.SetParent(skull.transform.parent);
				g.SetActive(true);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(!newSkull && gameHandler.instance.bossNumbers <= 0) {
			if(endTimer >= 2) {
				newSkull = true;

				GameObject g = (GameObject)Instantiate((GlobalGameManager.stage)%5==0?goldenSkull:skull);
				g.transform.SetParent(skull.transform.parent);
				g.SetActive(true);

				GameObject p = (GameObject)Instantiate(newSkullEffect);
				p.transform.parent = g.transform;
				p.transform.localPosition = Vector3.zero;
			} else {
				endTimer += Time.deltaTime;
			}
		}
	}
}
