using UnityEngine;

public class Highlighter : MonoBehaviour
{
	public GameObject highlightGameObject;
	[HideInInspector]
	public bool highlighted = false;

	void Start(){
		highlightGameObject.SetActive(highlighted);
	}

	void OnMouseDown(){
     	highlightGameObject.SetActive(highlighted=!highlighted);
  	}   
}
