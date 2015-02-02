using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class Ship : MonoBehaviour {

	public float speed;
	public float turnSpeed;

	Vector3 velocity;
	Quaternion angularVelocity;

	float horizontal;
	float vertical;
	float spin;
	float gas;

	// Use this for initialization
	void Start () {
		velocity = new Vector3();
		angularVelocity = new Quaternion();
	}
	
	// Update is called once per frame
	void Update () {
		horizontal = Input.GetAxis("Horizontal");
		vertical = Input.GetAxis("Vertical");
		spin = Input.GetAxis("Spin");
		gas = Input.GetAxis("Gas");

		angularVelocity = new Quaternion();
	}

	void FixedUpdate(){
		velocity += gas * Time.fixedDeltaTime * transform.forward * speed;
		rigidbody.velocity = velocity;

		float h = horizontal * turnSpeed * Time.fixedDeltaTime;
		float v = vertical * turnSpeed * Time.fixedDeltaTime;
		float s = spin * turnSpeed * Time.fixedDeltaTime;
		transform.Rotate(v,h,s,Space.Self);
	}
}
