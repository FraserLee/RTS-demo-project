using UnityEngine;

public class Highlighter : MonoBehaviour
{
	public GameObject highlightGameObject;

	private bool highlighted = false; //I don't want to make this public, as that could lead to highlighted becoming decoupled from the actual state of the highlight object
	// and we don't need 2-way encapsulation, as it shouldn't really ever be set from outside this class.
	public bool IsHighlighted(){
		return highlighted;
	}
	void Start(){
		highlightGameObject.SetActive(highlighted);
	}

	void OnMouseDown(){ //when clicked on, toggle the highlighted bool and activate or deactivate the highlight object appropriately
     	highlightGameObject.SetActive(highlighted=!highlighted);
  	}   
}
