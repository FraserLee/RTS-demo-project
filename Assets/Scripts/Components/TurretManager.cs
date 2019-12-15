using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretManager : MonoBehaviour
{
	public float turnSpeed = 40;
	public float radius = 12;
	public float bulletSpeed = 6;
	public float fireRate = 1;

	public GameObject bullet;
	public Transform firePoint;

	private GameObject[] units;

	void Start()
	{
		units = GameObject.FindGameObjectsWithTag("Unit"); //slow, but we're in start so it's fine.
	}
	private int target = -1; //the index in units[] of our current target. -1 indicates no target in range.
	private float charge = 0;
	void Update()
	{
		if(target == -1||(transform.position-units[target].transform.position).sqrMagnitude>radius*radius){ // if we don't have a target, or our current target's out of range
			target = - 1;// set target to -1
			for(int i = 0; i < units.Length; i++){//and search for a new one
				if((transform.position-units[i].transform.position).sqrMagnitude<radius*radius){
					target = i;
					break;
				}
			}
		}
		if(target!=-1){
			var direction = units[target].transform.position-transform.position;// the direction to look in
			direction.y = 0;// level off the y, so turrets can't bend down.
			transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime*turnSpeed);
			//turn towards units[target] at a rate of turnSpeed degrees per second
			charge += Time.deltaTime;
			if(charge > 1/fireRate){//firing a bullet
				charge = 0;
				var bulletInstance = Instantiate(bullet, firePoint.position, firePoint.rotation);// Instantiate a bullet object at the firing point
				bulletInstance.GetComponent<Rigidbody>().velocity = bulletSpeed*bulletInstance.transform.forward; //and give it some forward velocity
			}
		}
	}
}
