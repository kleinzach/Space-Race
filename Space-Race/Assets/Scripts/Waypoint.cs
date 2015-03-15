using UnityEngine;
using System.Collections;

public class Waypoint : MonoBehaviour {

	public bool active = false;

	public bool complete = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider col)
	{
		Debug.Log("collision");
		if (active && col.gameObject.tag == "Player")
		{
			deactivate();
		}
	}

	void deactivate()
	{
		complete = true;
		active = false;
		this.gameObject.SetActive(false);
	}
}
