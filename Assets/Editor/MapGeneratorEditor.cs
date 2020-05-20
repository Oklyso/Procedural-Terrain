using UnityEngine;
using System.Collections;
using UnityEditor;

// I actually googled this, but this is to make sure my 
// terrain auto-updates whenever i use the sliders.
[CustomEditor (typeof (GenerateNoiseMap))]
public class MapGeneratorEditor : Editor {

	public override void OnInspectorGUI() {
		GenerateNoiseMap mapGen = (GenerateNoiseMap)target;

		if (DrawDefaultInspector ()) {
			if (mapGen.autoUpdate) {
				mapGen.GenerateMap ();
			}
		}

		if (GUILayout.Button ("Init")) {
			mapGen.GenerateMap ();
		}
	}
}