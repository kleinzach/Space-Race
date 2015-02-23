using UnityEngine;
using System.Collections;
using UnityEditor;
using UnityEditorInternal;

[CustomEditor(typeof(Track))]
public class TrackEditor : Editor {

	public override void OnInspectorGUI(){
		DrawDefaultInspector();

		Track myTrack = (Track)target;
		if(GUILayout.Button("New Waypoint")){
			myTrack.addWaypoint();
		}
	}
}
