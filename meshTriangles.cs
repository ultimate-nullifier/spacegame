using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meshTriangles : MonoBehaviour
{
    Mesh mesh;
    int resolution;
    Vector3 localUp;
    Vector3 axisA;
    Vector3 axisB;
    meshTriangles triangleTest;

    public meshTriangles(Mesh mesh, int resolution, Vector3 localUp)
    {
        this.mesh = mesh;
        this.resolution = resolution;
        this.localUp = localUp;

        axisA = new Vector3(localUp.y, localUp.z, localUp.x);
        axisB = Vector3.Cross(localUp, axisA);
    }

    public void ConstructMesh()
    {
        mesh.vertices = new Vector3[]
        {
            localUp,
            axisA,
            axisB
        };

        mesh.triangles = new int[]
        {
            0, 1, 2
        };
    }

    void Start()
    {
        gameObject.AddComponent<MeshFilter>();
        gameObject.AddComponent<MeshRenderer>();
        Mesh mesh = GetComponent<MeshFilter>().mesh;
        mesh.Clear();
        triangleTest = new meshTriangles(mesh, 1, Vector3.up);
        triangleTest.ConstructMesh();
    }
}
