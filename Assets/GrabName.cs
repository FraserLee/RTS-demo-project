using UnityEngine;
using TMPro;

public class GrabName : MonoBehaviour
{
	void Start()
	{
		GetComponent<TextMeshProUGUI>().text = MenuFunctionality.name;
	}
}
