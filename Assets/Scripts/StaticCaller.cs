using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticCaller : MonoBehaviour
{// Any static methods can be called from here, with the knoladge that they'll only be called once
	private bool hasStarted = false;
	void Start()
	{
		if(!hasStarted){
			hasStarted = true;
			ClickToMove.StaticStart();
		}
	}
	private static bool hasUpdated = false;
	void Update()
	{
		if(!hasUpdated){
			hasUpdated = true;

			ClickToMove.StaticUpdate();
		}
	}
	void LateUpdate(){
		hasUpdated = false;
	}
}
