using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[ExecuteInEditMode]
public class ParticleRenderLayer : MonoBehaviour {
	public string layer;
	public int order;

	void Start ()
	{
		//Change Foreground to the layer you want it to display on 
		//You could prob. make a public variable for this
		particleSystem.renderer.sortingLayerName = layer;
		particleSystem.renderer.sortingOrder = order;
	}

	void OnEnable() {
		Start();
	}
}
