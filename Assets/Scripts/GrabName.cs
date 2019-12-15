using UnityEngine;
using TMPro;

public class GrabName : MonoBehaviour
{
	void Start()
	{
		GetComponent<TextMeshProUGUI>().text = MenuFunctionality.playerName; 
	}	//Grab the playerName string from MenuFunctionality and toss it into the text field of this gameObject.
}
