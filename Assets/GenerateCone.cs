using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class GenerateCone : MonoBehaviour
{
    [Range(4, 100)]
    public int NumBaseVertices;

    [Range(3.0f, 100.0f)]
    public float Radius;

    [Range(3.0f, 100.0f)]
    public float Height;

    private 
    void Start()
    {
        var meshFilter = GetComponent<MeshFilter>();
        meshFilter.mesh = CreatMesh();
    }

    private Mesh CreatMesh()
    {
        var mesh = new Mesh()
        {
            name = "Cone"
        };

        var vertices = new List<Vector3>();
        var colors = new List<Color>();

        // Faces
        for (int i = 0; i < NumBaseVertices; i++)
        {
            vertices.Add(new Vector3(Radius * Mathf.Cos(i * (2 * Mathf.PI / NumBaseVertices)), 0.0f, Radius * Mathf.Sin(i * (2 * Mathf.PI / NumBaseVertices))));
            vertices.Add(new Vector3(0.0f, Height, 0.0f));
            vertices.Add(new Vector3(Radius * Mathf.Cos((i + 1) * (2 * Mathf.PI / NumBaseVertices)), 0.0f, Radius * Mathf.Sin((i + 1) * (2 * Mathf.PI / NumBaseVertices))));
            Color color = new(0.0f, (255-(i*255/NumBaseVertices))/255f, (i * 255 / NumBaseVertices)/255f);
            colors.Add(color);
            colors.Add(color);
            colors.Add(color);
        }

        //Bottom
        for (int i = 0; i < NumBaseVertices; i++)
        {
            vertices.Add(new Vector3(Radius * Mathf.Cos(i * (2 * Mathf.PI / NumBaseVertices)), 0.0f, -Radius * Mathf.Sin(i * (2 * Mathf.PI / NumBaseVertices))));
            vertices.Add(new Vector3(0.0f, 0.0f, 0.0f));
            vertices.Add(new Vector3(Radius * Mathf.Cos((i + 1) * (2 * Mathf.PI / NumBaseVertices)), 0.0f, -Radius * Mathf.Sin((i + 1) * (2 * Mathf.PI / NumBaseVertices))));
            colors.Add(Color.gray);
            colors.Add(Color.gray);
            colors.Add(Color.gray);
        }

        mesh.SetVertices(vertices);
        mesh.SetColors(colors);

        var indices = Enumerable.Range(0, mesh.vertices.Length).ToArray();
        mesh.SetIndices(indices, MeshTopology.Triangles, 0);


        return mesh;
    }

    private void Update()
    {
        var mesh = GetComponent<MeshFilter>();
        mesh.mesh = CreatMesh();
    }
}
