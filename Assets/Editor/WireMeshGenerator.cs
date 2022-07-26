using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System.Linq;

namespace S2Lab
{

public static class WireMeshGenerator
{
    [MenuItem("Assets/S2Lab/Convert to Wire Mesh", true)]
    static bool ValidateConvertMesh()
      => SelectedMeshes.Length > 0;

    [MenuItem("Assets/S2Lab/Convert to Wire Mesh")]
    static void ConvertMesh()
      => SelectedMeshes.Select(x => ConvertMesh((Mesh)x))
                       .ToList().ForEach(x => SaveMesh(x));

    static Object[] SelectedMeshes
      => Selection.GetFiltered(typeof(Mesh), SelectionMode.Deep);

    static void SaveMesh(Mesh mesh)
      => ProjectWindowUtil.CreateAsset(mesh, $"{mesh.name}_Wire.asset");

    static Mesh ConvertMesh(Mesh source)
    {
        var mesh = new Mesh();
        var indices = ConvertIndices(source.GetIndices(0));
        mesh.name = source.name;
        mesh.SetVertices(source.vertices);
        mesh.SetIndices(indices, MeshTopology.Lines, 0);
        mesh.RecalculateBounds();
        return mesh;
    }

    static List<int> ConvertIndices(int[] source)
    {
        var buffer = new List<int>();
        for (var i = 0; i < source.Length; i += 3)
        {
            var (i1, i2, i3) = (source[i], source[i + 1], source[i + 2]);
            buffer.Add(i1); buffer.Add(i2);
            buffer.Add(i2); buffer.Add(i3);
            buffer.Add(i3); buffer.Add(i1);
        }
        return buffer;
    }
}

} // namespace S2Lab
