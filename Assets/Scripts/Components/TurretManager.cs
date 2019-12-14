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
		units = GameObject.FindGameObjectsWithTag("Unit");
	}
	private int target = -1;
	private float charge = 0;
	void Update()
	{
		if(target == -1||(transform.position-units[target].transform.position).magnitude>radius){
			target = - 1;
			for(int i = 0; i < units.Length; i++){
				if((transform.position-units[i].transform.position).magnitude<radius){
					target = i;
					break;
				}
			}
		}
		if(target!=-1){
			var direction = units[target].transform.position-transform.position;
			direction.y = 0;
			transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime*turnSpeed);
			
			charge += Time.deltaTime;
			if(charge > 1/fireRate){
				charge = 0;
				var bulletInstance = Instantiate(bullet, firePoint.position, firePoint.rotation);
				bulletInstance.GetComponent<Rigidbody>().velocity = bulletSpeed*bulletInstance.transform.forward;
			}
		}
	}
}
