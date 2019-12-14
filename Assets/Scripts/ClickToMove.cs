using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ClickToMove : MonoBehaviour {
	//component
	NavMeshAgent navMeshAgent;
	Highlighter highlighter;
	void Start() {
		navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
		highlighter = GetComponent<Highlighter>();

		instances.Add(this);
	}
	//system
	private static List<ClickToMove> instances = new List<ClickToMove>();
	private static Camera camera;
	public static void StaticStart(){
		camera = Camera.main;
	}
	private static RaycastHit hit;

	public static void StaticUpdate(){
		if (Input.GetMouseButtonDown(0)
			&& Physics.Raycast(camera.ScreenPointToRay(Input.mousePosition), out hit) 
			&& hit.collider.tag == "Terrain"){

			foreach (ClickToMove ctm in instances)
				if (ctm.highlighter.IsHighlighted())ctm.navMeshAgent.SetDestination(hit.point);
		}
	}
}

