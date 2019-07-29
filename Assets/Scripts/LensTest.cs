using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class LensTest : MonoBehaviour {

    [SerializeField] float r1;
    [SerializeField] float r2;
    [SerializeField] float d;
    [SerializeField] float maxR;

    public void Test () {
        new Lens(r1, r2, 1f, d, maxR);
    }
	
}

#if UNITY_EDITOR

[CustomEditor(typeof(LensTest))]
public class LensTestEditor : Editor {

    public override void OnInspectorGUI () {
        DrawDefaultInspector();
        if(GUILayout.Button("Test")){
            ((LensTest)target).Test();
        }
    }

}

#endif