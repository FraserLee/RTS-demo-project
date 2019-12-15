using UnityEngine;
using UnityEngine.AI;

public class ClickToMove : MonoBehaviour {
	//instanced section
	NavMeshAgent navMeshAgent;
	Highlighter highlighter;
	void Start() {
		navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();//grab a few other components
		highlighter = GetComponent<Highlighter>();

		mcamera = Camera.main;//Wastefully writing to the same variable once per instance, but it'll still be plenty fast since it's only in start.
	}
	void Update() {
		if(getShouldMove() && highlighter.IsHighlighted())
			navMeshAgent.SetDestination(rayhit.point);
	}
	//static section
	private static Camera mcamera;

	private static bool getShouldMoveChecked = false, shouldMove = false;
	private static RaycastHit rayhit;

	private static bool getShouldMove(){ 	// This ends up being a decently expensive check, so I've moved it off to make sure it can only be called once per frame, regardless of how many units there are.
		if(!getShouldMoveChecked){			// This is exactly the use case that ECS is made for, but I thought using it might muddy up what's me and what's the paradigm.
			getShouldMoveChecked = true;

			shouldMove = Input.GetMouseButtonDown(0)
			&& Physics.Raycast(mcamera.ScreenPointToRay(Input.mousePosition), out rayhit) 
			&& rayhit.collider.tag == "Terrain"; 	// to avoid pathing when selecting other units, or anything else undesired.
		}										// since this only happens once per click, we can probably get away with a string comparison.
		return shouldMove;
	}

	void LateUpdate(){	getShouldMoveChecked = false;	} //reset the flag, so getShouldMove will be checked again next frame.
}

