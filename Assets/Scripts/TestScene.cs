using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TestScene : MonoBehaviour {
	public GameObject panelObject;
	public GameObject buttonPrefab;
	public TestSceneSpawnObject[] powerups;
	public TestSceneSpawnObject[] bosses;
	private Transform buttonContainer;
	private int menu = 0;

	void Start() {
		panelObject.SetActive(false);
		buttonPrefab.SetActive(false);
		buttonContainer = buttonPrefab.transform.parent;
		menu = 0;
	}

	// Update is called once per frame
	void Update () {
		if(Debugger.isOn && Input.GetKey(KeyCode.Space) && Input.GetKeyDown(KeyCode.D)) {
			panelObject.SetActive(!panelObject.activeSelf);

			if(panelObject.activeSelf) {
				menu = 0;
				RemoveChildren();
				ShowMainMenu();
			}
		}

		if(panelObject.activeSelf) {
			if(Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1)) {
				OnButtonPress(1);
			}
			if(Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2)) {
				OnButtonPress(2);
			}
			if(Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3)) {
				OnButtonPress(3);
			}
			if(Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Keypad4)) {
				OnButtonPress(4);
			}
			if(Input.GetKeyDown(KeyCode.Alpha5) || Input.GetKeyDown(KeyCode.Keypad5)) {
				OnButtonPress(5);
			}
			if(Input.GetKeyDown(KeyCode.Alpha6) || Input.GetKeyDown(KeyCode.Keypad6)) {
				OnButtonPress(6);
			}
			if(Input.GetKeyDown(KeyCode.Alpha7) || Input.GetKeyDown(KeyCode.Keypad7)) {
				OnButtonPress(7);
			}
			if(Input.GetKeyDown(KeyCode.Alpha8) || Input.GetKeyDown(KeyCode.Keypad8)) {
				OnButtonPress(8);
			}
			if(Input.GetKeyDown(KeyCode.Alpha9) || Input.GetKeyDown(KeyCode.Keypad9)) {
				OnButtonPress(9);
			}
		}
	}

	public void OnButtonPress(int buttonNumber) {
		if(menu == 0) {
			if(buttonNumber == 1) {
				RemoveChildren();
				menu = 1;
				ShowToolMenu();
			}
			if(buttonNumber == 2) {
				RemoveChildren();
				menu = 2;
				ShowPowerMenu();
			}
			if(buttonNumber == 3) {
				RemoveChildren();
				menu = 3;
				ShowBossMenu();
			}
		} else if(menu == 1) { //Tools
			if(buttonNumber == 1) {
				foreach(character c in Component.FindObjectsOfType<character>()) {
					c.currentHealth = c.maxHealth;
				}
			}
			if(buttonNumber == 2) {
				foreach(EnemyScript e in Component.FindObjectsOfType<EnemyScript>()) {
					e.currentHealth = (int)(e.currentHealth * 0.5f);
					if(e.healthBar != null)
						e.healthBar.value = e.currentHealth;
				}
			}
			if(buttonNumber == 3) {

			}
			panelObject.SetActive(false);
		} else if(menu == 2) { //Powerups
			Instantiate(powerups[buttonNumber-1].prefab, Vector3.zero, Quaternion.identity);
			panelObject.SetActive(false);
		} else if(menu == 3) { //Bosses
			GameObject g = (GameObject)Instantiate(bosses[buttonNumber-1].prefab, Vector3.zero, Quaternion.identity);
			GameObject b = GuiManager.instance.NewBossHealthBar();

			if(g.GetComponent<EnemyScript>() != null)
				g.GetComponent<EnemyScript>().SetHPBar(b.GetComponent<Slider>());
			else
				g.GetComponentInChildren<EnemyScript>().SetHPBar(b.GetComponent<Slider>());

			panelObject.SetActive(false);
		}
	}

	void RemoveChildren() {
		for(int i = 0; i < buttonContainer.childCount; i++) {
			if(buttonContainer.GetChild(i).gameObject.activeSelf)
				Destroy(buttonContainer.GetChild(i).gameObject);
		}
	}

	void ShowMainMenu() {
		GameObject b1 = (GameObject)Instantiate(buttonPrefab);
		b1.transform.SetParent(buttonPrefab.transform.parent);
		b1.SetActive(true);
		b1.GetComponent<CodeButton>().text.text = "1 Tools";
		b1.GetComponent<CodeButton>().returnMethod = OnButtonPress;
		b1.GetComponent<CodeButton>().returnArgument = 1;

		GameObject b2 = (GameObject)Instantiate(buttonPrefab);
		b2.transform.SetParent(buttonPrefab.transform.parent);
		b2.SetActive(true);
		b2.GetComponent<CodeButton>().text.text = "2 Powerups";
		b2.GetComponent<CodeButton>().returnMethod = OnButtonPress;
		b2.GetComponent<CodeButton>().returnArgument = 2;

		GameObject b3 = (GameObject)Instantiate(buttonPrefab);
		b3.transform.SetParent(buttonPrefab.transform.parent);
		b3.SetActive(true);
		b3.GetComponent<CodeButton>().text.text = "3 Bosses";
		b3.GetComponent<CodeButton>().returnMethod = OnButtonPress;
		b3.GetComponent<CodeButton>().returnArgument = 3;
	}

	void ShowToolMenu() {
		GameObject b1 = (GameObject)Instantiate(buttonPrefab);
		b1.transform.SetParent(buttonPrefab.transform.parent);
		b1.SetActive(true);
		b1.GetComponent<CodeButton>().text.text = "1 Heal";
		b1.GetComponent<CodeButton>().returnMethod = OnButtonPress;
		b1.GetComponent<CodeButton>().returnArgument = 1;

		GameObject b2 = (GameObject)Instantiate(buttonPrefab);
		b2.transform.SetParent(buttonPrefab.transform.parent);
		b2.SetActive(true);
		b2.GetComponent<CodeButton>().text.text = "2 Damage Boss";
		b2.GetComponent<CodeButton>().returnMethod = OnButtonPress;
		b2.GetComponent<CodeButton>().returnArgument = 2;
		
		/*
		GameObject b3 = (GameObject)Instantiate(buttonPrefab);
		b3.transform.SetParent(buttonPrefab.transform.parent);
		b3.SetActive(true);
		b3.GetComponent<CodeButton>().text.text = "Bosses";
		b3.GetComponent<CodeButton>().returnMethod = OnButtonPress;
		b3.GetComponent<CodeButton>().returnArgument = 3;
		*/
	}
	void ShowPowerMenu() {
		for(int i = 0; i < powerups.Length; i++) {
			GameObject b1 = (GameObject)Instantiate(buttonPrefab);
			b1.transform.SetParent(buttonPrefab.transform.parent);
			b1.SetActive(true);
			b1.GetComponent<CodeButton>().text.text = (i+1) + " " + powerups[i].prefab.name;
			b1.GetComponent<CodeButton>().returnMethod = OnButtonPress;
			b1.GetComponent<CodeButton>().returnArgument = i;
		}
	}
	
	void ShowBossMenu() {
		for(int i = 0; i < bosses.Length; i++) {
			GameObject b1 = (GameObject)Instantiate(buttonPrefab);
			b1.transform.SetParent(buttonPrefab.transform.parent);
			b1.SetActive(true);
			b1.GetComponent<CodeButton>().text.text = (i+1) + " " + bosses[i].prefab.name;
			b1.GetComponent<CodeButton>().returnMethod = OnButtonPress;
			b1.GetComponent<CodeButton>().returnArgument = i;
		}
	}
}

[System.Serializable]
public class TestSceneSpawnObject {
	public GameObject prefab;
}
