using UnityEngine;
using UnityEngine.AI;

public class ClickToMove : MonoBehaviour {

	private Camera camera;
	private UnityEngine.AI.NavMeshAgent navMeshAgent;

	void Start() {
		camera = Camera.main;
		navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
	}

	void Update () 
	{
		if (Input.GetMouseButtonDown(0))
		{
			Ray ray = camera.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;

			if (Physics.Raycast(ray, out hit))
			{
				navMeshAgent.SetDestination(hit.point);
			}
		}
	}
}