using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretManager : MonoBehaviour
{
	private GameObject[] units;
	public float turnSpeed = 3f;
	void Start()
	{
		units = GameObject.FindGameObjectsWithTag("Unit");
	}

	void Update()
	{
		var direction = units[0].transform.position-transform.position;
 		direction.y = 0;
 		transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime*turnSpeed);
	}
}
