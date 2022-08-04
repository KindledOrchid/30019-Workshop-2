using UnityEngine;
using System.Linq;

public class GeneratePyramid : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var meshFilter = GetComponent<MeshFilter>();
        meshFilter.mesh = CreatMesh();
    }

    private Mesh CreatMesh()
    {
        var mesh = new Mesh()
        {
            name = "Pyramid"
        };

        mesh.SetVertices(new[]
        {
            // Front
            new Vector3(0.0f, 1.0f, 0.0f),
            new Vector3(1.0f, -1.0f, -1.0f),
            new Vector3(-1.0f, -1.0f, -1.0f),

            // Right
            new Vector3(0.0f, 1.0f, 0.0f),
            new Vector3(1.0f, -1.0f, 1.0f),
            new Vector3(1.0f, -1.0f, -1.0f),

            // Back
            new Vector3(0.0f, 1.0f, 0.0f),
            new Vector3(-1.0f, -1.0f, 1.0f),
            new Vector3(1.0f, -1.0f, 1.0f),

            // Left
            new Vector3(0.0f, 1.0f, 0.0f),
            new Vector3(-1.0f, -1.0f, -1.0f),
            new Vector3(-1.0f, -1.0f, 1.0f),

            // Bottom
            new Vector3(-1.0f, -1.0f, 1.0f),
            new Vector3(-1.0f, -1.0f, -1.0f),
            new Vector3(1.0f, -1.0f, -1.0f),

            new Vector3(1.0f, -1.0f, -1.0f),
            new Vector3(1.0f, -1.0f, 1.0f),
            new Vector3(-1.0f, -1.0f, 1.0f)
        });

        mesh.SetColors(new[]
        {
            // Front
            Color.blue,
            Color.blue,
            Color.blue,

            // Right
            Color.yellow,
            Color.yellow,
            Color.yellow,

            // Back
            Color.green,
            Color.green,
            Color.green,

            // Left
            Color.gray,
            Color.gray,
            Color.gray,

            // Bottom
            Color.red,
            Color.red,
            Color.red,

            Color.red,
            Color.red,
            Color.red
        });

        var indices = Enumerable.Range(0, mesh.vertices.Length).ToArray();
        mesh.SetIndices(indices, MeshTopology.Triangles, 0);

        return mesh;

    }
}
