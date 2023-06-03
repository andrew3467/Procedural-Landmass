using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public struct MeshData {
    public Vector3[] Vertices;
    public Vector2[] UV;
    public int[] Triangles;

    int TriIndex;

    public MeshData(int w, int h) {
        Vertices = new Vector3[w * h];
        UV = new Vector2[w * h];
        Triangles = new int[6 * (w - 1) * (h - 1)];

        TriIndex = 0;
    }

    public void AddTriangle(int a, int b, int c) {
        Triangles[TriIndex] = a;
        Triangles[TriIndex + 1] = b;
        Triangles[TriIndex + 2] = c;
        TriIndex += 3;
    }

    public Mesh CreateMesh() {
        Mesh mesh = new Mesh();

        mesh.indexFormat = IndexFormat.UInt32;
        
        mesh.vertices = Vertices;
        mesh.uv = UV;
        mesh.triangles = Triangles;
        
        mesh.RecalculateBounds();
        mesh.RecalculateNormals();
        mesh.RecalculateTangents();

        return mesh;
    }
}
