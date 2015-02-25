using UnityEngine;
using System.Collections;

[RequireComponent (typeof(MeshFilter))]
public class Planet : MeshModifier {

	void Start() {
		for(int i = 0; i < vertices.Length; i++){
			heighten(vertices[i],1,Random.Range(-1,1));
		}
	}

	// Update is called once per frame
	void Update () {

	}
}
