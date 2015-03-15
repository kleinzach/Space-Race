using UnityEngine;
using System.Collections;

public class CameraFollower : MonoBehaviour {

	public Transform target;
	public float followAmount = 1;
	public float rotateAmount = 1;
	
	// Update is called once per frame
	void Update () {
		this.transform.position = Vector3.MoveTowards(transform.position, target.position, followAmount*Time.deltaTime);
		this.transform.rotation = Quaternion.RotateTowards(transform.rotation, target.rotation, rotateAmount * Time.deltaTime);
	}
}
