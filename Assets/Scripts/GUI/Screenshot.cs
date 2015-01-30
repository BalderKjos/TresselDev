using UnityEngine;
using System.Collections;

public class Screenshot : MonoBehaviour {
	public KeyCode key = KeyCode.F12;
	public string filename;
	public int sizeMultiplier = 1;
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyUp(key)) {
			int suffix = 0;
			string screenname = filename + "_" + suffix + ".png";
			string path = Application.dataPath.Replace("Assets", "");

			if(!System.IO.Directory.Exists(path + "screenshots/"))
				System.IO.Directory.CreateDirectory(path + "screenshots/");

			print("Checking: " + path + "screenshots/" + screenname);
			while(System.IO.File.Exists(path + "screenshots/" + screenname)) {
				suffix++;
				screenname = filename + "_" + suffix + ".png";
				
				print("Checking: " + path + "screenshots/" + screenname);
			}
			
			Application.CaptureScreenshot("screenshots/" + screenname, sizeMultiplier);
			//System.IO.File.Move(path + screenname, path + "screenshots/" + screenname);
			
			print("Screenshot taken: " + path + "screenshots/" + screenname);
		}
	}
}
