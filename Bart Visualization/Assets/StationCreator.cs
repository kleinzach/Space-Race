using UnityEngine;
using System.Collections;
using System.Xml;

public class StationCreator : MonoBehaviour {

	string URI_prefix = "http://api.bart.gov/api/stn.aspx?";

	string command = "cmd=stns";

	public Station station;

	void Awake () {
		string uri = URI_prefix + command + "&" + "key=" + Util.key;
		XmlDocument doc_stations = new XmlDocument();
		doc_stations.Load(uri);
		//Debug.Log(doc_stations.InnerXml);
		foreach(XmlElement sta in doc_stations.GetElementsByTagName("station")){
			Station s = (Instantiate(station.gameObject, Vector3.zero, Quaternion.identity) as GameObject).GetComponent<Station>();
			s.Initialize(sta);
			s.transform.parent = this.transform;
		}
	}
}
