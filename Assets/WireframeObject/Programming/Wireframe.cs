using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wireframe : MonoBehaviour {

	Vector3 startVertex;
	Vector3 mousePos;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		startVertex = new Vector3(mousePos.x / Screen.width, mousePos.y / Screen.height, 0);
		mousePos = Input.mousePosition;
	}

	void OnPreRender()
    {
        GL.wireframe = true;
    }

    void OnPostRender()
    {
        GL.wireframe = true;
		
		// GL.Begin(GL.LINES);
        // GL.Color(Color.red);
        // GL.Vertex(startVertex);
        // GL.Vertex(new Vector3(mousePos.x / Screen.width, mousePos.y / Screen.height, 0));
        // GL.End();
    }
}
