using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuFunctionality : MonoBehaviour
{
	public static string name = "";
	public TMP_InputField input;
	public void StartButton(){
		SceneManager.LoadScene(1);
	}
	public void ExitButton(){
		#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
		#else
		Application.Quit();
		#endif
	}
	public void TextChanged(){
		name = input.text;
	}
}
