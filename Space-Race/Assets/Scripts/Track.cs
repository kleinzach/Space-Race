using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Track : MonoBehaviour {

	public Waypoint genericWaypoint;

	public List<Waypoint> route;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void addWaypoint(){
		GameObject go = (GameObject.Instantiate(genericWaypoint.gameObject) as GameObject);
		route.Add(go.GetComponent<Waypoint>());
	}
}
