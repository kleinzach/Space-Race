using UnityEngine;
using System.Collections;

public class MeshModifier : MonoBehaviour {

	Mesh mesh;
	protected Vector3[] vertices;
	protected Vector3[] normals;
	protected float[] distances;
	
	// Use this for initialization
	void Awake () {
		mesh = GetComponent<MeshFilter>().mesh;
		vertices = mesh.vertices;
		normals = mesh.normals;
	}

	void Start() {
		Debug.Log ("Start");
		for(int i = 0; i< 50; i++){
			
			heighten(vertices[Random.Range(0,vertices.Length)],Random.Range(.125f,1f),Random.Range(-.25f,.25f));
		}
	}

	public void heighten (Vector3 v,float size, float amount){
		for(int i = 0; i < vertices.Length; i++){
			float dist = Vector3.Distance(vertices[i],v);
			dist = (dist == 0)?dist = float.Epsilon:dist;
			if(dist < size){
				vertices[i] += normals[i] * amount * (size-dist);
			}
			mesh.vertices = vertices;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
