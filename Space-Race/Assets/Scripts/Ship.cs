using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
public class Ship : MonoBehaviour {

	public float speed;
	public float turnSpeed;

	public Transform velocityArrow;
	public Transform waypointArrow;
	public RectTransform powerMeter;

	Vector3 force;
	Quaternion angularVelocity;

	float horizontal;
	float vertical;
	float spin;
	float gas;

	public float maxEnergy;
	float energyRemaining;

	public Transform model;
	private Vector3 baseRotation;

	public ParticleSystem particles;

	public Text speedText;

	private Track course;

	// Use this for initialization
	void Start () {
		force = new Vector3();
		angularVelocity = new Quaternion();
		//baseRotation = model.transform.localRotation.eulerAngles;
		course = GameObject.FindObjectOfType<Track>();
		energyRemaining = maxEnergy;
	}
	
	// Update is called once per frame
	void Update () {
		horizontal = Input.GetAxis("Horizontal");
		vertical = Input.GetAxis("Vertical");
		spin = Input.GetAxis("Spin");
		if (energyRemaining <= 0)
		{
			energyRemaining = 0;
			gas = 0;
		}
		else
		{
			gas = Input.GetAxis("Gas");
			energyRemaining -= gas * Time.deltaTime;
		}
		powerMeter.sizeDelta = new Vector2(energyRemaining/maxEnergy * 10f, powerMeter.rect.height);
	}

	void FixedUpdate(){
		force = gas * Time.fixedDeltaTime * transform.forward * speed;
		particles.Emit ((int)(gas*5));
		GetComponent<Rigidbody>().AddForce(force);

		float h = horizontal * turnSpeed * Time.fixedDeltaTime;
		float v = vertical * turnSpeed * Time.fixedDeltaTime / 2;
		float s = spin * turnSpeed * Time.fixedDeltaTime;
		GetComponent<Rigidbody>().AddRelativeTorque(v,h,s);
		//model.localRotation = Quaternion.Euler(
			//baseRotation + new Vector3(vertical * 10, horizontal * 10,spin * 10));
		speedText.text = GetComponent<Rigidbody>().velocity.magnitude + "";
		velocityArrow.rotation = Quaternion.LookRotation(GetComponent<Rigidbody>().velocity);
		if (course.route.Count > 0)
		{
			waypointArrow.rotation = Quaternion.LookRotation(course.route[0].transform.position - this.transform.position);
		}
	}
}
