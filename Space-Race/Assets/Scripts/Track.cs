using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Track : MonoBehaviour {

	public Waypoint genericWaypoint;

	public List<Waypoint> route;

	// Use this for initialization
	void Start () {
		if (route.Count > 0)
		{
			route[0].active = true;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (route.Count <= 0)
		{
			endRace();
			return;
		}
		if (!route[0].gameObject.activeSelf)
		{
			route.RemoveAt(0);
			if (route.Count > 0)
			{
				route[0].active = true;
			}
		}
		
	}

	public void addWaypoint(){
		GameObject go = (GameObject.Instantiate(genericWaypoint.gameObject) as GameObject);
		route.Add(go.GetComponent<Waypoint>());
	}

	public void endRace()
	{

	}
}
