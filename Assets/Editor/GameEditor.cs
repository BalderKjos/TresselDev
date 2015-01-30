using UnityEngine;
using UnityEditor;
using System.Collections;

public class GameEditor : MonoBehaviour {

	[MenuItem("Tressel/PLAY GAME")]
	public static void PlayGame()
	{
		EditorApplication.SaveCurrentSceneIfUserWantsTo();
		EditorApplication.isPlaying = true;
		EditorApplication.OpenScene(EditorBuildSettings.scenes[0].path);
	}

}
