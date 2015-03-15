using UnityEngine;
using System.Collections;
using System.Xml;

public class Station : MonoBehaviour {

	float laditude;
	float longitude;

	static float lad_offset = 37;
	static float lad_scale = 60;

	static float long_offset = -122;
	static float long_scale = 50;

	public string name;
	public string abbr;

	private Vector3 offset;

	public void Initialize(XmlElement element)
	{
		laditude = Util.getXMLFloat("gtfs_latitude",element);
		longitude = Util.getXMLFloat("gtfs_longitude",element);

		float x = (longitude - long_offset) * long_scale;
		float z = (laditude - lad_offset) * lad_scale;

		this.transform.position = new Vector3(x, 0, z);

		name = Util.getXMLString("name", element);
		abbr = Util.getXMLString("abbr", element);
		this.gameObject.name = name;

		offset = new Vector3();

	}

	public Vector3 getPosition()
	{
		Vector3 pos = this.transform.position + offset;
		offset += new Vector3(.05f, 0, .05f);
		Debug.Log(offset);
		return pos;
	}
}
