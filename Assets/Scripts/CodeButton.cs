using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CodeButton : MonoBehaviour {
	public Button button;
	public Text text;
	
	public delegate void OnPressMethod(int arg);
	public OnPressMethod returnMethod;
	public int returnArgument;

	// Use this for initialization
	void Awake () {
		if(button == null)
			button = GetComponent<Button>();
		if(text == null)
			text = GetComponentInChildren<Text>();
	}
	
	public void OnPress () {
		if(returnMethod != null) {
			returnMethod(returnArgument);
		}
	}
}
