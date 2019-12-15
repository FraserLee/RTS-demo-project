using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletManager : MonoBehaviour
{
	public float range = 25;
	private Vector3 src;

	void Start(){
		src = transform.position;
	}
	void Update()
	{
		if((transform.position-src).magnitude>range)GameObject.Destroy(gameObject);
	}
}
