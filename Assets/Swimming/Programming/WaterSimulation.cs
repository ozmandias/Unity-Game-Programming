using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSimulation : MonoBehaviour {
	Mesh waterMesh;
	Vector3[] originalVertices;
	Vector3[] newVertices;

	/*Vector3[] vertices;
	Vector3[] normals;*/

	/*public Vector3 scale = new Vector3(0.1f, 0.1f, 0.1f);
    public Vector3 speed = new Vector3(1.0f,1.0f,1.0f);
    public Vector3 waveDistance = new Vector3(1.0f,1.0f,1.0f);
    public Vector3 noiseStrength = new Vector3(1.0f,1.0f,1.0f);
    public Vector3 noiseWalk = new Vector3(1.0f,1.0f,1.0f);*/

	public float Scale = 0.1f;
    public float Speed = 1.0f;
	public float NoiseStrength = 1f;
    public float NoiseWalk = 1f;

	// Use this for initialization
	void Start () {
		waterMesh = GetComponent<MeshFilter>().mesh;
	}
	
	// Update is called once per frame
	void Update () {
		Simulate();
	}

	void Simulate() {
		// Debug.Log("Simulate");
		
		/*vertices = waterMesh.vertices;
		normals = waterMesh.normals;
		int i = 0;
		while(i < vertices.Length) {
			vertices[i] += normals[i] * Mathf.Sin(Time.time);
			i = i + 1;
		}*/

		if(originalVertices == null) {
			originalVertices = waterMesh.vertices;
		}
		newVertices = new Vector3[originalVertices.Length];

		for(int i=0; i<originalVertices.Length; i=i+1) {
			Vector3 vertex = originalVertices[i];
			// vertex = transform.TransformPoint(vertex);
			vertex.y += Mathf.Sin(Time.time * Speed + originalVertices[i].x + originalVertices[i].y + originalVertices[i].z) * Scale /*GetWave(vertex)*/; // vertex up movement
			vertex.y += Mathf.PerlinNoise(originalVertices[i].x + NoiseWalk, originalVertices[i].y + Mathf.Sin(Time.time * 0.1f)) * NoiseStrength;
			// newVertices[i] = transform.InverseTransformPoint(vertex);
			newVertices[i] = vertex;
		}

		waterMesh.vertices = newVertices /*vertices*/;
		// waterMesh.RecalculateNormals();
	}

	/*public Vector3 GetWave(Vector3 coord)
    {
        Vector3 xyz_coord1 = Vector3.zero;
        Vector3 xyz_coord2 = Vector3.zero;
       
        xyz_coord1.x += Mathf.Cos((Time.time * speed.x + coord.z)/waveDistance.x)*scale.x;
        xyz_coord1.x += Mathf.PerlinNoise(coord.y + noiseWalk.x, coord.z + Mathf.Sin(Time.time * 0.1f)) * noiseStrength.x;

        xyz_coord1.y += Mathf.Sin((Time.time * speed.y + coord.z)/waveDistance.y)*scale.y;
        xyz_coord1.y += Mathf.PerlinNoise(coord.x + noiseWalk.y, coord.z + Mathf.Sin(Time.time * 0.1f)) * noiseStrength.y;

        xyz_coord2.y += Mathf.Sin((Time.time * speed.y + coord.x)/waveDistance.y)*scale.y;
        xyz_coord2.y += Mathf.PerlinNoise(coord.x + noiseWalk.y, coord.z + Mathf.Sin(Time.time * 0.1f)) * noiseStrength.y;

        xyz_coord1.z += Mathf.Cos((Time.time * speed.z + coord.x)/waveDistance.z)*scale.z;
        xyz_coord1.z += Mathf.PerlinNoise(coord.x + noiseWalk.z, coord.y + Mathf.Sin(Time.time * 0.1f)) * noiseStrength.z;

        return xyz_coord1+xyz_coord2;
    }*/
}
