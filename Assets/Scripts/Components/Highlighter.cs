using UnityEngine;

public class Highlighter : MonoBehaviour
{
	public GameObject highlightGameObject;

	private bool highlighted = false;
	
	public bool IsHighlighted(){
		return highlighted;
	}
	void Start(){
		highlightGameObject.SetActive(highlighted);
	}

	void OnMouseDown(){
     	highlightGameObject.SetActive(highlighted=!highlighted);
  	}   
}
