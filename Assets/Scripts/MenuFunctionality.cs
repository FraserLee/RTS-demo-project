using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuFunctionality : MonoBehaviour
{
	public static string playerName = "";
	public TMP_InputField input;
	public void StartButton(){
		SceneManager.LoadScene(1);//swap to the main scene
	}
	public void ExitButton(){
		#if UNITY_EDITOR // platform dependent compilation, so we can get some functionality out of that exit button without needing to do a build.
		UnityEditor.EditorApplication.isPlaying = false;
		#else
		Application.Quit();// I've not actually built and tested that this works, just going off the manual for this one. 
		#endif
	}
	public void TextChanged(){
		playerName = input.text;
	}
}
