using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;

public class RouteCreater : MonoBehaviour {

	string URI_prefix = "http://api.bart.gov/api/route.aspx?";

	string routesCommand = "cmd=routes";
	string command = "cmd=routeinfo";

	public List<Route> routes;

	public class Route
	{
		public List<Vector3> path = new List<Vector3>();
		public Color color = new Color();

	}

	// Use this for initialization
	void Start () {
		string routeuri = URI_prefix + routesCommand + "&key=" + Util.key;
		XmlDocument doc_routes = new XmlDocument();
		doc_routes.Load(routeuri);
		XmlNodeList routeList = doc_routes.GetElementsByTagName("route");

		routes = new List<Route>();

		List<int> currentRoutes = new List<int>();

		int index = 0;

		foreach(XmlElement r in routeList){
			
			int number = (int)Util.getXMLInt("number", r);

			if (currentRoutes.Contains(Util.partner(number)))
			{
				continue;
			}
			else
			{
				currentRoutes.Add(number);
			}

			string uri = URI_prefix + command + "&" + "route=" + number + "&key=" + Util.key;
			XmlDocument doc_stations = new XmlDocument();

			doc_stations.Load(uri);


			XmlNodeList list = doc_stations.GetElementsByTagName("station");
			routes.Add(new Route());

			string str = Util.getXMLString("color", r).Substring(1);
			routes[index].color = Util.HexToColor(str);

			for (int i = 0; i < list.Count; i++)
			{
				Station s = Util.getStation(list.Item(i).InnerText);
				routes[index].path.Add(s.getPosition());
			}
			index++;
			
		}
	
	}
	public static Material lineMaterial;
	static void CreateLineMaterial()
	{
		if (!lineMaterial)
		{
			lineMaterial = new Material("Shader \"Lines/Colored Blended\" {" + "SubShader { Pass { " + "    Blend SrcAlpha OneMinusSrcAlpha " + "    ZWrite Off Cull Off Fog { Mode Off } " + "    BindChannels {" + "      Bind \"vertex\", vertex Bind \"color\", color }" + "} } }");
			lineMaterial.hideFlags = HideFlags.HideAndDontSave;
			lineMaterial.shader.hideFlags = HideFlags.HideAndDontSave;
		}
	}
	void OnPostRender()
	{
		CreateLineMaterial();
		lineMaterial.SetPass(0);

		//Draw each path
		foreach (Route r in routes)
		{
			GL.Begin(GL.LINES);
			GL.Color(r.color);
			GL.Vertex(r.path[0]);
			foreach (Vector3 v in r.path)
			{
				GL.Vertex(v);
				GL.Vertex(v);
			}
			GL.End();
		}
	}
}
